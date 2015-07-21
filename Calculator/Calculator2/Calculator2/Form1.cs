using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace Calculator2
{
    public partial class Form1 : Form
    {
        Button [] numb = new Button[16];
        public TextBox txtCalc;
        string sign;
        bool status = false;
        string btValue;
        string txtValue;
        string[] oppName = {"+","-","*","/","="};
        double a=0,b=0;
        calOperations calOp = new calOperations();

       public Form1()
        {
            InitializeComponent();
            txtCalc = new TextBox();
            txtCalc.Location = new Point(10,5);
            txtCalc.Size = new Size(120, 10);
            txtCalc.ReadOnly = true;
            txtCalc.Text = "0";
            this.Controls.Add(txtCalc);
            addButtons();
         }   

// !Создание кнопок
        public void addButtons()
        {
            int x = 5;
            int y = 5;
            int gap = 2;
            int n = 1;
            int m = 11;
            for (int i = 1; i <= 9; i++)
            {
                numb[i]=new Button();
                numb[i].Text = Convert.ToString(i);
                numb[i].Tag = i;
                numb[i].TabIndex = i;
                numb[i].Size = new Size(30, 30);
                numb[i].Click += new EventHandler(Number_Click); 
                Controls.Add(numb[i]);
             }

            // Создание 0
            numb[0] = new Button();
            numb[0].Text = Convert.ToString(0);
            numb[0].Tag = 0;
            numb[0].TabIndex = 0;
            numb[0].Location = new Point(7, 133);
            numb[0].Click += new EventHandler(Number_Click);
            numb[0].BackColor = Color.White;
            numb[0].Size = new Size(63, 30);
            Controls.Add(numb[0]);
            // -----------------------------------

            // Создание Clear
            numb[10] = new Button();
            numb[10].Text = "C";
            numb[10].Tag = "C";
            numb[10].TabIndex = 10;
            numb[10].Location = new Point(72, 133);
            numb[10].Click += new EventHandler(ClearAll_Click);
            numb[10].BackColor = Color.White;
            numb[10].Size = new Size(30, 30);
            Controls.Add(numb[10]);
            // -----------------------------------

                for (int j = 3; j > 0; j--)
                    for (int i = 0; i < 3; i++)
                    {
                        numb[n].Location = new Point((x + gap * (i + 1) + 30 * i), 30 * j + y + gap * j);
                        n = n + 1;
                    }

            // Создание операций
                for (int i = 11; i <= 15; i++)
                {
                    numb[i] = new Button();
                    numb[i].Text = oppName[i-11];
                    numb[i].Tag = i;
                    numb[i].TabIndex = i;
                    numb[i].Size = new Size(30, 30);
                    numb[i].Click += new EventHandler(Oppertion_Click);
                    numb[i].BackColor = Color.White;
                    Controls.Add(numb[i]);
                }

                for (int j = 0; j < 5; j++)
                {
                    numb[m].Location = new Point(102, 30 * j + 37 + gap * j);
                    m = m + 1;
                }

              // -----------------------------------

        }

        public void Number_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            btValue = bt.Text;
            txtValue = txtCalc.Text;
            if (txtValue == "0" || status == false)
            {
                txtCalc.Text = btValue;
                status = true;
            }
            else
            {
                txtCalc.Text = txtCalc.Text+ btValue;
            }

           }

        public  void ClearAll_Click(object sender, EventArgs e)
        {
            b = 0;
            a = 0;
            txtCalc.Text = "0";
        }

        public  void Oppertion_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            btValue = bt.Text;
            if (txtCalc.Text != "Деление на ноль")
            {
                b = Convert.ToInt64(txtCalc.Text);
                txtCalc.Text = calOp.Action(a, b, sign);
            }
            if (txtCalc.Text != "Деление на ноль")
            {
                a = Convert.ToInt64(txtCalc.Text);
            }
            else
            {
                a = 0;
                b= 0 ;
            }
            status = false;
            sign = btValue;
        }

    }
   
}
