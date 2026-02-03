#define MyAppName "Zero-Sum Game Calculator by Arash Behnamfar"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Arash Behnamfar"
#define MyAppExeName "ZeroSumGameCalculator.exe"

; IMPORTANT: set this to your publish folder path
#define PublishDir "C:\Users\ASUS\Desktop\publish"

[Setup]
AppId={{B1A8E81A-5A90-4D4C-9D4C-4A2D57C0D8F1}}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename=Setup_{#MyAppName}_{#MyAppVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern

SetupIconFile="C:\Users\ASUS\Downloads\sword-clash\sword-clash.ico"

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked

[Files]
Source: "{#PublishDir}\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent
