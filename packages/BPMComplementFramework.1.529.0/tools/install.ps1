param($installPath, $toolsPath, $package, $project)
$archivoBundleConfig = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($project.FileName), "App_Start\BundleConfig.cs")
if([System.IO.File]::Exists($archivoBundleConfig)){
$pattern = "public static void RegisterBundles"
$fileOriginal = Get-Content $archivoBundleConfig

# Crea un Array vacío y lo usa como un archivo modificado... 
[String[]] $fileModified = @() 
# Va recorriendo el archivo Original y agregando cada linea en el archivo modificado
foreach ($line in $fileOriginal)
{    
    $fileModified += $line
    # Cuando el flag es true agrega el texto que queremos y volvemos a false el flag
    # Esto para agregar el texto inmediatamente despues del caracter {
    if($flag -eq $True)
    {
       $flag = $False
       $fileModified += '            bundles.Add(new Ultimus.Framework.ResourceTrasform().GetBundleScriptsResources());' + [System.Environment]::NewLine +
                        '            bundles.Add(new ScriptBundle("~/bundles/tether").Include("~/Scripts/tether/tether.min.js"));' + [System.Environment]::NewLine +
                        '            bundles.Add(new StyleBundle("~/Content/tether").Include("~/Content/tether/tether.css"));'
    }
    # Si la linea coincide con el pattern buscado establece flag a true
    if ($line -match $pattern) 
    {
       $flag=$True
    } 
}
Set-Content $archivoBundleConfig $fileModified
}
#**************************************************Parte que agrega un código en el global.asax*********************************************************************
$archivoGlobalAsax = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($project.FileName), "Global.asax.cs")
if([System.IO.File]::Exists($archivoGlobalAsax)){
$fileGlobalOriginal = Get-Content $archivoGlobalAsax
#Write-Host $fileGlobalOriginal
$pattern2 = "BundleConfig.RegisterBundles"
[String[]] $fileGlobalModified = @() 
$bandera = $False
#Write-Host "Bandera antes de entrar al for "$bandera
foreach ($line in $fileGlobalOriginal)
{
    $fileGlobalModified += $line
    if ($line -match $pattern2) 
    {
       $bandera = $True
       #$fileGlobalModified += "#if DEBUG" + [System.Environment]::NewLine + "            BundleTable.EnableOptimizations = true;" + [System.Environment]::NewLine + "            foreach (var bundle in BundleTable.Bundles.Where(b => b.Path != ""~/Scripts/Ultimus-Framework"").ToList())" + [System.Environment]::NewLine + "                bundle.Transforms.Clear();" + [System.Environment]::NewLine + "#endif"
       $fileGlobalModified += "            new Ultimus.Framework.ResourceTrasform().OptimizeUltimusFrameworkBundle();"
    }
}

Set-Content $archivoGlobalAsax $fileGlobalModified
#Write-Host "Bandera despues de salir del for "$bandera


# Si no existe la linea BundleConfig.RegisterBundle en el global.asax , la debe escribir e inmediatamente debajo escribir lo que necesitamos
if($bandera -eq $False)
{
    $fileGlobal = Get-Content $archivoGlobalAsax
    [String[]] $fileNuevo = @() 
#    Write-Host $fileGlobal
    $nuevoPattern = "protected void Application_Start"
    $flag2=$False
    foreach ($line in $fileGlobal)
    {    
      $fileNuevo +=$line 
      # Cuando el flag2 es true agrega el texto que queremos y volvemos a false el flag2
      # Esto para agregar el texto inmediatamente despues del caracter {
      if($flag2 -eq $True)
      {
         $flag2 = $False
         $fileNuevo += "            BundleConfig.RegisterBundles(BundleTable.Bundles);" + [System.Environment]::NewLine + "            new Ultimus.Framework.ResourceTrasform().OptimizeUltimusFrameworkBundle();"
      }
      # Si la linea coincide con el pattern buscado establece flag2 a true
      if ($line -match $nuevoPattern) 
      {
         $flag2=$True
      }  
    }
    Set-Content $archivoGlobalAsax $fileNuevo
 }
 }