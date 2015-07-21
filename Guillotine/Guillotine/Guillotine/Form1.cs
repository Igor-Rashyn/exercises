using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guillotine
{
    public partial class Form1 : Form
    {
        Element el; // элементы
        List<Element> freeElements = new List<Element>();
        List<Element> elements = new List<Element>();
        List<Element> allElements = new List<Element>();
        List<Field> fields = new List<Field>();
        private int page =0;
        private int currentPage = 0;
        public Form1()
        {
            InitializeComponent();
            //fields.Add(new Field(1));
            //this.Controls.Add(fields[0]);
            //el = new Element(50, 120);
            //fields[0].Controls.Add(el);
            //page++;
        }


        private List<Element> SortLis(List<Element> el)
        {
            el.Sort((a, b) => a.Height.CompareTo(b.Height) * -1);
            return el;
        }



        private void addToCollectionButton_Click(object sender, EventArgs e)
        {
            var width= Convert.ToInt16(this.widthTextBox.Text);
            var height = Convert.ToInt16(this.heightTextBox.Text);
            var amount = Convert.ToInt16(this.amountTextBox.Text);
            while (amount != 0)
            {
                allElements.Add(new Element(width, height));
                amount--;
            }
            this.widthTextBox.Text = "";
            this.heightTextBox.Text = "";
            this.amountTextBox.Text = "";
        }

        private void allocateButton_Click(object sender, EventArgs e)
        {
            fields.Clear();
           // freeElements.Clear();
            page = 0;
            for (int i = 0; i < allElements.Count; i++)
            {
                allElements[i].Page = 0;                  
                freeElements.Add(allElements[i]);             
            }           
            var el = SortLis(freeElements);

            myPanel.Controls.Clear();
            
            
            while (freeElements.Count != 0)
            {
                if (freeElements.Count != 0)
                {
                    page++;
                    fields.Add(new Field(page).Place(el));
                    myPanel.Controls.Add(fields[page-1]);
                }
                else
                {
                    MessageBox.Show("No elements for locating", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                for(int i=0; i<freeElements.Count; i++)
                {
                    if (freeElements[i].Page==0)
                    {
                        elements.Add(freeElements[i]);
                    }
                }
                freeElements.Clear();
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Page == 0)
                    {
                        freeElements.Add(elements[i]);
                      //  el.Add(elemens[i]);
                    }
                }
                elements.Clear();
                el = SortLis(freeElements);
            }

        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (currentPage!=0)
            {
                fields[currentPage].Visible = false;
                fields[currentPage-1].Visible = true;
                currentPage--;
            }
            else
            {
                MessageBox.Show("You cannot change a pange, because it is first!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (currentPage != fields.Count-1)
            {
                fields[currentPage].Visible = false;
                fields[currentPage + 1].Visible = true;
                currentPage++;
            }
            else
            {
                MessageBox.Show("You cannot change a pange, because it is last!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }
    }
}
