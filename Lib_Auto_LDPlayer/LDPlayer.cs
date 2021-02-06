using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KAutoHelper;

namespace Auto_LDPlayer
{
    public class LDPlayer
    {
        public static string pathLD = @"C:\LDPlayer\LDPlayer4.0\ldconsole.exe";
        //----------------------Tương Tác Tab Giả Lập--------------------------------//

        //Nhóm 1 - Thao Tác

        public void Open(string param, string NameOrId)
        {
            ExecuteLD(string.Format("launch --{0} {1}", param, NameOrId));
        }

        public void Open_App(string param, string NameOrId, string Package_Name)
        {
            ExecuteLD(string.Format("launchex --{0} {1} --packagename {2}", param, NameOrId, Package_Name));
        }

        public void Close(string param, string NameOrId)
        {
            ExecuteLD(string.Format("quit --{0} {1}", param, NameOrId));
        }

        public void CloseAll()
        {
            ExecuteLD("quitall");
        }

        public void ReBoot(string param, string NameOrId)
        {
            ExecuteLD(string.Format("reboot --{0} {1}", param, NameOrId));
        }

        //Nhóm 2 - Tuỳ Chỉnh Thêm

        public void Create(string Name)
        {
            ExecuteLD("add --name " + Name);
        }

        public void Copy(string Name, string From_NameOrId)
        {
            ExecuteLD(string.Format("copy --name {0} --from {1}", Name, From_NameOrId));
        }

        public void Delete(string param, string NameOrId)
        {
            ExecuteLD(string.Format("remove --{0} {1}", param, NameOrId));
        }

        public void ReName(string param, string NameOrId, string title_new)
        {
            ExecuteLD(string.Format("rename --{0} {1} --title {2}", param, NameOrId, title_new));
        }

        //Nhóm 3 - Change Setting

        public void InstallApp_File(string param, string NameOrId, string File_Name)
        {
            ExecuteLD(string.Format(@"installapp --{0} {1} --filename ""{2}""", param, NameOrId, File_Name));
        }

        public void InstallApp_Package(string param, string NameOrId, string Package_Name)
        {
            ExecuteLD(string.Format("installapp --{0} {1} --packagename {2}", param, NameOrId, Package_Name));
        }

        public void UnInstallApp(string param, string NameOrId, string Package_Name)
        {
            ExecuteLD(string.Format("uninstallapp --{0} {1} --packagename {2}", param, NameOrId, Package_Name));
        }

        public void RunApp(string param, string NameOrId, string Package_Name)
        {
            ExecuteLD(string.Format("runapp --{0} {1} --packagename {2}", param, NameOrId, Package_Name));
        }

        public void KillApp(string param, string NameOrId, string Package_Name)
        {
            ExecuteLD(string.Format("killapp --{0} {1} --packagename {2}", param, NameOrId, Package_Name));
        }

        public void Locate(string param, string NameOrId, string Lng, string Lat)
        {
            ExecuteLD(string.Format("locate --{0} {1} --LLI {2},{3}", param, NameOrId, Lng, Lat));
        }

        public void Change_Property(string param, string NameOrId, string cmd)
        {
            ExecuteLD(string.Format("modify --{0} {1} {2}", param, NameOrId, cmd));
            //[--resolution ]
            //[--cpu < 1 | 2 | 3 | 4 >]
            //[--memory < 512 | 1024 | 2048 | 4096 | 8192 >]
            //[--manufacturer asus]
            //[--model ASUS_Z00DUO]
            //[--pnumber 13812345678]
            //[--imei ]
            //[--imsi ]    
            //[--simserial ]
            //[--androidid ]
            //[--mac ]
            //[--autorotate < 1 | 0 >]
            //[--lockwindow < 1 | 0 >]
        }

        public void SetProp(string param, string NameOrId, string key, string value)
        {
            ExecuteLD(string.Format("setprop --{0} {1} --key {2} --value {3}", param, NameOrId, key, value));
        }

