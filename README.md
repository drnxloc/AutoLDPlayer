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
0. param => name, index. NameOrId => "Name LDPlayer Or Index LDPlayer"
```

1. Set Path LDPlayer
```js
    LDPlayer.pathLD = "Your Path LD";
```

2. Manipulation Emulator
```js
    void Open(string param, string NameOrId)
```
```js
    Exam:   Open("name", "ld0");
            Open("index", "0");
```

```js
```