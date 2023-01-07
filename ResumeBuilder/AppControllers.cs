using Microsoft.Win32;
using System.Diagnostics;

namespace ResumeBuilder
{
    internal class AppControllers
    {
        public static int savingOption { get; set; }
        public static int languageOption { get; set; }
        public void OpenURL(string url)
        {
            string key = @"htmlfile\shell\open\command";
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = url;
            p.Start();
        }
    }
}