        public string GetProp(string param, string NameOrId, string key)
        {
            return ExecuteLD_Result(string.Format("getprop --{0} {1} --key {2}", param, NameOrId, key));
        }

        public string ADB(string param, string NameOrId, string cmd)
        {
            return ExecuteLD_Result(string.Format("adb --{0} {1} --command {2}", param, NameOrId, cmd));
        }

        public void DownCPU(string param, string NameOrId, string rate)
        {
            ExecuteLD(string.Format("downcpu --{0} {1} --rate {2}", param, NameOrId, rate));
        }

        public void Backup(string param, string NameOrId, string file_path)
        {
            ExecuteLD(string.Format(@"backup --{0} {1} --file ""{2}""", param, NameOrId, file_path));
        }

        public void Restore(string param, string NameOrId, string file_path)
        {
            ExecuteLD(string.Format(@"restore --{0} {1} --file ""{2}""", param, NameOrId, file_path));
        }

        public void Action(string param, string NameOrId, string key, string value)
        {
            ExecuteLD(string.Format("action --{0} {1} --key {2} --value {3}", param, NameOrId, key, value));
        }

        public void Scan(string param, string NameOrId, string file_path)
        {
            ExecuteLD(string.Format("scan --{0} {1} --file {2}", param, NameOrId, file_path));
        }

        public void SortWnd()
        {
            ExecuteLD("sortWnd");
        }

        public void zoomIn(string param, string NameOrId)
        {
            ExecuteLD(string.Format("zoomIn --{0} {1}", param, NameOrId));
        }

        public void zoomOut(string param, string NameOrId)
        {
            ExecuteLD(string.Format("zoomOut --{0} {1}", param, NameOrId));
        }

        public void Pull(string param, string NameOrId, string remote_file_path, string local_file_path)
        {
            ExecuteLD(string.Format(@"pull --{0} {1} --remote ""{2}"" --local ""{3}""", param, NameOrId, remote_file_path, local_file_path));
        }

        public void Push(string param, string NameOrId, string remote_file_path, string local_file_path)
        {
            ExecuteLD(string.Format(@"push --{0} {1} --remote ""{2}"" --local ""{3}""", param, NameOrId, remote_file_path, local_file_path));
        }

        public void BackupApp(string param, string NameOrId, string Package_Name, string file_path)
        {
            ExecuteLD(string.Format(@"backupapp --{0} {1} --packagename {2} --file ""{3}""", param, NameOrId, Package_Name, file_path));
        }

        public void RestoreApp(string param, string NameOrId, string Package_Name, string file_path)
        {
            ExecuteLD(string.Format(@"restoreapp --{0} {1} --packagename {2} --file ""{3}""", param, NameOrId, Package_Name, file_path));
        }

        public void Golabal_Config(string param, string NameOrId, string fps, string audio, string fast_play, string clean_mode)
        {
            //  [--fps <0~60>] [--audio <1 | 0>] [--fastplay <1 | 0>] [--cleanmode <1 | 0>]
            ExecuteLD(string.Format("globalsetting --{0} {1} --audio {2} --fastplay {3} --cleanmode {4}", param, NameOrId, audio, fast_play, clean_mode));
        }

