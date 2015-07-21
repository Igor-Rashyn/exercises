using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toggle
{
    public partial class Form1 : Form
    {
            Random random = new Random();
            int r, value;
            string result;
            int sum;
            //int amount, x,y, attempt;
            int[,] arrMain = new int[4, 4];
            int[,] arrCurrent = new int[4, 4];
            static List<int> arg = new List<int> {0};
            bool solution;
            List<Toggle> toggles;


        public Form1()
        {
            InitializeComponent();
            Draw();

            //for (int i =0; i<4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        r = random.Next(1, 50);
            //        value = (int)Math.Pow(-1, r);
            //        this.Controls.Add(new Toggle(i, j, value)); 
            //    }
            //}
            //foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            //{
            //    toggles.Click += new System.EventHandler(this.Toggles_Click);
            //}

        }
        private void Toggles_Click(object sender, EventArgs e)
        {
            Toggle b = (Toggle)sender;
            int x = b.IPosition;
            int y = b.JPosition;

            foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            {
                if (toggles.JPosition==y || toggles.IPosition==x)
                {
                    if (toggles.value < 0)
                    {
                        toggles.Width = 100;
                        toggles.Height = 50;
                        toggles.Location = new Point(toggles.Location.X - 25, toggles.Location.Y + 25);
                        toggles.value = 1;
                    }
                    else
                    {
                        toggles.Width = 50;
                        toggles.Height = 100;
                        toggles.Location = new Point(toggles.Location.X + 25, toggles.Location.Y - 25);
                        toggles.value = -1;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] array = new int[4, 4];
            int i = 0;         
            foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            {
                int x = toggles.JPosition;
                int y = toggles.IPosition;
                array[x, y] = toggles.value;
                arrMain[x, y] = toggles.value;
                arrCurrent[x, y] = toggles.value;
                if (toggles.value==1)
                {
                    i++;
                }
            }

            Solve();
            //SolvePuzzle(array, ref result, ref attempt,i);
            if (solution==true)
            textBox1.Text = result;
       }
        //private void SolvePuzzle (int [,] array,ref string result, ref int attempt, int sum)
        //{
        //    int[,] keyArray = new int[4, 4];
        //    if (sum >= 5)
        //    {
        //        array = Calculation(ref array, ref result, ref amount, ref x, ref y);
        //    }


        //     for (int i = 0; i < 4; i++)
        //                {
        //                    for (int j = 0; j < 4; j++)
        //                    {
        //                        keyArray[i, j] = array[i,j];
        //                        if (keyArray[i, j]==1)
        //                                {
        //                                    result = result + j+","+i+"; ";
        //                                }
        //                    }
        //                }

        //    result = result + "Step";

        //    for (int i=0; i<4; i++)
        //    {
        //        for (int j=0; j<4; j++)
        //        {
        //            if (keyArray[i, j] == 1)
        //            {

        //                for (int ki = 0; ki < 4; ki++)
        //                {
        //                    for (int kj = 0; kj < 4; kj++)
        //                    {
        //                        if (ki == i || kj == j)
        //                        {
        //                            array[ki, kj] = array[ki, kj] * (-1);
        //                        }
        //                    }
        //                }

        //            }

        //        }
        //    }

        //    attempt++;
        //    if (attempt != 2)
        //    {
        //        SolvePuzzle(array,ref result, ref attempt,0);
        //    }

        //}
        //private int[,] Calculation (ref int [,] arr, ref string result, ref int amount, ref int x, ref int y)
        //{
        //    int count=0;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 4; j++)
        //        {
        //            arr[i, j] = arr[i, j];
        //            if (arr[i, j] == 1)
        //            {
        //                count++;
        //            }
        //        }
        //    }

        //    if (count>=5)
        //    {
        //        for (int i=0;i<4;i++)
        //        {
        //            for (int j=0; j<4; j++)
        //            {
        //                if (arr[i,j]==1 || arr[i,j]==-1)
        //                {
        //                    for (int ik=0; ik<4;ik++)
        //                    {
        //                        for (int jk=0; jk<4; jk++)
        //                        {
        //                            if (ik==i||jk==j)
        //                            {
        //                                sum = sum + arr[ik, jk];
        //                            }
        //                        }
        //                    }
        //                    if (sum>amount)
        //                    {
        //                        amount = sum;
        //                        x=i;
        //                        y=j;
        //                    }
        //                   sum = 0;
        //                }
        //            }

        //        }

        //        for (int i = 0; i < 4; i++)
        //        {
        //            for (int j = 0; j < 4; j++)
        //            {
        //                if (i == x || j == y)
        //                {
        //                    arr[i, j] = arr[i, j] * (-1);
        //                }
        //            }
        //        }
        //    }


         
        //  if (count >= 5 && amount !=0)
        //  {
        //      result = result + y + "," + x + "; ";
        //      amount = 0;
        //      x = 0;
        //      y = 0;
        //      Calculation(ref arr, ref result, ref amount, ref x, ref y);
        //  }
        //  return arr;
        //}

        private void FindCoordinates(List<int> buttons, ref int[,] arrCurrent, int k)
        {
            while (k != buttons.Count)
            {
                var count = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        count++;
                        if (buttons.Count > k)
                        {
                            if (buttons[k] == count)
                            {
                                Change(i, j, ref arrCurrent);
                                if (buttons.Count > k)
                                {
                                    k++;
                                }
                                if (k == buttons.Count)
                                {
                                    Check(ref arrCurrent, ref solution);
                                }
                            }
                        }
                    }
                }
            }


        }
        private void Change(int x, int y, ref int[,] arrCurrent)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == x || j == y)
                    {
                        arrCurrent[i, j] = arrCurrent[i, j] * (-1);
                    }
                }
            }
        }
        private void Check(ref int[,] arrCurrent, ref bool solution)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    if (arrCurrent[i, j] == -1)
                    {
                        sum++;
                    }
            }

            if (sum==16)
            {
                solution = true;

                for (int i = 0; i < arg.Count; i++ )
                {
                    result = result + ","+ Convert.ToString(arg[i]);
                }
                
            }
            else
            {
                sum = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        arrCurrent[i, j] = arrMain[i, j];
                    }

                }

            }

        }
        private void Solve()
        {
            while (solution!=true && arg.Count!=7)
            {
                if(arg[0]!=17)
                {
                    arg[0] = arg[0] + 1;
                }

                for (int j = 0; j < arg.Count; j++ )
                {
                    if (arg[j]==17)
                    {
                        if (arg.Last() == 17)
                        {
                            arg.Add(0);
                        }
                        arg[j] = 1;
                        arg[j + 1] = arg[j + 1] + 1;
                    }
                   
                 }

                FindCoordinates(arg, ref arrCurrent, 0);                   
            }
            if (solution == false)
            {
                MessageBox.Show("No solution less 6 steps", "No solution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        void Draw()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    r = random.Next(1, 50);
                    value = (int)Math.Pow(-1, r);
                    this.Controls.Add(new Toggle(i, j, value));
                }
            }
            foreach (Toggle toggles in this.Controls.OfType<Toggle>())
            {
                toggles.Click += new System.EventHandler(this.Toggles_Click);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int j=0;
            //IEnumerable<Toggle> tr = this.Controls.OfType<Toggle>();
            //List<Toggle> toggles = tr.ToList();

            //foreach (Control ctrl in this)
            //{
            //    if (ctrl is Toggle)
            //        (ctrl as Toggle).Clear();
            //}
            //this.Controls.ClearControls<Toggle>();

            //toggles.Clear();

            while (j!=5)
            {
            foreach (Toggle toggle in this.Controls.OfType<Toggle>())
            {
                this.Controls.Remove(toggle);
                
            }
            j++;
            }


            Draw();
            textBox1.Text = "Результат...";
            arg = new List<int> { 0 };
        }

     
    }
}
