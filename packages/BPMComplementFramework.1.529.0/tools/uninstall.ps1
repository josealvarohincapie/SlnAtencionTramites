param($installPath, $toolsPath, $package, $project)
$archivoBundleConfig = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($project.FileName), "App_Start\BundleConfig.cs")
if([System.IO.File]::Exists($archivoBundleConfig)){
   
$pattern = "bundles.Add\(new Ultimus.Framework.ResourceTrasform\(\).GetBundleScriptsResources\(\)\);"
$fileOriginal = Get-Content $archivoBundleConfig

# Crea un Array vacío y lo usa como archivo modificado...
[String[]] $fileModified = @() 
$regExp = New-Object Regex($pattern)
foreach ($line in $fileOriginal)
{    
    # Si la línea es la linea buscada, la reemplaza por ""
    $line =$regExp.Replace($line, "")
    $fileModified += $line
}
Set-Content $archivoBundleConfig $fileModified
}
#**********************************************************************Parte para borrar las modificaciones al global.asax********************************************************
$archivoGlobalAsax = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($project.FileName), "Global.asax.cs")
if([System.IO.File]::Exists($archivoGlobalAsax)){

$pattern2 ="new Ultimus.Framework.ResourceTrasform\(\).OptimizeUltimusFrameworkBundle\(\);"
$fileGlobalOriginal = Get-Content $archivoGlobalAsax

# Crea un Array vacío y lo usa como archivo modificado...
[String[]] $fileGlobalModified = @() 
$regExp = New-Object Regex($pattern2)
foreach ($line in $fileGlobalOriginal)
{    
    #Write-Host $line;
    # Si la línea es la linea buscada, la reemplaza por ""
    $line =$regExp.Replace($line, "")
    $fileGlobalModified += $line
}
Set-Content $archivoGlobalAsax $fileGlobalModified
}
