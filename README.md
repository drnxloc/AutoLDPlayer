# AutoLDPlayer
Auto ADB LDPlayer v1.0.0
Release Bao Gồm
- KAutoHelpper
- Emgu.CV.World.dll
- Auto_LDPlayer.dll

# Nuget
### Nuget: https://www.nuget.org/packages/Auto_LDPlayer
### Nếu sử dụng cần cài thêm: KAutoHelpper Và Emgu.CV.World.dll

# List Command
```js
Note:
    param => name, index. NameOrId => "Name LDPlayer Or Index LDPlayer"
    deviceID get form cmd "adb devices"
```

```js
0. Initialization
   LDPlayer ldplayer = new LDPlayer();
```

1. Set Path LDPlayer "ldconsole.exe"
```js
    LDPlayer.pathLD = "Your Path ldconsole.exe";
```

2. Manipulation Emulator
```js
    void Open(string param, string NameOrId)

    void Open_App(string param, string NameOrId, string Package_Name) //Mở LD cùng app khi chạy

    void Close(string param, string NameOrId)

    void CloseAll()

    void ReBoot(string param, string NameOrId)
```
```js
    Exam:   Open("name", "ld0");
            Open("index", "0");
```
3. Custom Emulator
```js
void Create(string Name)

void Copy(string Name)

void Delete(string param, string NameOrId)

void ReName(string param, string NameOrId, string title_new)
```

4. App 
```js
void InstallApp_File(string param, string NameOrId, string File_Name) //File_Name trỏ tới file apk

void InstallApp_Package(string param, string NameOrId, string Package_Name) //Cài qua LD Store, hơi dỏm, tốt nhất tự cài apk

void UnInstallApp(string param, string NameOrId, string Package_Name)

void RunApp(string param, string NameOrId, string Package_Name)

void KillApp(string param, string NameOrId, string Package_Name)
```

5. Orther
```js
void Locate(string param, string NameOrId, string Lng, string Lat) //Set Toạ Độ GPS
```

```js
void Change_Property(string param, string NameOrId, string cmd)
    cmd use: 
    [--resolution ]
    [--cpu < 1 | 2 | 3 | 4 >]
    [--memory < 512 | 1024 | 2048 | 4096 | 8192 >]
    [--manufacturer asus]
    [--model ASUS_Z00DUO]
    [--pnumber 13812345678]
    [--imei ]
    [--imsi ]    
    [--simserial ]
    [--androidid ]
    [--mac ]
    [--autorotate < 1 | 0 >]
    [--lockwindow < 1 | 0 >]

    Exam:   Change_Property("name", "ld0", " --cpu 1 --memory 1024 --imei 123456789");
```
```js
void SetProp(string param, string NameOrId, string key, string value)

string GetProp(string param, string NameOrId, string key)

string ADB(string param, string NameOrId, string cmd)

void DownCPU(string param, string NameOrId, string rate)

void Backup(string param, string NameOrId, string file_path)

void Restore(string param, string NameOrId, string file_path)

void Action(string param, string NameOrId, string key, string value)

void Scan(string param, string NameOrId, string file_path)

void SortWnd() //Sắp Xếp Tab Giả Lập

void zoomIn(string param, string NameOrId) //Phóng to

void zoomOut(string param, string NameOrId) //Phóng nhỏ lại

void Pull(string param, string NameOrId, string remote_file_path, string local_file_path)

void Push(string param, string NameOrId, string remote_file_path, string local_file_path)

void BackupApp(string param, string NameOrId, string Package_Name, string file_path)

void RestoreApp(string param, string NameOrId, string Package_Name, string file_path)
```
```js
void Golabal_Config(string param, string NameOrId, string fps, string audio, string fast_play, string clean_mode)
    [--fps <0~60>] [--audio <1 | 0>] [--fastplay <1 | 0>] [--cleanmode <1 | 0>]
    Exam: Golabal_Config("name", "ld0", "60", "0", "0", "0");
```
5. Get List Devices
```js
List<string> GetDevices()

List<string> GetDevices_Running()

bool IsDevice_Running(string param, string NameOrId)

List<Info_Devices> GetDevices2()

List<Info_Devices> GetDevices2_Running()
```

6. Cmd
```js
void ExecuteLD(string cmd)

string ExecuteLD_Result(string cmdCommand)
```

7. Directional
```js
void Back(string deviceID)

void Home(string deviceID)

void Menu(string deviceID)
```

8. Tap with OpenCV
```js
void Tap_Img(string deviceID, Bitmap ImgFind)
```