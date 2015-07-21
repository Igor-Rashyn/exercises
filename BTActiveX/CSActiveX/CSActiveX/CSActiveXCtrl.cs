using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CSActiveX
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("7E6F756B-C5A8-483F-8B55-E7FAAE0FDCA1")]
    public interface AxCSActiveXCtrl
    {

    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(AxCSActiveXCtrl))]
    [ProgId("CSActiveXCtrl")]
    [Guid("A6E34C4B-C469-4BD8-A58F-9BF505D30B14")]
    public partial class CSActiveXCtrl : UserControl, AxCSActiveXCtrl
    {
        Tree tree = new Tree();
        Drawer dr = new Drawer();

        public CSActiveXCtrl()
        {
            InitializeComponent();
        }


        #region ActiveX Control Registration
        [ComRegisterFunction()]
        public static void RegisterClass(string key)
        {
            StringBuilder sb = new StringBuilder(key);
            sb.Replace(@"HKEY_CLASSES_ROOT\", "");

            // Open the CLSID\{guid} key for write access  

            RegistryKey k = Registry.ClassesRoot.OpenSubKey(sb.ToString(), true);

            RegistryKey ctrl = k.CreateSubKey("Control");
            ctrl.Close();

            // Next create the CodeBase entry - needed if not string named and GACced.  

            RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);
            inprocServer32.SetValue("CodeBase", Assembly.GetExecutingAssembly().CodeBase);
            inprocServer32.Close();

            k.Close();
        }

        [ComUnregisterFunction()]
        public static void UnregisterClass(string key)
        {
            StringBuilder sb = new StringBuilder(key);
            sb.Replace(@"HKEY_CLASSES_ROOT\", "");

            // Open HKCR\CLSID\{guid} for write access  

            RegistryKey k = Registry.ClassesRoot.OpenSubKey(sb.ToString(), true);

            // Delete the 'Control' key, but don't throw an exception if it does not exist  
            if (k == null)
            {
                return;
            }
            k.DeleteSubKey("Control", false);

            // Next open up InprocServer32  

            RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);

            // And delete the CodeBase key, again not throwing if missing   

            inprocServer32.DeleteSubKey("CodeBase", false);

            // Finally close the main key   

            inprocServer32.Close(); k.Close();
        }
        #endregion

        private void addButton_Click(object sender, EventArgs e)
        {
            tree.Add(Convert.ToInt16(valueTextBox.Text));
            myPictureBox.Image = dr.Drawing(tree);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            tree.Delete(Convert.ToInt16(valueTextBox.Text));
            dr.InOrder(tree);
            myPictureBox.Image = dr.DrawingAllTree(tree);
        }    

    }
    
}
