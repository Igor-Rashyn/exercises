using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MVP.Presenter.Presenter presenter = new MVP.Presenter.Presenter();
            View Viewer = new View();
            MVP.Model.Factory model = new Model.Factory();

            Viewer.pr= presenter;
            presenter.model = model;
            presenter.view = Viewer;
            Application.Run(Viewer);

        }
    }
}
