using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlphaIMS
{
    public partial class ColumnForm : Form
    {
        public string ReturnName { get; set; }
        public string ReturnFormula { get; set; }
        public double ReturnMin { get; set; }
        public double ReturnMax { get; set; }
        public int ReturnReadvalue { get; set; }

        public ColumnForm(int column, int x, int y, TABLECOLUMN tableCol)
        {
            InitializeComponent();

            columnLabel.Text = string.Format("{0}列", Convert.ToChar(column + 65).ToString());
            nameTextBox.Text = Convert.ToChar(column + 65).ToString();
            
            if (tableCol != null)
            {
                formulaTextBox.Text = tableCol.Formula;
                minTextBox.Text = tableCol.Min.ToString("f3");
                maxTextBox.Text = tableCol.Max.ToString("f3");

                if (tableCol.Name != "")
                    nameTextBox.Text = tableCol.Name;

                switch (tableCol.Readvalue)
                {
                    case 0:
                        radioButton1.Checked = true;
                        break;

                    case 1:
                        radioButton2.Checked = true;
                        break;

                    case 2:
                        radioButton3.Checked = true;
                        break;

                    case 3:
                        radioButton4.Checked = true;
                        break;

                    case 4:
                        radioButton5.Checked = true;
                        break;
                }

                if (formulaTextBox.Text == "")
                {
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    radioButton4.Visible = true;
                    radioButton5.Visible = true;
                }
                else
                {
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;
                    radioButton5.Visible = false;
                }
            }

            OKBtn.BackColor = Color.FromArgb(72, 180, 225);
            cancelBtn.BackColor = Color.FromArgb(72, 180, 225);

            if ((x + this.Width) > Screen.PrimaryScreen.Bounds.Width)
                x = x - ((x + this.Width) - Screen.PrimaryScreen.Bounds.Width);

            this.Location = new Point(x, y);
            this.BackColor = Color.FromArgb(226,226,226);
        }


        private void OKBtn_Click(object sender, EventArgs e)
        {
            ReturnName = nameTextBox.Text;
            ReturnFormula = formulaTextBox.Text;
            ReturnMin = Double.Parse(minTextBox.Text);
            ReturnMax = Double.Parse(maxTextBox.Text);

            if (radioButton1.Checked)
                ReturnReadvalue = 0;
            else if (radioButton2.Checked)
                ReturnReadvalue = 1;
            else if(radioButton3.Checked)
                ReturnReadvalue = 2;
            else if(radioButton3.Checked)
                ReturnReadvalue = 3;
            else
                ReturnReadvalue = 4;

            this.DialogResult = DialogResult.OK;
        }

        private void formulaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (Char)97 && e.KeyChar <= (Char)122)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void formulaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (formulaTextBox.Text == "")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
            }
        }

        private void minTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.KeyChar == (Char)48 ~ 57 -----> 0~9
            // e.KeyChar == (Char)8 -----------> Backpace
            // e.KeyChar == (Char)46 -----------> .
            if (e.KeyChar == (Char)48 || e.KeyChar == (Char)49 ||
               e.KeyChar == (Char)50 || e.KeyChar == (Char)51 ||
               e.KeyChar == (Char)52 || e.KeyChar == (Char)53 ||
               e.KeyChar == (Char)54 || e.KeyChar == (Char)55 ||
               e.KeyChar == (Char)56 || e.KeyChar == (Char)57 ||
               e.KeyChar == (Char)8 || e.KeyChar == (Char)46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void maxTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.KeyChar == (Char)48 ~ 57 -----> 0~9
            // e.KeyChar == (Char)8 -----------> Backpace
            // e.KeyChar == (Char)46 -----------> .
            if (e.KeyChar == (Char)48 || e.KeyChar == (Char)49 ||
               e.KeyChar == (Char)50 || e.KeyChar == (Char)51 ||
               e.KeyChar == (Char)52 || e.KeyChar == (Char)53 ||
               e.KeyChar == (Char)54 || e.KeyChar == (Char)55 ||
               e.KeyChar == (Char)56 || e.KeyChar == (Char)57 ||
               e.KeyChar == (Char)8 || e.KeyChar == (Char)46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public class TABLECOLUMN
    {
        public TABLECOLUMN()
        {
            Name = "";
            Formula = "";
            Min = 0.00;
            Max = 1000.00;
            Readvalue = 0;
        }

        public string Name { get; set; }
        public string Formula { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public int Readvalue { get; set; }
    }
}
