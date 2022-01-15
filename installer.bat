@echo off
cd C:\Rhodum\Client\2013

IF EXIST C:\Rhodum\Client\2013 del /Q C:\Rhodum
if not exist C:\Rhodum\Client\2013 md C:\Rhodum\Client\
cls
@echo Rhodum is installing....
@echo --------------------------------------------
@echo Downloading, this may take a while depending on your internet speed...
@echo --------------------------------------------
cd C:\Rhodum\Client\
powershell -Command "(New-Object Net.WebClient).DownloadFile('http://rhodum.xyz/Client/20/2013.zip', 'package.zip')"
powershell -Command "Invoke-WebRequest http://rhodum.xyz/Client/20/2013.zip -OutFile package.zip"
cls
@echo Rhodum is installing....
@echo --------------------------------------------
@echo uzipping file...
@echo --------------------------------------------
setlocal
cd /d %~dp0
Call :UnZipFile "C:\Rhodum\Client\" "C:\Rhodum\Client\package.zip"
exit /b

:UnZipFile <ExtractTo> <newzipfile>
set vbs="%temp%\_.vbs"
if exist %vbs% del /f /q %vbs%
>%vbs%  echo Set fso = CreateObject("Scripting.FileSystemObject")
>>%vbs% echo If NOT fso.FolderExists(%1) Then
>>%vbs% echo fso.CreateFolder(%1)
>>%vbs% echo End If
>>%vbs% echo set objShell = CreateObject("Shell.Application")
>>%vbs% echo set FilesInZip=objShell.NameSpace(%2).items
>>%vbs% echo objShell.NameSpace(%1).CopyHere(FilesInZip)
>>%vbs% echo Set fso = Nothing
>>%vbs% echo Set objShell = Nothing
cscript //nologo %vbs%
if exist %vbs% del /f /q %vbs%
cls
@echo Rhodum is installing....
@echo --------------------------------------------
@echo Cleaning up...
@echo --------------------------------------------
del "C:\Rhodum\Client\package.zip" /s /f /q
cls
@echo Rhodum is installing....
@echo --------------------------------------------
@echo Downloading Launcher...
@echo --------------------------------------------
cd %UserProfile%\Desktop
powershell -Command "(New-Object Net.WebClient).DownloadFile('http://rhodum.xyz/Client/Launcher.zip', 'package.zip')"
powershell -Command "Invoke-WebRequest http://rhodum.xyz/Client/Launcher.zip -OutFile package.zip"
cls
@echo Rhodum is installing....
@echo --------------------------------------------
@echo unzipping Launcher...
@echo --------------------------------------------
setlocal
cd /d %~dp0
Call :UnZipFile "%UserProfile%\Desktop" "%UserProfile%\Desktop\package.zip"
exit /b

:UnZipFile <ExtractTo> <newzipfile>
set vbs="%temp%\_.vbs"
if exist %vbs% del /f /q %vbs%
>%vbs%  echo Set fso = CreateObject("Scripting.FileSystemObject")
>>%vbs% echo If NOT fso.FolderExists(%1) Then
>>%vbs% echo fso.CreateFolder(%1)
>>%vbs% echo End If
>>%vbs% echo set objShell = CreateObject("Shell.Application")
>>%vbs% echo set FilesInZip=objShell.NameSpace(%2).items
>>%vbs% echo objShell.NameSpace(%1).CopyHere(FilesInZip)
>>%vbs% echo Set fso = Nothing
>>%vbs% echo Set objShell = Nothing
cscript //nologo %vbs%
if exist %vbs% del /f /q %vbs%
cls
@echo Rhodum is installing....
@echo --------------------------------------------
@echo Cleaning up...
@echo --------------------------------------------
del "%UserProfile%\Desktop\package.zip" /s /f /q
cls
@echo Thank you for installing Rhodum!
pause

