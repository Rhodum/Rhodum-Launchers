@echo off
cd C:\Rhodum\Client\2013
powershell -Command "(New-Object Net.WebClient).DownloadFile('http://rhodum.xyz/Client/version.txt', '2.txt')"
set /p response=<2.txt
if "%response%"=="2.0" (
   @echo Rhodum is up to date, enjoy!
   pause
) else (
    @echo Rhodum is not up to date, please install a new version.
	pause
)

