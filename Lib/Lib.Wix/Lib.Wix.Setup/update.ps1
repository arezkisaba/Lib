# FOR TESTING : msbuild /p:RunWixToolsOutOfProc=true /p:ProductName="BabylonTools.MediaManager.NetCore" /p:ProductVersion="1.0.0.0" /p:UpgradeCode="db71bd75-c571-4155-a1ac-bd6d13680710" /p:HandleStartup="True"

Function InternalGetItemsFromDirectory($Path, $DirectoryRefId, [ref]$XmlForDirectories, [ref]$XmlForFiles) {

	$items = Get-ChildItem "$path"
	foreach ($item in $items) {
		if (!$item.PSIsContainer) {
			$componentId = "cmp" + [guid]::NewGuid().ToString().Replace("-", "")
			$relativePath = (Resolve-Path -Relative $item.FullName).Replace("..\", "").Replace(".\", "")
			$fileId = $relativePath.Replace("-", "").Replace("\", "_")
			$XmlForFiles.Value += @"
			<Component Id="$componentId" Directory="$DirectoryRefId" Guid="*">
				<File Id="$fileId" KeyPath="yes" Source="`$(var.ProjectDir)$relativePath" />
			</Component>`n
"@
		} else {
			$directoryId = "dir" + [guid]::NewGuid().ToString().Replace("-", "")
			$XmlForDirectories.Value += @"
	<Fragment>
		<DirectoryRef Id="$DirectoryRefId">
			<Directory Id="$directoryId" Name="$($item.Name)" />
		</DirectoryRef>
	</Fragment>`n
"@
			InternalGetItemsFromDirectory -Path "$($item.FullName)" -DirectoryRefId "$($directoryId)" -XmlForDirectories $XmlForDirectories -XmlForFiles $XmlForFiles
		}
	}
}

$basePath = $PsScriptRoot
$artifactFolderName = "Artifacts"

#PRODUCT.WXS

$wxsTemplatePath = "$basePath\Templates\Components.wxs"
$wxsPath = "$basePath\Components.wxs"
$xmlForDirectories = ""
$xmlForFiles = ""

InternalGetItemsFromDirectory -Path "$basePath\$artifactFolderName" -DirectoryRefId "INSTALLFOLDER" -XmlForDirectories ([ref]$xmlForDirectories) -XmlForFiles ([ref]$xmlForFiles)

$content = (Get-Content $wxsTemplatePath)
$content = $content -replace "##DIRECTIORIES##", $xmlForDirectories
$content = $content -replace "##FILES##", $xmlForFiles
Set-Content $wxsPath $content

# LICENCE

$licenceTemplatePath = "$basePath\Templates\LICENCE.rtf"
$licencePath = "$basePath\$artifactFolderName\LICENCE.rtf"
$exe = Get-ChildItem -Path "$basePath\$artifactFolderName" -Filter *.exe 
$productName = [io.path]::GetFileNameWithoutExtension($exe[0].FullName)

$content = (Get-Content $licenceTemplatePath)
$content = $content -replace "##ProductName##", $productName
Set-Content $licencePath $content