        public List<string> GetDevices()
        {
            string[] arr = ExecuteLD_Result("list").Trim().Split('\n');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "")
                    return new List<string>();
                arr[i] = arr[i].Trim();
            }
            //System.Windows.Forms.MessageBox.Show(string.Join("|", arr));
            return arr.ToList<string>();
        }

        public List<string> GetDevices_Running()
        {
            string[] arr = ExecuteLD_Result("runninglist").Trim().Split('\n');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "")
                    return new List<string>();
                arr[i] = arr[i].Trim();
            }
            //System.Windows.Forms.MessageBox.Show(string.Join("|", arr));
            return arr.ToList<string>();
        }

        public bool IsDevice_Running(string param, string NameOrId)
        {
            string result = ExecuteLD_Result(string.Format("isrunning --{0} {1}", param, NameOrId)).Trim();
            if (result == "running")
                return true;
            return false;
        }

        public List<Info_Devices> GetDevices2()
        {
            try
            { 
                List<Info_Devices> listLDPlayer = new List<Info_Devices>();
                string[] arr = ExecuteLD_Result("list2").Trim().Split('\n');
                for (int i = 0; i < arr.Length; i++)
                {
                    Info_Devices devices = new Info_Devices();
                    string[] aDetail = arr[i].Trim().Split(',');
                    devices.index = int.Parse(aDetail[0]);
                    devices.name = aDetail[1];
                    devices.adb_id = "-1";
                    listLDPlayer.Add(devices);
                }
                //System.Windows.Forms.MessageBox.Show(string.Join("\n", arr));
                return listLDPlayer;
            }
            catch
            {
                return new List<Info_Devices>();
            }
}

        public List<Info_Devices> GetDevices2_Running()
        {
            try
            {
                int j = 0;
                List<string> list_adb_id = ADBHelper.GetDevices();
                List<Info_Devices> listLDPlayer = new List<Info_Devices>();
                List<string> device_running = GetDevices_Running();
                string[] arr = ExecuteLD_Result("list2").Trim().Split('\n');
                for (int i = 0; i < arr.Length; i++)
                {
                    Info_Devices devices = new Info_Devices();
                    string[] aDetail = arr[i].Trim().Split(',');
                    devices.index = int.Parse(aDetail[0]);
                    devices.name = aDetail[1];
                    if (device_running.Contains(devices.name))
                    {
                        devices.adb_id = list_adb_id[j];
                        listLDPlayer.Add(devices);
                        j++;
                    }
                }
                return listLDPlayer;
            }
            catch
            {
                return new List<Info_Devices>();
            }
            //System.Windows.Forms.MessageBox.Show(string.Join("\n", arr));
        }

        public void ExecuteLD(string cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = pathLD;
            p.StartInfo.Arguments = cmd;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        public string ExecuteLD_Result(string cmdCommand)
        {
            string result;
            try
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = pathLD,
                    Arguments = cmdCommand,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                process.WaitForExit();
                string text = process.StandardOutput.ReadToEnd();
                result = text;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        // Điều Hướng
        public void Back(string deviceID)
        {
            ADBHelper.Key(deviceID, ADBKeyEvent.KEYCODE_BACK);
        }

        public void Home(string deviceID)
        {
            ADBHelper.Key(deviceID, ADBKeyEvent.KEYCODE_HOME);
        }

        public void Menu(string deviceID)
        {
            ADBHelper.Key(deviceID, ADBKeyEvent.KEYCODE_APP_SWITCH);
        }

        //IMG OpenCV
        public void Tap_Img(string deviceID, Bitmap ImgFind)
        {
            Bitmap bm = (Bitmap)ImgFind.Clone();
            var screen = ADBHelper.ScreenShoot(deviceID);
            var Point = ImageScanOpenCV.FindOutPoint(screen, bm);
            if (Point != null)
            {
                ADBHelper.Tap(deviceID, Point.Value.X, Point.Value.Y);
                return;
            }
            //MessageBox.Show("Tìm không ra");
        }

        //Change Proxy
        public void Change_Proxy(string deviceID, string ip_proxy, string port_proxy)
        {
            ADBHelper.ExecuteCMD(string.Format("adb -s {0} shell settings put global http_proxy {1}:{2}", deviceID, ip_proxy, port_proxy));
        }

        public void Remove_Proxy(string deviceID)
        {
            ADBHelper.ExecuteCMD(string.Format("adb -s {0} shell settings put global http_proxy :0", deviceID));
        }
    }
}
