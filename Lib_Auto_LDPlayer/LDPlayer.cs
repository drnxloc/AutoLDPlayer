using Auto_LDPlayer.Enums;
using Auto_LDPlayer.Extensions;
using KAutoHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;

namespace Auto_LDPlayer
{
    public class LDPlayer
    {
        public static string PathLD = @"C:\LDPlayer\LDPlayer4.0\ldconsole.exe";

        //----------------------Emulator Interaction--------------------------------//

        //Group 1 - Control

        public static void Open(LDType ldType, string nameOrId)
        {
            ExecuteLD($"launch --{ldType.ToName()} {nameOrId}");
        }

        public static void OpenApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD($"launchex --{ldType.ToName()} {nameOrId} --packagename {packageName}");
        }

        public static void Close(LDType ldType, string nameOrId)
        {
            ExecuteLD($"quit --{ldType.ToName()} {nameOrId}");
        }

        public static void CloseAll()
        {
            ExecuteLD("quitall");
        }

        public static void ReBoot(LDType ldType, string nameOrId)
        {
            ExecuteLD($"reboot --{ldType.ToName()} {nameOrId}");
        }

        //Group 2 - More Custom

        public static void Create(string name)
        {
            ExecuteLD("add --name " + name);
        }

        public static void Copy(string name, string fromNameOrId)
        {
            ExecuteLD($"copy --name {name} --from {fromNameOrId}");
        }

        public static void Delete(LDType ldType, string nameOrId)
        {
            ExecuteLD($"remove --{ldType.ToName()} {nameOrId}");
        }

        public static void Rename(LDType ldType, string nameOrId, string titleNew)
        {
            ExecuteLD($"rename --{ldType.ToName()} {nameOrId} --title {titleNew}");
        }

        //Group 3 - Change Setting

        public static void InstallAppFile(LDType ldType, string nameOrId, string fileName)
        {
            ExecuteLD($@"installapp --{ldType.ToName()} {nameOrId} --filename ""{fileName}""");
        }

        public static void InstallAppPackage(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD($"installapp --{ldType.ToName()} {nameOrId} --packagename {packageName}");
        }

