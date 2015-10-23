@echo off
erase "%USERPROFILE%\Local Settings\Application Data\licensecb\data"
erase "%ALLUSERSPROFILE%\Application Data\licensecb\data"
erase "%APPDATA%\Local\licensecb\data"
reg delete HKEY_CURRENT_USER\Software\licensecb /f
echo:Trial cleared! You can now use crazybump for another month.
pause
start /c "%programfiles(x86)%\Crazybump" crazybump.exe
start /c "%programfiles%\Crazybump" crazybump.exe
:end