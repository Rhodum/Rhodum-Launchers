@echo off
cd C:\Rhodum\Client\2013\
@echo Rhodum Hosting Service, port is 49167
@echo NOTICE: You can only host 1 game at a time.
@echo THIS IS AN BETA VERSION, THIS IS UNSTABLE.
set /p username="Enter username: "
set /p token="Enter connection token: "
set /p gname="Enter game name: "
set /p gpic="Enter game thumbnail picture url: "
set /p network="Enter Radmin network name: "
set /p netpass="Enter Radmin network password: "
set /p radip="Enter Radmin ip adress: "
set /p gmap="Drag your map file here: "
powershell -Command "(New-Object Net.WebClient).DownloadFile('http://rhodum.xyz/2013/hostgame1.php?username=%username%&token=%token%&gname=%gname%&gpic=%gpic%&nwork=%network%&npass=%netpass%&radip=%radip%', '1.txt')"
set /p response=<1.txt
if "%response%"=="true" (
	cls
	echo " Execute this script in the studio command bar: dofile("http://rhodum.xyz/2013/20/server.lua")                                                                                       "
	pause
	Server.exe %gmap%
) else (
	@echo The connection token was incorrect. Please try again.
	pause
	)


