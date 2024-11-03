@echo off

REM Start XAMPP MySQL
echo Starting XAMPP MySQL server...
start "" "C:\xampp\xampp_start.exe"
timeout /t 5 /nobreak > nul  REM Wait for 5 seconds to allow MySQL to start

REM Start the ASP.NET Web API in a minimized window and detach it
echo Starting ASP.NET Web API...
start "" /B cmd /C "cd /d C:\Users\COIN\Desktop\Csharp projects\Student ELection\Student Election Management System\Backend\API\StudentElectionAPI\StudentElectionAPI && dotnet run > nul 2>&1"

REM Start the frontend in a minimized window and detach it
echo Starting frontend...
start "" /B cmd /C "cd /d C:\Users\COIN\Desktop\Csharp projects\Student ELection\Student Election Management System\Frontend && npm run dev > nul 2>&1"

REM Open Chrome with the specified URL
echo Opening browser...
start chrome "http://localhost:5173/"

echo cls

echo All services started!
pause
