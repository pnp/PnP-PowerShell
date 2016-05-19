using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.Commands.Base;
using File = Microsoft.SharePoint.Client.File;
using PnPResources = SharePointPnP.PowerShell.Commands.Properties.Resources;

namespace SharePointPnP.PowerShell.Commands.Provider
{
    [CmdletProvider("SPO", ProviderCapabilities.ShouldProcess)]
    public class SPOProvider : NavigationCmdletProvider, IContentCmdletProvider
    {
        //Private properties
        private const string Pattern = @"^[\\w\\d\\.\\s]*$";
        private const string PathSeparator = "/";
        private const int DefaultCacheTimeout = 1000;

        //Init
        protected override ProviderInfo Start(ProviderInfo providerInfo)
        {
#if DEBUG
            SessionState.PSVariable.Set("WebRequestCounter", 0);
#endif
            return base.Start(providerInfo);
        }

        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            WriteVerbose(string.Format("SPOProvider::NewDrive (Drive.Name = ’{0}’, Drive.Root = ’{1}’)", drive.Name, drive.Root));

            var spoParametes = DynamicParameters as SPODriveParameters;
            var spoDrive = new SPODriveInfo(drive);
            if (spoParametes != null && spoParametes.UseCurrentSPOContext)
            {
                if (SPOnlineConnection.CurrentConnection != null)
                {
                    spoDrive.Web = SPOnlineConnection.CurrentConnection.Context.Web;
                }
                else
                {
                    WriteErrorInternal(PnPResources.NoConnection, spoDrive, ErrorCategory.ConnectionError);
                }
            }
            else if (spoParametes != null && spoParametes.Web != null)
            {
                var webUrl = spoParametes.Web.EnsureProperty(w => w.ServerRelativeUrl);
                spoDrive.Web = spoParametes.Web.Context.Clone(webUrl).Web;
            }
            else if (spoParametes != null && spoParametes.Url != null && SPOnlineConnection.CurrentConnection != null)
            {
                var cloneCtx = SPOnlineConnection.CurrentConnection.Context.Clone(spoParametes.Url);
                spoDrive.Web = cloneCtx.Web;

            }
            else if (SPOnlineConnection.CurrentConnection != null)
            {
                var webUrl = SPOnlineConnection.CurrentConnection.Context.Web.EnsureProperty(w => w.Url);
                spoDrive.Web = SPOnlineConnection.CurrentConnection.Context.Clone(webUrl).Web;
            }
            else
            {
                WriteErrorInternal(PnPResources.NoConnection, spoDrive, ErrorCategory.ConnectionError);
            }

            spoDrive.Timeout = (spoParametes != null && spoParametes.CacheTimeout != default(int)) ? spoParametes.CacheTimeout : DefaultCacheTimeout;

#if DEBUG
            spoDrive.Web.Context.ExecutingWebRequest += (sender, args) =>
            {
                var counter = (int)SessionState.PSVariable.Get("WebRequestCounter").Value;
                counter++;
                SessionState.PSVariable.Set("WebRequestCounter", counter);
            };
#endif

            spoDrive.NormalizedRoot = NormalizeRoot(spoDrive);

            if (!ValidateRoot(spoDrive))
            {
                WriteErrorInternal("Unvalid root", spoDrive.Root, ErrorCategory.InvalidArgument);
            }

            //return spoDrive;

            //Set root to normalized root
            return new SPODriveInfo(new PSDriveInfo(spoDrive.Name ,spoDrive.Provider, spoDrive.NormalizedRoot, spoDrive.Description, spoDrive.Credential, spoDrive.DisplayRoot))
            {
                Web = spoDrive.Web,
                Timeout = spoDrive.Timeout,
                NormalizedRoot = spoDrive.NormalizedRoot,
                IsNotClonedContext = spoDrive.IsNotClonedContext
               
            };
        }

