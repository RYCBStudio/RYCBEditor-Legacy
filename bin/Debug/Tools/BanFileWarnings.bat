@echo off
net session >nul 2>&1
if %errorlevel% neq 0 (
    PowerShell -Command "Start-Process '%~dpnx0' -Verb RunAs"
    exit /b
)
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Associations /v ModRiskFileTypes /t REG_SZ /d "IDE.exe;IDE-PatchApplyer.exe;BanFileWarnings.bat;Runner.exe;Compiler.exe" /f
