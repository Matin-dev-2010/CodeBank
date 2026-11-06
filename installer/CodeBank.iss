#ifndef AppVersion
  #define AppVersion "0.1.0"
#endif

#define AppName "CodeBank"
#define AppPublisher "Matin-dev-2010"
#define AppExeName "CodeBank.exe"

[Setup]
AppId={{D12B35F1-9B9D-4D0C-8A26-7E7E24F2B6C1}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={localappdata}\Programs\CodeBank
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
OutputDir=..\artifacts\installer
OutputBaseFilename=CodeBank-Setup-{#AppVersion}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\CodeBank.exe
CloseApplications=yes
RestartApplications=no

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a desktop shortcut"; GroupDescription: "Additional shortcuts:"; Flags: unchecked

[Files]
Source: "..\CodeBank\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\CodeBank"; Filename: "{app}\CodeBank.exe"
Name: "{autodesktop}\CodeBank"; Filename: "{app}\CodeBank.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\CodeBank.exe"; Description: "Launch CodeBank"; Flags: postinstall nowait skipifsilent
