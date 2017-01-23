using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharePointPnP.PowerShell.ModuleFilesGenerator
{
    internal class ModuleManifestGenerator
    {
        private string _assemblyPath;
        private string _configurationName;
        private List<Model.CmdletInfo> _cmdlets;
        private Version _assemblyVersion;

        public ModuleManifestGenerator(List<Model.CmdletInfo> cmdlets, string assemblyPath, string configurationName, Version assemblyVersion)
        {
            _cmdlets = cmdlets;
            _assemblyPath = assemblyPath;
            _configurationName = configurationName;
            _assemblyVersion = assemblyVersion;
        }
        internal void Generate()
        {
            var spVersion = string.Empty;
            switch (_configurationName.ToLowerInvariant())
            {
                case "debug":
                case "release":
                    {
                        spVersion = "Online";
                        break;
                    }
                case "debug15":
                case "release15":
                    {
                        spVersion = "2013";
                        break;

                    }
                case "debug16":
                case "release16":
                    {
                        spVersion = "2016";
                        break;
                    }
            }
            // Generate PSM1 file
            var aliasesToExport = new List<string>();
            var psm1Path = $"{new FileInfo(_assemblyPath).Directory}\\ModuleFiles\\SharePointPnPPowerShell{spVersion}Aliases.psm1";
            var aliasBuilder = new StringBuilder();
            foreach (var cmdlet in _cmdlets.Where(c => c.Aliases.Any()))
            {
                foreach (var alias in cmdlet.Aliases)
                {
                    var aliasLine = $"Set-Alias -Name {alias} -Value {cmdlet.FullCommand}";
                    aliasBuilder.AppendLine(aliasLine);
                    aliasesToExport.Add(alias);
                }
            }
            File.WriteAllText(psm1Path, aliasBuilder.ToString());

            // Create Module Manifest
            var psd1Path = $"{new FileInfo(_assemblyPath).Directory}\\ModuleFiles\\SharePointPnPPowerShell{spVersion}.psd1";
            var cmdletsToExportString = string.Join(",", _cmdlets.Select(c => "'" + c.FullCommand + "'"));
            var aliasesToExportString = string.Join(",", aliasesToExport.Select(x => "'" + x + "'"));
            WriteModuleManifest(psd1Path, spVersion, cmdletsToExportString, aliasesToExportString);
        }

        private void WriteModuleManifest(string path, string spVersion, string cmdletsToExport, string aliasesToExport)
        {
            var manifest = $@"@{{
    RootModule = 'SharePointPnP.PowerShell.{spVersion}.Commands.dll'
    NestedModules = @('SharePointPnPPowerShell{spVersion}Aliases.psm1')
    ModuleVersion = '{_assemblyVersion}'
    Description = 'SharePoint Patterns and Practices PowerShell Cmdlets for SharePoint {spVersion}'
    GUID = '8f1147be-a8e4-4bd2-a705-841d5334edc0'
    Author = 'SharePoint Patterns and Practices'
    CompanyName = 'SharePoint Patterns and Practices'
    DotNetFrameworkVersion = '4.5'
    ProcessorArchitecture = 'None'
    FunctionsToExport = '*'
    CmdletsToExport = {cmdletsToExport}
    VariablesToExport = '*'
    AliasesToExport = {aliasesToExport}
    FormatsToProcess = 'SharePointPnP.PowerShell.{spVersion}.Commands.Format.ps1xml' 
}}";
            File.WriteAllText(path, manifest, Encoding.UTF8);
        }
    }
}
