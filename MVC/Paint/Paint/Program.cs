using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        static void Main()
        {
            MVC.Controller.Controller control = new MVC.Controller.Controller();
            View Viewer = new View();
            MVC.Model.Factory model = new Model.Factory();

            Viewer.model = model;
            Viewer.ctr = control;
            control.model = model;
            model.view = Viewer;
            Application.Run(Viewer);

        }
    }
}


//Controller Control = new Controller();
//            Painter Viewer = new Painter();  ----
//            Viewer.cP = Control;----
//            Control.pV = Viewer;
//            Application.Run(Viewer);
