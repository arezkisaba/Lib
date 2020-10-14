Param(
	[switch]$Local = $false,
	[switch]$Uwp = $false
)

function Resolve-MsBuild {
	$msb2017 = Resolve-Path "${env:ProgramFiles(x86)}\Microsoft Visual Studio\*\*\MSBuild\*\bin\msbuild.exe" -ErrorAction SilentlyContinue
	if($msb2017.Length -gt 0) {
		Write-Host "Found MSBuild 2017 (or later)."
		Write-Host $msb2017[0]
		return $msb2017[0]
	}

	$msBuild2015 = "${env:ProgramFiles(x86)}\MSBuild\14.0\bin\msbuild.exe"

	if(-Not (Test-Path $msBuild2015)) {
		throw 'Could not find MSBuild 2015 or later.'
	}

	Write-Host "Found MSBuild 2015."
	Write-Host $msBuild2015

	return $msBuild2015
}

if ($Local) {
	$artifactFeed = "Development"
	$artifactFolder = $Env:TEMP
} else {
	$artifactFeed = $Env:Build_DEFINITIONNAME
	$artifactFolder = $Env:BUILD_ARTIFACTSTAGINGDIRECTORY

	if ($artifactFeed -eq $null -Or $artifactFolder -eq $null) {
		throw "Build_DEFINITIONNAME or BUILD_ARTIFACTSTAGINGDIRECTORY are undefined"
	}
}

$nugetArtifactFolder = [io.path]::combine($artifactFolder, 'NuGetPackages', [system.guid]::newguid().tostring())
$source = "https://arezkisaba.pkgs.visualstudio.com/Lib/_packaging/Development/nuget/v3/index.json"

$PackageName = (Get-Item .).Name
$csproj = "$PackageName.csproj"
$nuspec = "$PackageName.nuspec"

if ($Uwp) {
	$msBuild = Resolve-MsBuild
	& $msBuild $csproj /p:Configuration=Debug
	nuget pack $nuspec -Symbols -SymbolPackageFormat snupkg -OutputDirectory $nugetArtifactFolder -Properties Configuration=Debug
} else {
	dotnet restore
	dotnet pack $csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -o $nugetArtifactFolder -c Debug
}

$packages = Get-ChildItem -Path $nugetArtifactFolder -Filter *.nupkg
foreach ($package in $packages) {
 	nuget push $package.FullName "apiKey" -Source "$source"
}
