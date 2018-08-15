using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) {
            //path to the executable
            string thisPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string pluginFolderBasePath = @"C:\DOUsRevitPlugin";
            string pluginAssemblyName = "DigitalOnUsPlugin.dll";
            string addInsRevitPathFolderPath = @"C:\ProgramData\Autodesk\Revit\Addins\2019";

            //Delete plugin folder if exists
            if (Directory.Exists(pluginFolderBasePath)) {
                Directory.Delete(pluginFolderBasePath, true);
            }
            CreatePluginFolder(pluginFolderBasePath, thisPath);
            CreateAddInManifest(pluginFolderBasePath, pluginAssemblyName, addInsRevitPathFolderPath, thisPath);
            MessageBox.Show("Plugin installed");
            this.Close();
        }

        private void CreatePluginFolder(string pluginFolderBasePath, string thisPath) {
            string sourcePath = $@"{thisPath}\plugin";

            //First create the main plugin folder
            Directory.CreateDirectory(pluginFolderBasePath);

            //Create all the folders
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories)) {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, pluginFolderBasePath));
            }

            //Now copy all the files
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories)) {
                File.Copy(newPath, newPath.Replace(sourcePath, pluginFolderBasePath), true);
            }
        }

        private void CreateAddInManifest(string pluginFolderBasePath, string pluginAssemblyName, string addInsRevitPathFolderPath, string thisPath) {
            string pluginAssemblyFullPath = $@"{pluginFolderBasePath}\{pluginAssemblyName}";
            string manifestTemplate = File.ReadAllText($@"{thisPath}\template\DigitalOnUsPlugin.addin");
            string manifest = manifestTemplate.Replace("${PathToPlugin}", pluginAssemblyFullPath);
            File.WriteAllText($@"{addInsRevitPathFolderPath}\DigitalOnUsPlugin.addin", manifest);
        }
    }
}
