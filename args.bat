@echo off

set conncode=%1
set conncode=%conncode:"=%
set list=%conncode%
FOR /f "tokens=1-4 delims=:" %%a IN ("%list%") DO (
   set userid=%%a
   set gameid=%%b
   set userkey=%%c
)


cd %CD%
start Roblox.exe -script "wait(); dofile('someurl.net/somefile.php?arg1=%userid%&arg2=%gameid%&arg3=somekey&arg4=%userkey%')"
:: Yes, now open source
