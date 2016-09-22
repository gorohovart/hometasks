ildasm.exe task.exe /output:ILCode.il
powershell -Command "(gc ILCode.il) -replace ' 2B ', ' 2D ' | Out-File ILCode.il" 
powershell -Command "(gc ILCode.il) -replace ' add', ' sub' | Out-File ILCode.il" 
