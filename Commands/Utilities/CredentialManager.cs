using System;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.Win32.SafeHandles;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace SharePointPnP.PowerShell.Commands.Utilities
{
    internal static class CredentialManager
    {

#if NETSTANDARD2_0
        public static bool AddCredential(string name, string username, SecureString password, bool overwrite)
#else
        public static bool AddCredential(string name, string username, SecureString password)
#endif
        {
#if !NETSTANDARD2_0
            WriteCredential(name, username, password);
            return true;
#else
            if (OperatingSystem.IsWindows())
            {
                WriteCredential(name, username, password);
            } else if (OperatingSystem.IsMacOS())
            {
                var pw = SecureStringToString(password);
                var cmd = $"/usr/bin/security add-generic-password -a '{username}' -w '{pw}' -s '{name}'";
                if (overwrite)
                {
                    cmd += " -U";
                }
                Shell.Bash(cmd);
            }
            return true;
#endif
        }

        private static void WriteCredential(string applicationName, string userName, SecureString securePassword)
        {
            //https://gist.github.com/meziantou/10311113

            var password = SecureStringToString(securePassword);

            byte[] byteArray = password == null ? null : Encoding.Unicode.GetBytes(password);
            // XP and Vista: 512; 
            // 7 and above: 5*512
            if (Environment.OSVersion.Version < new Version(6, 1) /* Windows 7 */)
            {
                if (byteArray != null && byteArray.Length > 512)
                    throw new ArgumentOutOfRangeException("password", "The secret message has exceeded 512 bytes.");
            }
            else
            {
                if (byteArray != null && byteArray.Length > 512 * 5)
                    throw new ArgumentOutOfRangeException("password", "The secret message has exceeded 2560 bytes.");
            }

            NativeCredential credential = new NativeCredential();
            credential.AttributeCount = 0;
            credential.Attributes = IntPtr.Zero;
            credential.Comment = IntPtr.Zero;
            credential.TargetAlias = IntPtr.Zero;
            credential.Type = CRED_TYPE.GENERIC;
            credential.Persist = (uint)3;
            credential.CredentialBlobSize = (uint)(byteArray == null ? 0 : byteArray.Length);
            credential.TargetName = Marshal.StringToCoTaskMemUni(applicationName);
            credential.CredentialBlob = Marshal.StringToCoTaskMemUni(password);
            credential.UserName = Marshal.StringToCoTaskMemUni(userName ?? Environment.UserName);

            bool written = CredWrite(ref credential, 0);
            Marshal.FreeCoTaskMem(credential.TargetName);
            Marshal.FreeCoTaskMem(credential.CredentialBlob);
            Marshal.FreeCoTaskMem(credential.UserName);

            if (!written)
            {
                int lastError = Marshal.GetLastWin32Error();
                throw new Exception(string.Format("CredWrite failed with the error code {0}.", lastError));
            }
        }

        public static PSCredential GetCredential(string name)
        {
#if !NETSTANDARD2_0
            PSCredential psCredential = null;
            IntPtr credPtr;

            bool success = CredRead(name, CRED_TYPE.GENERIC, 0, out credPtr);
            if (success)
            {
                var critCred = new CriticalCredentialHandle(credPtr);
                var cred = critCred.GetCredential();
                var username = cred.UserName;
                var securePassword = new SecureString();
                string credentialBlob = cred.CredentialBlob;
                char[] passwordChars = credentialBlob.ToCharArray();
                foreach (char c in passwordChars)
                {
                    securePassword.AppendChar(c);
                }
                psCredential = new PSCredential(username, securePassword);
            }
            return psCredential;
#else
            if (OperatingSystem.IsWindows())
            {
                PSCredential psCredential = null;
                IntPtr credPtr;

                bool success = CredRead(name, CRED_TYPE.GENERIC, 0, out credPtr);
                if (success)
                {
                    var critCred = new CriticalCredentialHandle(credPtr);
                    var cred = critCred.GetCredential();
                    var username = cred.UserName;
                    var securePassword = StringToSecureString(cred.CredentialBlob);
                    psCredential = new PSCredential(username, securePassword);
                }
                return psCredential;
            }
            if (OperatingSystem.IsMacOS())
            {
                var cmd = $"/usr/bin/security find-generic-password -s '{name}'";
                var output = Shell.Bash(cmd);
                string username = null;
                string password = null;
                foreach (var line in output)
                {                
                    if (line.Trim().StartsWith(@"""acct"""))
                    {
                        var acctline = line.Trim().Split(new string[] { "<blob>=" }, StringSplitOptions.None);
                        username = acctline[1].Trim(new char[] { '"' });
                    }
                }
                cmd = $"/usr/bin/security find-generic-password -s '{name}' -w";
                output = Shell.Bash(cmd);
                if(output.Count == 1)
                {
                    password = output[0];
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    return new PSCredential(username, StringToSecureString(password));
                }
            }
            return null;
#endif

        }

        private static SecureString StringToSecureString(string inputString)
        {
            var securityString = new SecureString();
            char[] chars = inputString.ToCharArray();
            foreach (var c in chars)
            {
                securityString.AppendChar(c);
            }
            return securityString;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct NativeCredential
        {
            public UInt32 Flags;
            public CRED_TYPE Type;
            public IntPtr TargetName;
            public IntPtr Comment;
            public FILETIME LastWritten;
            public UInt32 CredentialBlobSize;
            public IntPtr CredentialBlob;
            public UInt32 Persist;
            public UInt32 AttributeCount;
            public IntPtr Attributes;
            public IntPtr TargetAlias;
            public IntPtr UserName;

            internal static NativeCredential GetNativeCredential(Credential cred)
            {
                NativeCredential ncred = new NativeCredential();
                ncred.AttributeCount = 0;
                ncred.Attributes = IntPtr.Zero;
                ncred.Comment = IntPtr.Zero;
                ncred.TargetAlias = IntPtr.Zero;
                ncred.Type = CRED_TYPE.GENERIC;
                ncred.Persist = (UInt32)1;
                ncred.CredentialBlobSize = (UInt32)cred.CredentialBlobSize;
                ncred.TargetName = Marshal.StringToCoTaskMemUni(cred.TargetName);
                ncred.CredentialBlob = Marshal.StringToCoTaskMemUni(cred.CredentialBlob);
                ncred.UserName = Marshal.StringToCoTaskMemUni(Environment.UserName);
                return ncred;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct Credential
        {
            public UInt32 Flags;
            public CRED_TYPE Type;
            public string TargetName;
            public string Comment;
            public FILETIME LastWritten;
            public UInt32 CredentialBlobSize;
            public string CredentialBlob;
            public UInt32 Persist;
            public UInt32 AttributeCount;
            public IntPtr Attributes;
            public string TargetAlias;
            public string UserName;
        }

        public enum CRED_PERSIST : uint
        {
            CRED_PERSIST_SESSION = 1,
            CRED_PERSIST_LOCAL_MACHINE = 2,

            CRED_PERSIST_ENTERPRISE = 3
        }
        public enum CRED_TYPE : uint
        {
            GENERIC = 1,
            DOMAIN_PASSWORD = 2,
            DOMAIN_CERTIFICATE = 3,
            DOMAIN_VISIBLE_PASSWORD = 4,
            GENERIC_CERTIFICATE = 5,
            DOMAIN_EXTENDED = 6,
            MAXIMUM = 7,      // Maximum supported cred type
            MAXIMUM_EX = (MAXIMUM + 1000),  // Allow new applications to run on old OSes
        }

        public class CriticalCredentialHandle : CriticalHandleZeroOrMinusOneIsInvalid
        {
            public CriticalCredentialHandle(IntPtr preexistingHandle)
            {
                SetHandle(preexistingHandle);
            }

            public Credential GetCredential()
            {
                if (!IsInvalid)
                {
                    NativeCredential ncred = (NativeCredential)Marshal.PtrToStructure(handle,
                          typeof(NativeCredential));
                    Credential cred = new Credential();
                    cred.CredentialBlobSize = ncred.CredentialBlobSize;
                    cred.CredentialBlob = Marshal.PtrToStringUni(ncred.CredentialBlob,
                          (int)ncred.CredentialBlobSize / 2);
                    cred.UserName = Marshal.PtrToStringUni(ncred.UserName);
                    cred.TargetName = Marshal.PtrToStringUni(ncred.TargetName);
                    cred.TargetAlias = Marshal.PtrToStringUni(ncred.TargetAlias);
                    cred.Type = ncred.Type;
                    cred.Flags = ncred.Flags;
                    cred.Persist = ncred.Persist;
                    return cred;
                }
                else
                {
                    throw new InvalidOperationException("Invalid CriticalHandle!");
                }
            }

            override protected bool ReleaseHandle()
            {
                if (!IsInvalid)
                {
                    CredFree(handle);
                    SetHandleAsInvalid();
                    return true;
                }
                return false;
            }
        }

        private static string SecureStringToString(SecureString value)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        [DllImport("Advapi32.dll", SetLastError = true, EntryPoint = "CredWriteW", CharSet = CharSet.Unicode)]
        public static extern bool CredWrite([In] ref NativeCredential userCredential, [In] UInt32 flags);

        [DllImport("Advapi32.dll", EntryPoint = "CredReadW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CredRead(string target, CRED_TYPE type, int reservedFlag, out IntPtr CredentialPtr);

        [DllImport("Advapi32.dll", EntryPoint = "CredFree", SetLastError = true)]
        public static extern bool CredFree([In] IntPtr cred);
    }
}
