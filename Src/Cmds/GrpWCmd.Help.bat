@ECHO OFF
ECHO.
ECHO.
ECHO Writes and displays help file
ECHO.
ECHO.

REM --- Determine exe path --------------------------------------------

set RunName=NetGrepWin
set RunExe=%RunName%.exe

REM Use local exe 
set ExePath=.\
set Path2CmdFile=.\
if exist %ExePath%\%RunExe% goto :EndExePath

REM Use local exe one path to the rrot
set ExePath=..\
set Path2CmdFile=.\
if exist %ExePath%\%RunExe% goto :EndExePath

REM Use debug exe 
set ExePath=..\%RunName%\bin\Debug\
set Path2CmdFile=..\..\Cmds\
if exist %ExePath%\%RunExe% goto :EndExePath

REM Use release exe 
set ExePath=..\%RunName%\bin\Release\
set Path2CmdFile=..\..\..\Cmds\
if exist %ExePath%\%RunExe% goto :EndExePath

REM Use standard path
set ExePath=%WWM500EXE%
set Path2CmdFile=.\

:EndExePath
ECHO .
ECHO %ExePath%\%RunExe% "->>%Path2CmdFile%"
REM pause
ECHO ">>>"

REM --- Start Exe --------------------------------------------

ECHO ON
%ExePath%\%RunExe% /? /NoAutoExit /CloseAfterCommandsDone
@ECHO OFF

ECHO.
ECHO.
ECHO.
REM pause

