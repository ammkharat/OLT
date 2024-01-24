@echo off
color
cls
color 2F
IF "%1" == "" goto BuildNoArgs
IF NOT "%2" == "" goto BuildTwoArgs
IF NOT "%1" == "" goto BuildOneArg

:CheckErrors
IF ERRORLEVEL 1 goto RedBuild
IF ERRORLEVEL 0 goto GreenBuild

:BuildNoArgs
msbuild olt.msbuild /m:4 /p:BuildInParallel=true 
goto CheckErrors

:BuildTwoArgs
msbuild olt.msbuild /m:4 /p:BuildInParallel=true /t:%1 /t:%2 
goto CheckErrors

:BuildOneArg
msbuild olt.msbuild /m:4 /p:BuildInParallel=true /t:%1 
goto CheckErrors
:RedBuild
color 4F
goto TheEnd

:GreenBuild
color 2F

:TheEnd
echo Build Finished at: %date% - %time%
pause

color
