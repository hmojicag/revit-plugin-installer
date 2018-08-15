# revit-plugin-installer
This is a Revit Plugin Installer

This Windows Forms application was made with Visual Studio Community 2017.


## How to use
Once you Build the .exe (it may be in .\RevitPluginInstaller\WindowsFormsApp1\bin\Debug\WindowsFormsApp1.exe) create 
2 folders in the same folder:
* plugin
* template

In .\plugin paste all the assemblies of the Revit plugin (Including the hardcoded DigitalOnUsplugin.dll).
In .\release paste the manifest template file.

Sample files are in the root of this repository.

This program will copy everything in the .\plugin folder and paste it in C:\DOUsRevitPlugin and then create the addin file  
C:\ProgramData\Autodesk\Revit\Addins\2019\DigitalOnUsPlugin.addin

Check the source code to change the hadcoded paths.
