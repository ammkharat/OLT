@echo off
color
cls

IF "%1" == "" msbuild.exe olt.msbuild /m:2 /p:BuildInParallel=true
IF NOT "%1" == "" msbuild olt.msbuild /m:2 /p:BuildInParallel=true /t:%1

IF ERRORLEVEL 1 goto RedBuild
IF ERRORLEVEL 0 goto GreenBuild

:RedBuild
color 4F
goto TheEnd

:GreenBuild
color 2F

:TheEnd
pause

color