        public static void UninstallApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD($"uninstallapp --{ldType.ToName()} {nameOrId} --packagename {packageName}");
        }

        public static void RunApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD($"runapp --{ldType.ToName()} {nameOrId} --packagename {packageName}");
        }

        public static void KillApp(LDType ldType, string nameOrId, string packageName)
        {
            ExecuteLD($"killapp --{ldType.ToName()} {nameOrId} --packagename {packageName}");
        }

        public static void Locate(LDType ldType, string nameOrId, string lng, string lat)
        {
            ExecuteLD($"locate --{ldType.ToName()} {nameOrId} --LLI {lng},{lat}");
        }

        public static void ChangeProperty(LDType ldType, string nameOrId, string cmd)
        {
            ExecuteLD($"modify --{ldType.ToName()} {nameOrId} {cmd}");
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

        public static void SetProp(LDType ldType, string nameOrId, string key, string value)
        {
            ExecuteLD($"setprop --{ldType.ToName()} {nameOrId} --key {key} --value {value}");
        }

        public static string GetProp(LDType ldType, string nameOrId, string key)
        {
            return ExecuteLDForResult($"getprop --{ldType.ToName()} {nameOrId} --key {key}");
        }

        public static string Adb(LDType ldType, string nameOrId, string cmd, int timeout = 10000, int retry = 1)
        {
            return ExecuteLDForResult($"adb --{ldType.ToName()} \"{nameOrId}\" --command \"{cmd}\"", timeout,
                retry);
        }

        public static void DownCpu(LDType ldType, string nameOrId, string rate)
        {
            ExecuteLD($"downcpu --{ldType.ToName()} {nameOrId} --rate {rate}");
        }

        public static void Backup(LDType ldType, string nameOrId, string filePath)
        {
            ExecuteLD($@"backup --{ldType.ToName()} {nameOrId} --file ""{filePath}""");
        }

        public static void Restore(LDType ldType, string nameOrId, string filePath)
        {
            ExecuteLD($@"restore --{ldType.ToName()} {nameOrId} --file ""{filePath}""");
        }

        public static void Action(LDType ldType, string nameOrId, string key, string value)
        {
            ExecuteLD($"action --{ldType.ToName()} {nameOrId} --key {key} --value {value}");
        }

        public static void Scan(LDType ldType, string nameOrId, string filePath)
        {
            ExecuteLD($"scan --{ldType.ToName()} {nameOrId} --file {filePath}");
        }

        public static void SortWnd()
        {
            ExecuteLD("sortWnd");
        }

        public static void ZoomIn(LDType ldType, string nameOrId)
        {
            ExecuteLD($"zoomIn --{ldType.ToName()} {nameOrId}");
        }

        public static void ZoomOut(LDType ldType, string nameOrId)
        {
            ExecuteLD($"zoomOut --{ldType.ToName()} {nameOrId}");
        }

        public static void Pull(LDType ldType, string nameOrId, string remoteFilePath, string localFilePath)
        {
            ExecuteLD($@"pull --{ldType.ToName()} {nameOrId} --remote ""{remoteFilePath}"" --local ""{localFilePath}""");
        }

        public static void Push(LDType ldType, string nameOrId, string remoteFilePath, string localFilePath)
        {
            ExecuteLD($@"push --{ldType.ToName()} {nameOrId} --remote ""{remoteFilePath}"" --local ""{localFilePath}""");
        }

        public static void BackupApp(LDType ldType, string nameOrId, string packageName, string filePath)
        {
            ExecuteLD($@"backupapp --{ldType.ToName()} {nameOrId} --packagename {packageName} --file ""{filePath}""");
        }

        public static void RestoreApp(LDType ldType, string nameOrId, string packageName, string filePath)
        {
            ExecuteLD($@"restoreapp --{ldType.ToName()} {nameOrId} --packagename {packageName} --file ""{filePath}""");
        }

        public static void GlobalConfig(LDType ldType, string nameOrId, string fps, string audio, string fastPlay,
            string cleanMode)
        {
            //  [--fps <0~60>] [--audio <1 | 0>] [--fastplay <1 | 0>] [--cleanmode <1 | 0>]
            ExecuteLD(
                $"globalsetting --{ldType.ToName()} {nameOrId} --audio {audio} --fastplay {fastPlay} --cleanmode {cleanMode}");
        }

        public static List<string> GetDevices()
        {
            var arr = ExecuteLDForResult("list").Trim().Split('\n');
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
            var arr = ExecuteLDForResult("runninglist").Trim().Split('\n');
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "")
                    return new List<string>();
                arr[i] = arr[i].Trim();
            }

            //System.Windows.Forms.MessageBox.Show(string.Join("|", arr));
            return arr.ToList();
        }

        public static bool IsDeviceRunning(LDType ldType, string nameOrId)
        {
            var result = ExecuteLDForResult($"isrunning --{ldType.ToName()} {nameOrId}").Trim();
            return result == "running";
        }

        public static List<LDevice> GetDevices2()
        {
            try
            {
                var listLDPlayer = new List<LDevice>();
                var arr = ExecuteLDForResult("list2").Trim().Split('\n');
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
                    listLDPlayer.Add(devices);
                }

                //System.Windows.Forms.MessageBox.Show(string.Join("\n", arr));
                return listLDPlayer;
            }
            catch
            {
                return null;
            }
        }

        public static List<LDevice> GetDevices2Running()
        {
            try
            {
                var listLDPlayer = new List<LDevice>();
                var deviceRunning = GetDevicesRunning();
                var arr = ExecuteLDForResult("list2").Trim().Split('\n');
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
                    listLDPlayer.Add(devices);
                }

                return listLDPlayer;
            }
            catch
            {
                return null;
            }
            //System.Windows.Forms.MessageBox.Show(string.Join("\n", arr));
        }

        public static void ExecuteLD(string cmd)
        {
            var p = new Process();
            p.StartInfo.FileName = PathLD;
            p.StartInfo.Arguments = cmd;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        public static string ExecuteLDForResult(string cmdCommand, int timeout = 10000, int retry = 2)
        {
            string result;
            try
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = PathLD,
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

        public static Point GetScreenResolution(LDType ldType, string nameOrId)
        {
            var str1 = Adb(ldType, nameOrId, "shell dumpsys display | grep \"mCurrentDisplayRect\"");
            var str2 = str1.Substring(str1.IndexOf("- ", StringComparison.Ordinal));
            var strArray = str2.Substring(str2.IndexOf(' '), str2.IndexOf(')') - str2.IndexOf(' ')).Split(',');
            return new Point(Convert.ToInt32(strArray[0].Trim()), Convert.ToInt32(strArray[1].Trim()));
        }

        public static void TapByPercent(LDType ldType, string nameOrId, double x, double y, int count = 1)
        {
            var screenResolution = GetScreenResolution(ldType, nameOrId);
            var num1 = (int) (x * (screenResolution.X * 1.0 / 100.0));
            var num2 = (int) (y * (screenResolution.Y * 1.0 / 100.0));
            Tap(ldType, nameOrId, num1, num2, count);
        }

        public static void Tap(LDType ldType, string nameOrId, int x, int y, int count = 1)
        {
            var cmdCommand = $"shell input tap {x} {y}";
            for (var index = 1; index < count; ++index)
                cmdCommand += (" && " + cmdCommand);
            Adb(ldType, nameOrId, cmdCommand, 200);
        }

        public static void PressKey(LDType ldType, string nameOrId, LDKeyEvent key)
        {
            Adb(ldType, nameOrId, $"shell input keyevent {key}", 200);
        }

        public static void SwipeByPercent(LDType ldType, string nameOrId, double x1, double y1, double x2, double y2,
            int duration = 100)
        {
            var screenResolution = GetScreenResolution(ldType, nameOrId);
            var num1 = (int) (x1 * (screenResolution.X * 1.0 / 100.0));
            var num2 = (int) (y1 * (screenResolution.Y * 1.0 / 100.0));
            var num3 = (int) (x2 * (screenResolution.X * 1.0 / 100.0));
            var num4 = (int) (y2 * (screenResolution.Y * 1.0 / 100.0));
            Swipe(ldType, nameOrId, num1, num2, num3, num4, duration);
        }

        public static void Swipe(LDType ldType, string nameOrId, int x1, int y1, int x2, int y2, int duration = 100)
        {
            Adb(ldType, nameOrId, $"shell input swipe {x1} {y1} {x2} {y2} {duration}", 200);
        }


        public static void InputText(LDType ldType, string nameOrId, string text)
        {
            Adb(ldType, nameOrId,
                $"shell input text \"{text.Replace(" ", "%s").Replace("&", "\\&").Replace("<", "\\<").Replace(">", "\\>").Replace("?", "\\?").Replace(":", "\\:").Replace("{", "\\{").Replace("}", "\\}").Replace("[", "\\[").Replace("]", "\\]").Replace("|", "\\|")}\""
            );
        }

        public static void LongPress(LDType ldType, string nameOrId, int x, int y, int duration = 100)
        {
            Swipe(ldType, nameOrId, x, y, x, y, duration);
        }

        public static Bitmap ScreenShoot(LDType ldType, string nameOrId, bool isDeleteImageAfterCapture = true,
            string fileName = "screenShoot.png")
        {
            var str1 = ldType + "_" + nameOrId;


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
            Adb(ldType, nameOrId, cmdCommand1);
            Adb(ldType, nameOrId, cmdCommand2);
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
                Adb(ldType, nameOrId, $"shell \"rm /sdcard/{path}\"");
            }
            catch
            {
                // ignored
            }

            return bitmap;
        }

        public static void PlanModeOn(LDType ldType, string nameOrId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            Adb(ldType, nameOrId, " settings put global airplane_mode_on 1");
            Adb(ldType, nameOrId, "am broadcast -a android.intent.action.AIRPLANE_MODE");
        }

        public static void PlanModeOff(LDType ldType, string nameOrId, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            Adb(ldType, nameOrId, " settings put global airplane_mode_on 1");
            Adb(ldType, nameOrId, "am broadcast -a android.intent.action.AIRPLANE_MODE");
        }

        public static void Delay(double delayTime)
        {
            for (var num = 0.0; num < delayTime; num += 100.0)
                Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
        }

        public static Point? FindImage(LDType ldType, string nameOrId, string imagePath, int count = 5)
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
                        mainBitmap = ScreenShoot(ldType, nameOrId);
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

        public static bool FindImageAndClick(LDType ldType, string nameOrId, string imagePath, int count = 5)
        {
            var point = FindImage(ldType, nameOrId, imagePath, count);
            if (!point.HasValue) return false;
            Tap(ldType, nameOrId, point.Value.X, point.Value.Y);
            return true;
        }


        // Navigation
        public static void Back(LDType ldType, string nameOrId)
        {
            PressKey(ldType, nameOrId, LDKeyEvent.KEYCODE_BACK);
        }

        public static void Home(LDType ldType, string nameOrId)
        {
            PressKey(ldType, nameOrId, LDKeyEvent.KEYCODE_HOME);
        }

        public static void Menu(LDType ldType, string nameOrId)
        {
            PressKey(ldType, nameOrId, LDKeyEvent.KEYCODE_APP_SWITCH);
        }


        //IMG OpenCV
        public static bool TapImg(LDType ldType, string nameOrId, Bitmap imgFind)
        {
            var bm = (Bitmap) imgFind.Clone();
            var screen = ScreenShoot(ldType, nameOrId);
            var point = ImageScanOpenCV.FindOutPoint(screen, bm);
            if (point == null) return false;
            Tap(ldType, nameOrId, point.Value.X, point.Value.Y);
            return true;

            //MessageBox.Show("Can't find it");
        }

        //Change Proxy
        public static void ChangeProxy(LDType ldType, string nameOrId, string ipProxy, string portProxy)
        {
            Adb(ldType, nameOrId, $"shell settings put global http_proxy {ipProxy}:{portProxy}");
        }

        public static void RemoveProxy(LDType ldType, string nameOrId)
        {
            Adb(ldType, nameOrId, "shell settings put global http_proxy :0");
        }
    }
}