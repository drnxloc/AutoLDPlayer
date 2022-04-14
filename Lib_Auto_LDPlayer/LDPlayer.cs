using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using KAutoHelper;

namespace Auto_LDPlayer
{
    public class LdPlayer
    {
        public static string PathLd = @"C:\LDPlayer\LDPlayer4.0\ldconsole.exe";

        //----------------------Tương Tác Tab Giả Lập--------------------------------//

        //Nhóm 1 - Thao Tác

        public static void Open(string param, string nameOrId)
        {
            ExecuteLd($"launch --{param} {nameOrId}");
        }

        public static void Open_App(string param, string nameOrId, string packageName)
        {
            ExecuteLd($"launchex --{param} {nameOrId} --packagename {packageName}");
        }

        public static void Close(string param, string nameOrId)
        {
            ExecuteLd($"quit --{param} {nameOrId}");
        }

        public static void CloseAll()
        {
            ExecuteLd("quitall");
        }

        public static void ReBoot(string param, string nameOrId)
        {
            ExecuteLd($"reboot --{param} {nameOrId}");
        }

        //Nhóm 2 - Tuỳ Chỉnh Thêm

        public static void Create(string name)
        {
            ExecuteLd("add --name " + name);
        }

        public static void Copy(string name, string fromNameOrId)
        {
            ExecuteLd($"copy --name {name} --from {fromNameOrId}");
        }

        public static void Delete(string param, string nameOrId)
        {
            ExecuteLd($"remove --{param} {nameOrId}");
        }

        public static void ReName(string param, string nameOrId, string titleNew)
        {
            ExecuteLd($"rename --{param} {nameOrId} --title {titleNew}");
        }

        //Nhóm 3 - Change Setting

        public static void InstallApp_File(string param, string nameOrId, string fileName)
        {
            ExecuteLd($@"installapp --{param} {nameOrId} --filename ""{fileName}""");
        }

        public static void InstallApp_Package(string param, string nameOrId, string packageName)
        {
            ExecuteLd($"installapp --{param} {nameOrId} --packagename {packageName}");
        }

        public static void UnInstallApp(string param, string nameOrId, string packageName)
        {
            ExecuteLd($"uninstallapp --{param} {nameOrId} --packagename {packageName}");
        }

        public static void RunApp(string param, string nameOrId, string packageName)
        {
            ExecuteLd($"runapp --{param} {nameOrId} --packagename {packageName}");
        }

        public static void KillApp(string param, string nameOrId, string packageName)
        {
            ExecuteLd($"killapp --{param} {nameOrId} --packagename {packageName}");
        }

        public static void Locate(string param, string nameOrId, string lng, string lat)
        {
            ExecuteLd($"locate --{param} {nameOrId} --LLI {lng},{lat}");
        }

