using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RunProgram
{
    class GetInstalledApps
    {
        public void GetInstalledAppPathAndRunProgram(string name)
        {

            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            string s = FindByDisplayName(regKey, name);
            MessageBox.Show(s);
            if (s != "")
                Process.Start(s);

        }

        public void GetInstalledAppPathAndRunProgram2(string name)
        {
            name = name.Trim();
            name = name.ToLower();
            name = name.Replace(" ", "");

            switch (name)
            {

                case "shareit":
                    if (Directory.Exists(@"C:\Program Files (x86)\Lenovo\SHAREit"))
                        Process.Start(@"C:\Program Files (x86)\Lenovo\SHAREit\Shareit.exe");
                    break;
                case "chrome":
                    if (Directory.Exists(@"C:\Program Files (x86)\Google\Chrome\Application"))
                        Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    break;

                case "adobereader":
                    if (Directory.Exists(@"C:\Program Files (x86)\Adobe\Reader 9.0\Reader"))
                        Process.Start(@"C:\Program Files (x86)\Adobe\Reader 9.0\Reader\AcroRd32.exe");
                    break;
                case "idm":
                    if (Directory.Exists(@"C:\Program Files (x86)\Internet Download Manager"))
                        Process.Start(@"C:\Program Files (x86)\Internet Download Manager\IDMan.exe");
                    break;
                case "word":
                    if (Directory.Exists(@"C:\Program Files (x86)\Microsoft Office\Office15"))
                        Process.Start(@"C:\Program Files (x86)\Microsoft Office\Office15\WINWORD.exe");
                    break;
                case "excel":
                    if (Directory.Exists(@"C:\Program Files (x86)\Microsoft Office\Office15"))
                        Process.Start(@"C:\Program Files (x86)\Microsoft Office\Office15\EXCEL.exe");
                    break;
                case "powerpoint":
                    if (Directory.Exists(@"C:\Program Files (x86)\Microsoft Office\Office15"))
                        Process.Start(@"C:\Program Files (x86)\Microsoft Office\Office15\POWERPOINT.exe");
                    break;

                case "vlc":
                    if (Directory.Exists(@"C:\Program Files (x86)\VideoLAN\VLC"))
                        Process.Start(@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe");
                    break;
                case "mozilla":
                    if (Directory.Exists(@"C:\Program Files (x86)\Google\Chrome\Application"))
                        Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    break;

                case "torrent":
                    //Process.Start(@"C:\Program Files (x86)\Lenovo\SHAREit\Shareit.exe");
                    break;
                case "gom":
                    //Process.Start(@"C:\Program Files (x86)\Lenovo\SHAREit\Shareit.exe");
                    break;
                case "photoshop":
                    //Process.Start(@"C:\Program Files (x86)\Lenovo\SHAREit\Shareit.exe");
                    break;
                case "illustrator":
                    //Process.Start(@"C:\Program Files (x86)\Lenovo\SHAREit\Shareit.exe");
                    break;
                case "kmplayer":
                    if (Directory.Exists(@"C:\The KMPlayer"))
                        Process.Start(@"C:\The KMPlayer\KMPLayer.exe");
                    break;

                default:
                    break;
            }

        }
        public static string FindByDisplayName(RegistryKey parentKey, string name)
        {
            name = name.ToLower();
            string[] nameList = parentKey.GetSubKeyNames();
            for (int i = 0; i < nameList.Length; i++)
            {
                RegistryKey regKey = parentKey.OpenSubKey(nameList[i]);
                try
                {
                    if (regKey.GetValue("DisplayName").ToString().Contains(name))
                    {
                        return regKey.GetValue("InstallLocation").ToString();
                    }
                }
                catch { }
            }
            return "";
        }
    }
}
