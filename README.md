# AutoLDPlayer
Auto ADB LDPlayer v1.0.0
Release Bao Gồm
- KAutoHelpper
- Emgu.CV.World.dll
- Auto_LDPlayer.dll

# Nuget
### Nuget: `https://www.nuget.org/packages/Auto_LDPlayer/`
### Nếu sử dụng cần cài thêm: KAutoHelpper Và Emgu.CV.World.dll

# List Command
```js
0. Note:
    param => name, index. NameOrId => "Name LDPlayer Or Index LDPlayer"
```

1. Set Path LDPlayer
```js
    LDPlayer.pathLD = "Your Path LD";
```

2. Manipulation Emulator
```js
    void Open(string param, string NameOrId)
    void Open_App(string param, string NameOrId, string Package_Name)
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
void InstallApp_File(string param, string NameOrId, string File_Name)
void InstallApp_Package(string param, string NameOrId, string Package_Name)
void UnInstallApp(string param, string NameOrId, string Package_Name)
void RunApp(string param, string NameOrId, string Package_Name)
void KillApp(string param, string NameOrId, string Package_Name)
void Locate(string param, string NameOrId, string Lng, string Lat)
void Change_Property(string param, string NameOrId, string cmd)
```js
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
```
```