        public static void Change_Property(string param, string nameOrId, string cmd)
        {
            ExecuteLd($"modify --{param} {nameOrId} {cmd}");
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

        public static void SetProp(string param, string nameOrId, string key, string value)
        {
            ExecuteLd($"setprop --{param} {nameOrId} --key {key} --value {value}");
        }

        public static string GetProp(string param, string nameOrId, string key)
        {
            return ExecuteLdForResult($"getprop --{param} {nameOrId} --key {key}");
        }

        public static string Adb(string param, string nameOrId, string cmd, int timeout = 10000, int retry = 1)
        {
            return ExecuteLdForResult($"adb --{param} \"{nameOrId}\" --command \"{cmd}\"", timeout,
                retry);
        }

        public static void DownCpu(string param, string nameOrId, string rate)
        {
            ExecuteLd($"downcpu --{param} {nameOrId} --rate {rate}");
        }

        public static void Backup(string param, string nameOrId, string filePath)
        {
            ExecuteLd($@"backup --{param} {nameOrId} --file ""{filePath}""");
        }

        public static void Restore(string param, string nameOrId, string filePath)
        {
            ExecuteLd($@"restore --{param} {nameOrId} --file ""{filePath}""");
        }

        public static void Action(string param, string nameOrId, string key, string value)
        {
            ExecuteLd($"action --{param} {nameOrId} --key {key} --value {value}");
        }

        public static void Scan(string param, string nameOrId, string filePath)
        {
            ExecuteLd($"scan --{param} {nameOrId} --file {filePath}");
        }

        public static void SortWnd()
        {
            ExecuteLd("sortWnd");
        }

        public static void ZoomIn(string param, string nameOrId)
        {
            ExecuteLd($"zoomIn --{param} {nameOrId}");
        }

        public static void ZoomOut(string param, string nameOrId)
        {
            ExecuteLd($"zoomOut --{param} {nameOrId}");
        }

        public static void Pull(string param, string nameOrId, string remoteFilePath, string localFilePath)
        {
            ExecuteLd($@"pull --{param} {nameOrId} --remote ""{remoteFilePath}"" --local ""{localFilePath}""");
        }

        public static void Push(string param, string nameOrId, string remoteFilePath, string localFilePath)
        {
            ExecuteLd($@"push --{param} {nameOrId} --remote ""{remoteFilePath}"" --local ""{localFilePath}""");
        }

        public static void BackupApp(string param, string nameOrId, string packageName, string filePath)
        {
            ExecuteLd($@"backupapp --{param} {nameOrId} --packagename {packageName} --file ""{filePath}""");
        }

        public static void RestoreApp(string param, string nameOrId, string packageName, string filePath)
        {
            ExecuteLd($@"restoreapp --{param} {nameOrId} --packagename {packageName} --file ""{filePath}""");
        }

        public static void GolabalConfig(string param, string nameOrId, string fps, string audio, string fastPlay,
            string cleanMode)
        {
            //  [--fps <0~60>] [--audio <1 | 0>] [--fastplay <1 | 0>] [--cleanmode <1 | 0>]
            ExecuteLd(
                $"globalsetting --{param} {nameOrId} --audio {audio} --fastplay {fastPlay} --cleanmode {cleanMode}");
        }

        public static List<string> GetDevices()
        {
            var arr = ExecuteLdForResult("list").Trim().Split('\n');
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "")
                    return new List<string>();
                arr[i] = arr[i].Trim();
            }

            //System.Windows.Forms.MessageBox.Show(string.Join("|", arr));
            return arr.ToList();
        }

