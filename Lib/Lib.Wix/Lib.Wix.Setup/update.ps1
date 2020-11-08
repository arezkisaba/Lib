# FOR TESTING : msbuild /p:RunWixToolsOutOfProc=true /p:ProductName="BabylonTools.MediaManager.NetCore" /p:ProductVersion="1.0.0.0" /p:UpgradeCode="db71bd75-c571-4155-a1ac-bd6d13680710" /p:HandleStartup="True"

$basePath = $PsScriptRoot
$artifactFolderName = "Artifacts"

#PRODUCT.WXS

$wxsTemplatePath = "$basePath\Templates\Components.wxs"
$wxsPath = "$basePath\Components.wxs"
$artifactFiles = Get-ChildItem -Recurse "$basePath\$artifactFolderName"
$xml = ""

foreach ($artifactFile in $artifactFiles) {
	if (!$artifactFile.PSIsContainer) {
		$relativePath = $artifactFile.FullName.Replace("$basePath\", "")
		$pattern = '[^a-zA-Z\._0-9]'
		$fileId = $relativePath.Replace($basePath, '').Replace('\', '_') -replace $pattern,''
		$componentId = -join ((65..90) + (97..122) | Get-Random -Count 15 | % {[char]$_})
		$row = "`t`t`t<Component Id=`"$fileId`" Guid=`"$([guid]::NewGuid().ToString())`">`r`n`t`t`t`t<File Id=`"$fileId`" Name=`"$($artifactFile.Name)`" Source=`"`$(var.ProjectDir)$relativePath`"/>`r`n`t`t`t</Component>`r`n"
		$xml += "$row`n"
	}
}

$content = (Get-Content $wxsTemplatePath)
$content = $content -replace "##TOREPLACE##", $xml
Set-Content $wxsPath $content

# LICENCE

$licenceTemplatePath = "$basePath\Templates\LICENCE.rtf"
$licencePath = "$basePath\$artifactFolderName\LICENCE.rtf"
$exe = Get-ChildItem -Path "$basePath\$artifactFolderName" -Filter *.exe 
$productName = [io.path]::GetFileNameWithoutExtension($exe[0].FullName)

$content = (Get-Content $licenceTemplatePath)
$content = $content -replace "##ProductName##", $productName
Set-Content $licencePath $content
