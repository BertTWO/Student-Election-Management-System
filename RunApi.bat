@echo off

REM Start XAMPP MySQL
echo Starting XAMPP MySQL server...
"C:\xampp\xampp_start.exe" 

REM Wait a few seconds for MySQL to start (optional)
timeout /t 5 /nobreak >nul

REM Start the ASP.NET Web API
echo Starting ASP.NET Web API...
cd "C:\Users\COIN\Desktop\Csharp projects\Student ELection\Student Election Management System\Backend\API\StudentElectionAPI\StudentElectionAPI"
dotnet run

pause