        protected override object NewDriveDynamicParameters()
        {
            return new SPODriveParameters();
        }

        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            WriteVerbose(string.Format("SPOProvider::RemoveDrive (Drive.Name = ’{0}’)", drive.Name));

            var spoDrive = drive as SPODriveInfo;
            if (spoDrive == null) return null;

            if (spoDrive.IsNotClonedContext)
            {
                spoDrive.Web.Context.Dispose();
            }

            return spoDrive;
        }

        //Validate
        protected override bool IsValidPath(string path)
        {
            WriteVerbose(string.Format("SPOProvider::IsValidPath (Path = ’{0}’)", path));
            return Regex.IsMatch(path, Pattern);
        }

        protected override bool IsItemContainer(string path)
        {
            WriteVerbose(string.Format("SPOProvider::IsItemContainer (Path = ’{0}’)", path));

            try
            {
                if (PathIsDrive(path)) return true;
                return GetFileOrFolder(path, false) is Folder;
            }
            catch (Exception e)
            {
                WriteErrorInternal(e.Message, path, exception: e);
                return false;
            }
        }

        protected override bool ItemExists(string path)
        {
            WriteVerbose(string.Format("SPOProvider::ItemExists (Path = ’{0}’)", path));

            if (PathIsDrive(path)) return true;
            try
            {
                return GetFileOrFolder(path, false) != null;
            }
            catch (Exception e)
            {
                WriteErrorInternal(e.Message, path, exception: e);
                return false;
            }
        }

        protected override bool HasChildItems(string path)
        {
            WriteVerbose(string.Format("SPOProvider::HasChildItems (Path = ’{0}’)", path));

            try
            {
                var folder = GetFileOrFolder(path) as Folder;
                if (folder != null)
                {
                    var folderAndFiles = GetFolderItems(folder, false);
                    return folderAndFiles.Any();
                }
                return false;
            }
            catch (Exception e)
            {
                WriteErrorInternal(e.Message, path, exception: e);
                return false;
            }
        }

        //Path
        protected override string MakePath(string parent, string child)
        {
            var result = base.MakePath(parent, child);
            WriteVerbose(string.Format("SPOProvider::MakePath (parent = ’{0}’, child = ’{1}’) = {2}", parent, child, result));
            return result;
        }

        protected override string GetParentPath(string path, string root)
        {
            var result = base.GetParentPath(path, root);
            WriteVerbose(string.Format("SPOProvider::GetParentPath (path = ’{0}’, root = ’{1}’) = {2}", path, root, result));
            return result;
        }

        protected override string GetChildName(string path)
        {
            WriteVerbose(string.Format("SPOProvider::GetChildName YYY (path = ’{0}’) = {1}", path, base.GetChildName(path)));
            return base.GetChildName(path);
        }

        protected override string NormalizeRelativePath(string path, string basePath)
        {
            var result = base.NormalizeRelativePath(path, basePath);
            WriteVerbose(string.Format("SPOProvider::NormalizeRelativePath (path = ’{0}’, basePath = ’{1}’) = {2}", path, basePath, result));
            return result;
        }

        //Get
        protected override void GetItem(string path)
        {
            WriteVerbose(string.Format("SPOProvider::GetItem (Path = ’{0}’)", path));

            var obj = GetFileOrFolder(path);
            if (obj != null)
            {
                WriteItemObject(obj, GetServerRelativePath(path), (obj is Folder));
            }
        }

        protected override void GetChildItems(string path, bool recurse)
        {
            WriteVerbose(string.Format("SPOProvider::GetChildItems (Path = ’{0}’)", path));

            var folder = GetFileOrFolder(path) as Folder;
            if (folder != null)
            {
                WriteItemObject(string.Format("\nFolder: {0}\n", folder.ServerRelativeUrl), GetServerRelativePath(path), true);

                var folderAndFiles = GetFolderItems(folder).ToArray();
                folderAndFiles.OfType<Folder>().ToList().ForEach(subFolder => WriteItemObject(subFolder, GetServerRelativePath(path), true));
                folderAndFiles.OfType<File>().ToList().ForEach(file => WriteItemObject(file, GetServerRelativePath(path), false));

                if (recurse)
                {
                    folderAndFiles.OfType<Folder>().ToList().ForEach(subFolder => GetChildItems(subFolder.ServerRelativeUrl, true));
                }
            }
            else
            {
                WriteErrorInternal("No folder at end of path", path, ErrorCategory.InvalidOperation);
            }
        }

        protected override void GetChildNames(string path, ReturnContainers returnContainers)
        {
            WriteVerbose(string.Format("SPOProvider::GetChildNames (Path = ’{0}’)", path));

            var folder = GetFileOrFolder(path) as Folder;
            if (folder != null)
            {
                var folderAndFiles = GetFolderItems(folder).ToArray();

                folderAndFiles.OfType<Folder>().ToList().ForEach(subFolder => WriteItemObject(subFolder.Name, GetServerRelativePath(path), true));
                folderAndFiles.OfType<File>().ToList().ForEach(file => WriteItemObject(file.Name, GetServerRelativePath(path), false));
            }
            else
            {
                WriteErrorInternal("No folder at end of path", path, ErrorCategory.InvalidOperation);
            }
        }

        //Set
        protected override void CopyItem(string path, string copyPath, bool recurse)
        {
            WriteVerbose(string.Format("SPOProvider::CopyItem (Path = ’{0}’, copyPath = ’{1}’)", path, copyPath));

            if (!IsSameDrive(path, copyPath))
            {
                var msg = "Copy between drives is not implemented, yet";
                var err = new NotImplementedException(msg);
                WriteErrorInternal(msg, path, ErrorCategory.NotImplemented, exception:err);
                return;
            }

            var source = GetFileOrFolder(path);
            if (source == null) return;

            var spoDrive = GetCurrentDrive(path);
            if (spoDrive == null) return;

            var targetUrl = GetServerRelativePath(copyPath);
            var isTargetFile = targetUrl.Split(PathSeparator.ToCharArray()).Last().Contains(".");
            var targetFolderPath = (isTargetFile) ? GetParentServerRelativePath(targetUrl) : targetUrl;
            var targetFolder = spoDrive.Web.EnsureFolderPath(PathSeparator + GetWebRelativePath(targetFolderPath));

            if (ShouldProcess(string.Format("Copy {0} to {1}", GetServerRelativePath(path), targetUrl)))
            {
                if (source is File)
                {
                    var sourceFile = source as File;
                    if (isTargetFile)
                    {
                        sourceFile.CopyTo(targetUrl, Force);
                    }
                    else
                    {
                        sourceFile.CopyTo(targetFolderPath + PathSeparator + sourceFile.Name, Force);
                    }
                    sourceFile.Context.ExecuteQueryRetry();
                }
                else if (source is Folder && !isTargetFile)
                {
                    var sourceFolder = source as Folder;
                    var folderAndFiles = GetFolderItems(sourceFolder);

                    foreach (var folder in folderAndFiles.OfType<Folder>())
                    {
                        var newSubFolder = targetFolder.CreateFolder(folder.Name);
                        if (recurse)
                        {
                            CopyItem(folder.ServerRelativeUrl, newSubFolder.ServerRelativeUrl, recurse);
                        }
                    }
                    foreach (var file in folderAndFiles.OfType<File>())
                    {
                        file.CopyTo(targetFolderPath + PathSeparator + file.Name, Force);
                        file.Context.ExecuteQueryRetry();
                    }
                }
                else
                {
                    WriteErrorInternal("Operation not supported", path, ErrorCategory.InvalidOperation);
                }
            }
        }

        protected override void MoveItem(string path, string destination)
        {
            WriteVerbose(string.Format("SPOProvider::CopyItem (Path = ’{0}’, destination = ’{1}’)", path, destination));

            if (!IsSameDrive(path, destination))
            {
                var msg = "Move between drives is not implemented, yet";
                var err = new NotImplementedException(msg);
                WriteErrorInternal(msg, path, ErrorCategory.NotImplemented, exception: err);
                return;
            }

            var source = GetFileOrFolder(path);
            if (source == null) return;

            var spoDrive = GetCurrentDrive(path);
            if (spoDrive == null) return;

            var targetUrl = GetServerRelativePath(destination);
            var isTargetFile = targetUrl.Split(PathSeparator.ToCharArray()).Last().Contains(".");
            var targetFolderPath = (isTargetFile) ? GetParentServerRelativePath(targetUrl) : targetUrl;
            var targetFolder = spoDrive.Web.EnsureFolderPath(GetWebRelativePath(targetFolderPath));
            var moveToOperations = (Force) ? MoveOperations.Overwrite : MoveOperations.None;

            if (ShouldProcess(string.Format("Move {0} to {1}", GetServerRelativePath(path), targetUrl)))
            {
                if (source is File)
                {
                    var sourceFile = source as File;
                    if (isTargetFile)
                    {
                        sourceFile.MoveTo(targetUrl, moveToOperations);
                    }
                    else
                    {
                        sourceFile.MoveTo(targetFolderPath + PathSeparator + sourceFile.Name, moveToOperations);
                    }
                    sourceFile.Context.ExecuteQueryRetry();

                }
                else if (source is Folder && !isTargetFile)
                {
                    var sourceFolder = source as Folder;
                    var folderAndFiles = GetFolderItems(sourceFolder);

                    //Create new folders recursively
                    foreach (var folder in folderAndFiles.OfType<Folder>())
                    {
                        var newSubFolder = targetFolder.CreateFolder(folder.Name);
                        MoveItem(folder.ServerRelativeUrl, newSubFolder.ServerRelativeUrl);
                    }
                    //Move files
                    foreach (var file in folderAndFiles.OfType<File>())
                    {
                        file.MoveTo(targetFolderPath + PathSeparator + file.Name, moveToOperations);
                        file.Context.ExecuteQueryRetry();
                    }
                    //Remove source folders
                    sourceFolder.DeleteObject();
                    spoDrive.Web.Context.ExecuteQueryRetry();
                }
                else
                {
                    WriteErrorInternal("Operation not supported", path, ErrorCategory.InvalidOperation);
                }
            }

        }

        protected override void RenameItem(string path, string newName)
        {
            MoveItem(path, GetParentServerRelativePath(path) + PathSeparator + newName);
        }

        protected override void RemoveItem(string path, bool recurse)
        {
            WriteVerbose(string.Format("SPOProvider::CopyItem (Path = ’{0}’)", path));

            var obj = GetFileOrFolder(path);

            if (obj != null && ShouldProcess(GetServerRelativePath(path), string.Format("{0} {1}", (Force) ? "Delete" : "Recycle", obj.GetType().Name)))
            {
                if (obj is File)
                {
                    var file = obj as File;
                    if (Force)
                    {
                        file.DeleteObject();
                    }
                    else
                    {
                        file.Recycle();
                    }
                    file.Context.ExecuteQueryRetry();
                }
                else if (obj is Folder)
                {
                    var folder = obj as Folder;
                    if (Force)
                    {
                        folder.DeleteObject();
                    }
                    else
                    {
                        folder.Recycle();
                    }

                    folder.Context.ExecuteQueryRetry();
                }
            }
        }

        protected override void NewItem(string path, string itemTypeName, object newItemValue)
        {
            WriteVerbose(string.Format("SPOProvider::CopyItem (Path = ’{0}’, itemTypeName = ’{1}’)", path, itemTypeName));

            var itemUrl = GetServerRelativePath(path);
            var parentUrl = GetParentServerRelativePath(itemUrl);
            if (string.IsNullOrEmpty(itemTypeName)) itemTypeName = "File";

            var parentFolder = GetFileOrFolder(parentUrl) as Folder;
            if (parentFolder != null)
            {
                if (itemTypeName.Equals("file", StringComparison.InvariantCultureIgnoreCase))
                {
                    parentFolder.Files.Add(new FileCreationInformation
                    {
                        Url = itemUrl,
                        Content = System.Text.Encoding.UTF8.GetBytes(newItemValue as string ?? string.Empty),
                        Overwrite = Force
                    });
                }
                else if (itemTypeName.Equals("folder", StringComparison.InvariantCultureIgnoreCase) || itemTypeName.Equals("directory", StringComparison.InvariantCultureIgnoreCase))
                {
                    var folderName = itemUrl.Split(PathSeparator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Last();
                    if (!parentFolder.FolderExists(folderName))
                    {
                        parentFolder.Folders.Add(itemUrl);
                    }
                }
                else
                {
                    WriteErrorInternal("Only File or Folder (Directory) supported for Type", path, ErrorCategory.InvalidArgument);
                }
                parentFolder.Context.ExecuteQueryRetry();
            }
        }

        //Content
        public IContentReader GetContentReader(string path)
        {
            WriteVerbose(string.Format("SPOProvider::GetContentReader(path = ’{0}’)", path));

            var obj = GetFileOrFolder(path);
            if (obj is Folder)
            {
                WriteErrorInternal("Directories have no content", path, ErrorCategory.InvalidOperation);
            }
            if (obj is File)
            {
                var file = obj as File;
                var isString = false;
                var contentParameters = DynamicParameters as SPOContentParameters;
                if (contentParameters != null)
                {
                    isString = contentParameters.IsBinary;
                }
                return new SPOContentReaderWriter(file, isString);
            }

            return null;
        }

        public object GetContentReaderDynamicParameters(string path)
        {
            return new SPOContentParameters();
        }

        public IContentWriter GetContentWriter(string path)
        {
            WriteVerbose(string.Format("SPOProvider::GetContentWriter(path = ’{0}’)", path));

            var obj = GetFileOrFolder(path, false);
            if (obj is Folder)
            {
                WriteErrorInternal("Directories have no content", path, ErrorCategory.InvalidOperation);
            }
            if (obj == null)
            {
                NewItem(path, "File", string.Empty);
                obj = GetFileOrFolder(path);
            }
            if (obj is File)
            {
                var file = obj as File;
                var isBinary = false;
                var contentParameters = DynamicParameters as SPOContentParameters;
                if (contentParameters != null)
                {
                    isBinary = contentParameters.IsBinary;
                }

                if (ShouldProcess(string.Format("Set content in {0}", GetServerRelativePath(path))))
                {
                    return new SPOContentReaderWriter(file, isBinary, provider: this);
                }
            }

            return null;
        }

        public object GetContentWriterDynamicParameters(string path)
        {
            return new SPOContentParameters();
        }

        public void ClearContent(string path)
        {
            WriteVerbose(string.Format("SPOProvider::ClearContent(path = ’{0}’)", path));

            var obj = GetFileOrFolder(path);
            if (obj is Folder)
            {
                WriteErrorInternal("Directories have no content", path, ErrorCategory.InvalidOperation);
            }
            if (obj is File)
            {
                if (ShouldProcess(string.Format("Clear content from {0}", GetServerRelativePath(path))))
                {
                    var file = obj as File;
                    File.SaveBinaryDirect(file.Context as ClientContext, file.ServerRelativeUrl, Stream.Null, true);
                }
            }
        }

        public object ClearContentDynamicParameters(string path)
        {
            return null;
        }


        //Helpers
        private object GetFileOrFolder(string path, bool throwError = true)
        {
            var spoDrive = GetCurrentDrive(path);
            if (spoDrive == null) return null;

            var serverRelativePath = GetServerRelativePath(path);
            if (string.IsNullOrEmpty(serverRelativePath)) return null;

            //Try get cached item
            var fileOrFolder = GetCachedItem(serverRelativePath);
            if (fileOrFolder != null) return fileOrFolder;

            var web = spoDrive.Web;
            var ctx = spoDrive.Web.Context;

            var webUrl = IsPropertyAvailable(web, "ServerRelativeUrl") ? web.ServerRelativeUrl : web.EnsureProperty(w => w.ServerRelativeUrl);

            //If web root return web root folder
            if (serverRelativePath.Equals(webUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                if (!IsPropertyAvailable(web, "RootFolder"))
                {
                    web.EnsureProperty(w => w.RootFolder);
                }
                SetCachedItem(serverRelativePath, web.RootFolder);
                return web.RootFolder;
            }

            //Determine if we should try file or folder first
            var tryFileFirst = serverRelativePath.Split(PathSeparator.ToCharArray()).Last().Contains(".");

            File file;
            Folder folder;

            var scope = new ExceptionHandlingScope(ctx);
            if (tryFileFirst)
            {
                using (scope.StartScope())
                {
                    using (scope.StartTry())
                    {
                        file = web.GetFileByServerRelativeUrl(serverRelativePath);
                        ctx.Load(file);
                    }
                    using (scope.StartCatch())
                    {
                        folder = web.GetFolderByServerRelativeUrl(serverRelativePath);
                        ctx.Load(folder);
                    }
                }
            }
            else
            {
                using (scope.StartScope())
                {
                    using (scope.StartTry())
                    {
                        folder = web.GetFolderByServerRelativeUrl(serverRelativePath);
                        ctx.Load(folder);
                    }
                    using (scope.StartCatch())
                    {
                        file = web.GetFileByServerRelativeUrl(serverRelativePath);
                        ctx.Load(file);
                    }
                }
            }

            try
            {
                ctx.ExecuteQueryRetry();
            }
            catch (Exception e)
            {
                if (throwError)
                {
                    WriteErrorInternal(e.Message, path, ErrorCategory.ObjectNotFound, exception: e);
                }
            }


            //Check if we got data
            if (IsPropertyAvailable(file, "Name"))
            {
                SetCachedItem(serverRelativePath, file);
                return file;
            }
            else if (IsPropertyAvailable(folder, "Name"))
            {
                SetCachedItem(serverRelativePath, folder);
                return folder;
            }
            return null;
        }

        private IEnumerable<object> GetFolderItems(Folder folder, bool throwError = false)
        {
            try
            {
                if (folder != null)
                {
                    if (!IsPropertyAvailable(folder, "ServerRelativeUrl"))
                    {
                        folder.EnsureProperty(f => f.ServerRelativeUrl);
                    }
                    var folderAndFiles = GetCachedChildItems(folder.ServerRelativeUrl);
                    if (folderAndFiles != null) return folderAndFiles;


                    var files = folder.Context.LoadQuery(folder.Files).OrderBy(f => f.Name);
                    var folders = folder.Context.LoadQuery(folder.Folders).OrderBy(f => f.Name);
                    folder.Context.ExecuteQueryRetry();

                    folderAndFiles = folders.Concat<object>(files);
                    SetCachedChildItems(folder.ServerRelativeUrl, folderAndFiles);

                    return folderAndFiles;
                }
            }
            catch (Exception e)
            {
                if (throwError)
                {
                    WriteErrorInternal(e.Message, "GetFolderItems", exception: e);
                }
            }
            return null;
        }

        private SPODriveInfo GetCurrentDrive(string path)
        {
            return PSDriveInfo as SPODriveInfo ?? GetDrive(path);
        }

        private SPODriveInfo GetDrive(string path)
        {
            if (!path.Contains(":")) return null;
            return ProviderInfo.Drives.FirstOrDefault(d => path.StartsWith(d.Name, StringComparison.InvariantCultureIgnoreCase)) as SPODriveInfo;
        }

        private bool ValidateRoot(SPODriveInfo spoDrive)
        {
            if (!spoDrive.NormalizedRoot.StartsWith(PathSeparator)) return false;

            if (spoDrive.Root.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                var webUrl = IsPropertyAvailable(spoDrive.Web, "Url") ? spoDrive.Web.Url : spoDrive.Web.EnsureProperty(w => w.Url);
                if (!spoDrive.Root.StartsWith(webUrl))
                {
                    return false;
                }
            }

            var webRelativeUrl = IsPropertyAvailable(spoDrive.Web, "ServerRelativeUrl") ? spoDrive.Web.ServerRelativeUrl : spoDrive.Web.EnsureProperty(w => w.ServerRelativeUrl);
            if (spoDrive.NormalizedRoot.StartsWith(webRelativeUrl, StringComparison.InvariantCultureIgnoreCase))
            {
                //Try get root folder
                try
                {
                    var rootFolder = spoDrive.Web.GetFolderByServerRelativeUrl(spoDrive.NormalizedRoot);
                    spoDrive.Web.Context.ExecuteQueryRetry();
                    if (rootFolder != null)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private bool IsPropertyAvailable(ClientObject clientObject, string propertyName)
        {
            return clientObject.IsObjectPropertyInstantiated(propertyName) || clientObject.IsPropertyAvailable(propertyName);
        }

        internal void WriteErrorInternal(string message, object path, ErrorCategory errorCategory = ErrorCategory.NotSpecified, bool terminate = false, Exception exception = null)
        {
            exception = exception ?? new Exception(message);
            var error = new ErrorRecord(exception, message, errorCategory, path);

            if (terminate)
            {
                ThrowTerminatingError(error);
            }
            else
            {
                WriteError(error);
            }
        }

        //Path helpers
        private string GetServerRelativePath(string path)
        {
            var spoDrive = GetCurrentDrive(path);
            if (spoDrive == null) return null;

            var normalizedChild = NormalizePath(path);
            var childWithoutDriveAndRoot = RemoveDriveFromPath(normalizedChild);
            var normalizePath = NormalizePath(spoDrive.NormalizedRoot + PathSeparator + childWithoutDriveAndRoot, true);
            return normalizePath;
        }

        private string GetParentServerRelativePath(string path)
        {
            var serverRelativePath = GetServerRelativePath(path);
            if (string.IsNullOrEmpty(serverRelativePath)) return serverRelativePath;

            var index = serverRelativePath.LastIndexOf(PathSeparator);
            if (index > -1)
            {
                return serverRelativePath.Substring(0, index);
            }

            return serverRelativePath;
        }

        private string GetWebRelativePath(string serverRelativePath)
        {
            if (string.IsNullOrEmpty(serverRelativePath)) return serverRelativePath;

            var spoDrive = GetCurrentDrive(serverRelativePath);
            if (spoDrive == null) return null;

            var webPath = IsPropertyAvailable(spoDrive.Web, "ServerRelativeUrl") ? spoDrive.Web.ServerRelativeUrl : spoDrive.Web.EnsureProperty(w => w.ServerRelativeUrl);
            var result = Regex.Replace(serverRelativePath, string.Format(@"^{0}", webPath), string.Empty);
            if (string.IsNullOrEmpty(result)) result = PathSeparator;
            return result;
        }

        private string NormalizePath(string path, bool removeDuplicatePathSeparators = false)
        {
            if (string.IsNullOrEmpty(path)) return path;

            var result = Regex.Replace(path, @"\\", PathSeparator);
            if (removeDuplicatePathSeparators) result = Regex.Replace(result, @"/{2,}", PathSeparator);
            if (Regex.IsMatch(result, string.Format(@"[^{0}]{{1,}}", PathSeparator))) result = result.TrimEnd(PathSeparator.ToCharArray());

            return result;
        }

        private string NormalizeRoot(SPODriveInfo spoDrive)
        {
            var root = spoDrive.Root;
            if (root.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
            {
                Uri uri;
                if (Uri.TryCreate(root, UriKind.Absolute, out uri))
                {
                    root = uri.AbsolutePath;
                }
            }

            var normalizedRoot = NormalizePath(root + PathSeparator, true);
            var webRelativeUrl = IsPropertyAvailable(spoDrive.Web, "ServerRelativeUrl") ? spoDrive.Web.ServerRelativeUrl : spoDrive.Web.EnsureProperty(w => w.ServerRelativeUrl);

            if (!normalizedRoot.StartsWith(webRelativeUrl))
            {
                normalizedRoot = NormalizePath(webRelativeUrl + PathSeparator + normalizedRoot);
            }

            return normalizedRoot;
        }

        private string RemoveDriveFromPath(string path, bool removeRoot = true)
        {
            if (string.IsNullOrEmpty(path)) return path;

            var spoDrive = GetCurrentDrive(path);
            if (spoDrive == null) return path;

            var result = Regex.Replace(path, string.Format(@"^{0}:", spoDrive.Name), string.Empty);
            if (removeRoot) result = Regex.Replace(result, string.Format(@"^{0}", spoDrive.NormalizedRoot), string.Empty);

            return result;

        }

        private bool PathIsDrive(string path)
        {
            var spoDrive = GetCurrentDrive(path);
            if (spoDrive == null) return false;

            var normalizedPath = GetServerRelativePath(path);
            return normalizedPath.Equals(spoDrive.NormalizedRoot, StringComparison.InvariantCultureIgnoreCase);
        }

        private bool IsSameDrive(string path1, string path2)
        {
            var drive1 = GetDrive(path1);
            var drive2 = GetDrive(path2);

            return (drive1 == drive2);
        }

        //Cache helpers
        private object GetCachedItem(string serverRelativePath)
        {
            var spoDrive = GetCurrentDrive(serverRelativePath);
            if (spoDrive == null) return null;

            var cachedItem = spoDrive.CachedItems.FirstOrDefault(c => c.Path == serverRelativePath && (new TimeSpan(DateTime.Now.Ticks - c.LastRefresh.Ticks)).TotalMilliseconds < spoDrive.Timeout);
            return (cachedItem != null) ? cachedItem.Item : null;

        }

        private void SetCachedItem(string serverRelativePath, object obj)
        {
            var spoDrive = GetCurrentDrive(serverRelativePath);
            if (spoDrive == null) return;

            spoDrive.CachedItems.RemoveAll(item => item.Path == serverRelativePath);
            spoDrive.CachedItems.Add(new SPODriveCacheItem
            {
                Path = serverRelativePath,
                LastRefresh = DateTime.Now,
                Item = obj
            });
        }

        private IEnumerable<object> GetCachedChildItems(string serverRelativePath)
        {
            var spoDrive = GetCurrentDrive(serverRelativePath);
            if (spoDrive == null) return null;

            var childItems = spoDrive.CachedItems.Where(c => GetParentServerRelativePath(c.Path) == serverRelativePath && (new TimeSpan(DateTime.Now.Ticks - c.LastRefresh.Ticks)).TotalMilliseconds < spoDrive.Timeout);
            return childItems.Any() ? childItems.Select(c => c.Item) : null;
        }

        private void SetCachedChildItems(string parentServerRelativePath, IEnumerable<object> childItems)
        {
            var spoDrive = GetCurrentDrive(parentServerRelativePath);
            if (spoDrive == null) return;

            foreach (var item in childItems)
            {
                var name = string.Empty;
                var folder = item as Folder;
                var file = item as File;

                if (folder != null)
                {
                    name = folder.Name;
                }
                else if (file != null)
                {
                    name = file.Name;
                }
                SetCachedItem(parentServerRelativePath.TrimEnd(PathSeparator.ToCharArray()) + PathSeparator + name, item);
            }
        }

    }
}
