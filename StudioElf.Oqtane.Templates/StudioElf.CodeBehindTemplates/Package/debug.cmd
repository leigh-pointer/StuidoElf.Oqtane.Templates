XCOPY "..\Client\bin\Debug\net8.0\StudioElf.CodeBehindTemplates.Client.Oqtane.dll" "..\..\..\..\..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\bin\Debug\net8.0\StudioElf.CodeBehindTemplates.Client.Oqtane.pdb" "..\..\..\..\..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I