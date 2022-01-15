@echo off
cd C:\Rhodum\Client\2013
if not exist "C:\Rhodum\Client\2013\updater.exe" exit
updater.exe
set /p username="Enter username: "
set /p token="Enter connection token: "
set /p gameid="Enter game id: "
powershell -Command "(New-Object Net.WebClient).DownloadFile('http://rhodum.xyz/game/link.php?username=%username%&token=%token%', '1.txt')"
set /p response=<1.txt
if "%response%"=="true" (
    del "C:\Rhodum\Client\2013\1.txt" /s /f /q
	cls
    Rhodum.exe -build -script "wait(); dofile('http://rhodum.xyz/2013/serverconverse.php?pname=%username%&id=%gameid%')"
) else (
	del "C:\Rhodum\Client\2013\1.txt" /s /f /q
    cls
    @echo The connection token was incorrect. Please try again.
    pause
)
