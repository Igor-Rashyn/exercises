using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Data;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uri address;
        BasicHttpBinding binding;
        ChannelFactory<IService> factory;
        EndpointAddress endpoint;
        IService channel;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();
            Connect("http://localhost:2000/IService");
        }

        public void Connect (string addr)
        {
            try
            {
                address = new Uri(addr);
                binding = new BasicHttpBinding();
                endpoint = new EndpointAddress(address);
                factory = new ChannelFactory<IService>(binding, endpoint);
                channel = factory.CreateChannel();
                string newString = channel.GetData("<All data>");
                BindDataToGrid(newString);
            }
            catch {
                Connect("http://localhost:2000/IService");
            }
        }


        public void BindDataToGrid(string value)
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Strength", typeof(string));
            dt.Columns.Add("Age", typeof(Int32));
            dt.Columns.Add("Stamina", typeof(Int32));
            dt.Columns.Add("Beauty", typeof(Int32));
            dt.Columns.Add("EyeColor", typeof(string));
            dt.Columns.Add("Smile", typeof(string));
            dt.Columns.Add("Gender", typeof(string));

            string[] strArr = value.Split(',');
            for (int i=0; i<strArr.Length; i++)
            {
                if (strArr[i] == "EF.Model.Man")
                {
                    var row = dt.NewRow();
                    dt.Rows.Add(row);
                    row["Id"] = Convert.ToInt32(strArr[i+1]);
                    row["Name"] = strArr[i + 2];
                    row["Strength"] = strArr[i + 3];
                    row["Age"] = Convert.ToInt32(strArr[i + 4]);
                    row["Stamina"] = Convert.ToInt32(strArr[i + 5]);
                    row["Gender"] = "Man";
                }
                else if (strArr[i] == "EF.Model.Woman")
                {
                    var row = dt.NewRow();
                    dt.Rows.Add(row);
                    row["Id"] = Convert.ToInt32(strArr[i + 1]);
                    row["Name"] = strArr[i + 2];
                    row["Beauty"] = Convert.ToInt32(strArr[i + 3]);
                    row["EyeColor"] = strArr[i + 4];
                    row["Smile"] = strArr[i + 5];
                    row["Gender"] = "Woman";
                }
            }
            MyGrid.ItemsSource = null;
            MyGrid.ItemsSource = dt.DefaultView;
            //MyGrid.ItemsSource = dt.AsDataView();
        }

        private void MyGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
           
            string value = null;
            if (e.EditAction == DataGridEditAction.Commit)
            {
                //FormulaOneDriver driver = e.Row.DataContext as FormulaOneDriver;
                //driver.Save();
                var grid = (DataGrid)sender;
                var countDG = grid.Items.Count-1;
                var countDT = dt.Rows.Count;
                object item = grid.SelectedItem;
                var gender = (MyGrid.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
                if (countDG != countDT)
                {
                    if (gender.ToUpper() == "MAN")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        row["Id"] = Convert.ToInt32((MyGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                        row["Name"] = (MyGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                        row["Strength"] = (MyGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                        row["Age"] = Convert.ToInt32((MyGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                        row["Stamina"] = Convert.ToInt32((MyGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text);
                        row["Gender"] = "Man";
                        for (int i = 0; i < 8; i++)
                        {
                            value = value + "," + (MyGrid.SelectedCells[i].Column.GetCellContent(item) as TextBlock).Text;
                        }
                    }
                    else if (gender.ToUpper() == "WOMAN")
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        row["Id"] = Convert.ToInt32((MyGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                        row["Name"] = (MyGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                        row["Beauty"] = Convert.ToInt32((MyGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);
                        row["EyeColor"] = (MyGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                        row["Smile"] = (MyGrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                        row["Gender"] = "Woman";
                        for (int i = 0; i < 9; i++)
                        {
                            value = value + "," + (MyGrid.SelectedCells[i].Column.GetCellContent(item) as TextBlock).Text;
                        }
                    }

                    if (value != null)
                        channel.InsertPerson(value);
                }
                else
                {
                    var id = (MyGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    if (gender.ToUpper() == "MAN")
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            value = value + "," + (MyGrid.SelectedCells[i].Column.GetCellContent(item) as TextBlock).Text;
                        }
                    }
                    else if (gender.ToUpper() == "WOMAN")
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            value = value + "," + (MyGrid.SelectedCells[i].Column.GetCellContent(item) as TextBlock).Text;
                        }
                    }
                    channel.UpdatePerson(Convert.ToInt32(id),value);
                }

            }



        }

        //private void MyDataGrid_PreviewDeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        //{
        //    if (e.Command == DataGrid.DeleteCommand)
        //    {
        //        if (!(MessageBox.Show("Are you sure you want to delete?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
        //        {
        //            // Cancel Delete.
        //            e.Handled = true;

        //        }
        //    }
        //}

        private void MyGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 0)
                {
                    var Res = MessageBox.Show("Are you sure you want to delete " + grid.SelectedItems.Count + " people?", "Deleting Records", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (Res == MessageBoxResult.Yes)
                    {
                        foreach (var row in grid.SelectedItems)
                        {
                            object item = row;
                            var b = (MyGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                            channel.DeletePerson(b);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["Id"].ToString() == b)
                                {
                                    dt.Rows.RemoveAt(i);
                                }
                            }
                            dt.AcceptChanges();
                        }
                        MessageBox.Show(grid.SelectedItems.Count + " have being deleted!");
                    }
                    else
                        MyGrid.ItemsSource = dt.DefaultView;
                       // .ItemsSource = GetEmployeeList();
                }
            }
        }
    }
}