        public static List<string> GetDevicesRunning()
        {
            var arr = ExecuteLdForResult("runninglist").Trim().Split('\n');
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "")
                    return new List<string>();
                arr[i] = arr[i].Trim();
            }

            //System.Windows.Forms.MessageBox.Show(string.Join("|", arr));
            return arr.ToList();
        }

        public static bool IsDeviceRunning(string param, string nameOrId)
        {
            var result = ExecuteLdForResult($"isrunning --{param} {nameOrId}").Trim();
            return result == "running";
        }

        public static List<LDevice> GetDevices2()
        {
            try
            {
                var listLdPlayer = new List<LDevice>();
                var arr = ExecuteLdForResult("list2").Trim().Split('\n');
                foreach (var i in arr)
                {
                    var devices = new LDevice();
                    var aDetail = i.Trim().Split(',');
                    devices.index = int.Parse(aDetail[0]);
                    devices.name = aDetail[1];
                    devices.topHandle = new IntPtr(Convert.ToInt32(aDetail[2], 16));
                    devices.bindHandle = new IntPtr(Convert.ToInt32(aDetail[3], 16));
                    devices.androidState = int.Parse(aDetail[4]);
                    devices.dnplayerPID = int.Parse(aDetail[5]);
                    devices.vboxPID = int.Parse(aDetail[6]);
                    listLdPlayer.Add(devices);
                }

                //System.Windows.Forms.MessageBox.Show(string.Join("\n", arr));
                return listLdPlayer;
            }
            catch
            {
                return new List<LDevice>();
            }
        }

        public static List<LDevice> GetDevices2Running()
        {
            try
            {
                var listLdPlayer = new List<LDevice>();
                var deviceRunning = GetDevicesRunning();
                var arr = ExecuteLdForResult("list2").Trim().Split('\n');
                foreach (var t in arr)
                {
                    var devices = new LDevice();
                    var aDetail = t.Trim().Split(',');
                    devices.index = int.Parse(aDetail[0]);
                    devices.name = aDetail[1];
                    devices.topHandle = new IntPtr(Convert.ToInt32(aDetail[2], 16));
                    devices.bindHandle = new IntPtr(Convert.ToInt32(aDetail[3], 16));
                    devices.androidState = int.Parse(aDetail[4]);
                    devices.dnplayerPID = int.Parse(aDetail[5]);
                    devices.vboxPID = int.Parse(aDetail[6]);
                    if (!deviceRunning.Contains(devices.name)) continue;
                    listLdPlayer.Add(devices);
                }

                return listLdPlayer;
            }
            catch
            {
                return new List<LDevice>();
            }
            //System.Windows.Forms.MessageBox.Show(string.Join("\n", arr));
        }

        public static void ExecuteLd(string cmd)
        {
            var p = new Process();
            p.StartInfo.FileName = PathLd;
            p.StartInfo.Arguments = cmd;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        public static string ExecuteLdForResult(string cmdCommand, int timeout = 10000, int retry = 2)
        {
            string result;
            try
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = PathLd,
                    Arguments = cmdCommand,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                // process.WaitForExit();

                while (retry >= 0)
                {
                    retry--;
                    process.Start();
                    if (!process.WaitForExit(timeout))
                    {
                        process.Kill();
                    }
                    else
                    {
                        break;
                    }
                }

                var text = process.StandardOutput.ReadToEnd();
                result = text;
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public static Point GetScreenResolution(string param, string nameOrId)
        {
            var str1 = Adb(param, nameOrId, "shell dumpsys display | grep \"mCurrentDisplayRect\"");
            var str2 = str1.Substring(str1.IndexOf("- ", StringComparison.Ordinal));
            var strArray = str2.Substring(str2.IndexOf(' '), str2.IndexOf(')') - str2.IndexOf(' ')).Split(',');
            return new Point(Convert.ToInt32(strArray[0].Trim()), Convert.ToInt32(strArray[1].Trim()));
        }

        public static void TapByPercent(string param, string nameOrId, double x, double y, int count = 1)
        {
            var screenResolution = GetScreenResolution(param, nameOrId);
            var num1 = (int) (x * (screenResolution.X * 1.0 / 100.0));
            var num2 = (int) (y * (screenResolution.Y * 1.0 / 100.0));
            Tap(param, nameOrId, num1, num2, count);
        }

        public static void Tap(string param, string nameOrId, int x, int y, int count = 1)
        {
            var cmdCommand = $"shell input tap {x} {y}";
            for (var index = 1; index < count; ++index)
                cmdCommand += (" && " + cmdCommand);
            Adb(param, nameOrId, cmdCommand, 200);
        }

        public static void PressKey(string param, string nameOrId, LdAdbKeyEvent key)
        {
            Adb(param, nameOrId, $"shell input keyevent {key}", 200);
        }

        public static void SwipeByPercent(string param, string nameOrId, double x1, double y1, double x2, double y2,
            int duration = 100)
        {
            var screenResolution = GetScreenResolution(param, nameOrId);
            var num1 = (int) (x1 * (screenResolution.X * 1.0 / 100.0));
            var num2 = (int) (y1 * (screenResolution.Y * 1.0 / 100.0));
            var num3 = (int) (x2 * (screenResolution.X * 1.0 / 100.0));
            var num4 = (int) (y2 * (screenResolution.Y * 1.0 / 100.0));
            Swipe(param, nameOrId, num1, num2, num3, num4, duration);
        }

        public static void Swipe(string param, string nameOrId, int x1, int y1, int x2, int y2, int duration = 100)
        {
            Adb(param, nameOrId, $"shell input swipe {x1} {y1} {x2} {y2} {duration}", 200);
        }


        public static void InputText(string param, string nameOrId, string text)
        {
            Adb(param, nameOrId,
                $"shell input text \"{text.Replace(" ", "%s").Replace("&", "\\&").Replace("<", "\\<").Replace(">", "\\>").Replace("?", "\\?").Replace(":", "\\:").Replace("{", "\\{").Replace("}", "\\}").Replace("[", "\\[").Replace("]", "\\]").Replace("|", "\\|")}\""
            );
        }

        public static void LongPress(string param, string nameOrId, int x, int y, int duration = 100)
        {
            Swipe(param, nameOrId, x, y, x, y, duration);
        }

        public static Bitmap ScreenShoot(string param, string nameOrId, bool isDeleteImageAfterCapture = true,
            string fileName = "screenShoot.png")
        {
            var str1 = param + "_" + nameOrId;


            var path = Path.GetFileNameWithoutExtension(fileName) + str1 + Path.GetExtension(fileName);
            if (File.Exists(path))
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                    // ignored
                }

            var filename = Directory.GetCurrentDirectory() + "\\" + path;
            var str2 = $"\"{Directory.GetCurrentDirectory().Replace("\\\\", "\\")}\"";
            var cmdCommand1 = $"shell screencap -p \"/sdcard/{path}\"";
            var cmdCommand2 = $"pull /sdcard/{path} {str2}";
            Adb(param, nameOrId, cmdCommand1);
            Adb(param, nameOrId, cmdCommand2);
            Bitmap bitmap = null;
            try
            {
                using (var original = new Bitmap(filename))
                {
                    bitmap = new Bitmap(original);
                }
            }
            catch
            {
                // ignored
            }

            if (!isDeleteImageAfterCapture) return bitmap;
            try
            {
                File.Delete(path);
            }
            catch
            {
                // ignored
            }

            try
            {
                Adb(param, nameOrId, $"shell \"rm /sdcard/{path}\"");
            }
            catch
            {
                // ignored
            }

            return bitmap;
        }

        public static void PlanModeOn(string param, string nameOrId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            Adb(param, nameOrId, " settings put global airplane_mode_on 1");
            Adb(param, nameOrId, "am broadcast -a android.intent.action.AIRPLANE_MODE");
        }

        public static void PlanModeOff(string param, string nameOrId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            Adb(param, nameOrId, " settings put global airplane_mode_on 1");
            Adb(param, nameOrId, "am broadcast -a android.intent.action.AIRPLANE_MODE");
        }

        public static void Delay(double delayTime)
        {
            for (var num = 0.0; num < delayTime; num += 100.0)
                Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
        }

        public static Point? FindImage(string param, string nameOrId, string imagePath, int count = 5)
        {
            var files = new DirectoryInfo(imagePath).GetFiles();
            do
            {
                Bitmap mainBitmap = null;
                var num = 3;
                do
                {
                    try
                    {
                        mainBitmap = ScreenShoot(param, nameOrId);
                        break;
                    }
                    catch (Exception)
                    {
                        --num;
                        Delay(1000.0);
                    }
                } while (num > 0);

                if (mainBitmap == null)
                    return new Point?();
                var image = new Point?();
                foreach (var fileSystemInfo in files)
                {
                    var subBitmap = (Bitmap) Image.FromFile(fileSystemInfo.FullName);
                    image = ImageScanOpenCV.FindOutPoint(mainBitmap, subBitmap);
                    if (image.HasValue)
                        break;
                }

                if (image.HasValue)
                    return image;
                Delay(2000.0);
                --count;
            } while (count > 0);

            return new Point?();
        }

        public static bool FindImageAndClick(string param, string nameOrId, string imagePath, int count = 5)
        {
            var point = FindImage(param, nameOrId, imagePath, count);
            if (!point.HasValue) return false;
            Tap(param, nameOrId, point.Value.X, point.Value.Y);
            return true;
        }


        // Điều Hướng
        public static void Back(string param, string nameOrId)
        {
            PressKey(param, nameOrId, LdAdbKeyEvent.KEYCODE_BACK);
        }

        public static void Home(string param, string nameOrId)
        {
            PressKey(param, nameOrId, LdAdbKeyEvent.KEYCODE_HOME);
        }

        public static void Menu(string param, string nameOrId)
        {
            PressKey(param, nameOrId, LdAdbKeyEvent.KEYCODE_APP_SWITCH);
        }


        //IMG OpenCV
        public static bool Tap_Img(string param, string nameOrId, Bitmap imgFind)
        {
            var bm = (Bitmap) imgFind.Clone();
            var screen = ScreenShoot(param, nameOrId);
            var point = ImageScanOpenCV.FindOutPoint(screen, bm);
            if (point == null) return false;
            Tap(param, nameOrId, point.Value.X, point.Value.Y);
            return true;

            //MessageBox.Show("Tìm không ra");
        }

        //Change Proxy
        public static void ChangeProxy(string param, string nameOrId, string ipProxy, string portProxy)
        {
            Adb(param, nameOrId, $"shell settings put global http_proxy {ipProxy}:{portProxy}");
        }

        public static void RemoveProxy(string param, string nameOrId)
        {
            Adb(param, nameOrId, "shell settings put global http_proxy :0");
        }
    }
}