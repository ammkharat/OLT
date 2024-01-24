using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TestTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetTitle();
        }

        private void SetTitle()
        {
            var productNameFormat = "OLT Test Tools {0}.{1}.{2}";

            var assembly = Assembly.GetExecutingAssembly();
            var exePath = assembly.Location; // i.e. "C:\\dev\\windows\\csc\\trunk\\src\\TestTool\\bin\\Debug\\TestTool.exe"
            var oltPath = exePath.Replace("TestTool.exe", "Operator Log Tool.exe");

            var fileVersionInfo = FileVersionInfo.GetVersionInfo(oltPath);
            var major = fileVersionInfo.FileMajorPart;
            var minor = fileVersionInfo.FileMinorPart;
            var build = fileVersionInfo.FileBuildPart;

            var productName = string.Format(productNameFormat, major, minor, build);

            Text = productName;
        }
    }
}
