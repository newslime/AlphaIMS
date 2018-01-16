using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlphaIMS
{
    public partial class AccountForm : Form
    {
        uTextBox userTextBox;
        uTextBox passTextBox;
        uTextBox confirmTextBox;

        public AccountForm()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(44, 82, 110);

            userTextBox = new uTextBox();
            userTextBox.TipFont = new Font("微軟正黑體", 10);
            userTextBox.TipColor = Color.FromArgb(255, 255, 255);
            userTextBox.TipText = "帐号";
            userTextBox.Font = new Font("微軟正黑體", 10);
            userTextBox.TextAlign = HorizontalAlignment.Center;
            userTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            userTextBox.AutoSize = false;
            userTextBox.Size = new Size(180, 30);
            userTextBox.Location = new Point(35, 50);
            userTextBox.BackColor = Color.FromArgb(44, 82, 110);
            userTextBox.BorderStyle = BorderStyle.FixedSingle;
            userTextBox.TabIndex = 1;
            this.userTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userTextBox_KeyPress);
            this.Controls.Add(userTextBox);

            passTextBox = new uTextBox();
            passTextBox.TipFont = new Font("微軟正黑體", 10);
            passTextBox.TipColor = Color.FromArgb(255, 255, 255);
            passTextBox.TipText = "密码";
            passTextBox.Font = new Font("微軟正黑體", 10);
            passTextBox.TextAlign = HorizontalAlignment.Center;
            passTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            passTextBox.AutoSize = false;
            passTextBox.Size = new Size(180, 30);
            passTextBox.Location = new Point(35, 90);
            passTextBox.BackColor = Color.FromArgb(44, 82, 110);
            passTextBox.BorderStyle = BorderStyle.FixedSingle;
            passTextBox.PasswordChar = '*';
            passTextBox.TabIndex = 2;
            this.passTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passTextBox_KeyPress);
            this.Controls.Add(passTextBox);

            confirmTextBox = new uTextBox();
            confirmTextBox.TipFont = new Font("微軟正黑體", 10);
            confirmTextBox.TipColor = Color.FromArgb(255, 255, 255);
            confirmTextBox.TipText = "确认";
            confirmTextBox.Font = new Font("微軟正黑體", 10);
            confirmTextBox.TextAlign = HorizontalAlignment.Center;
            confirmTextBox.ForeColor = Color.FromArgb(255, 255, 255);
            confirmTextBox.AutoSize = false;
            confirmTextBox.Size = new Size(180, 30);
            confirmTextBox.Location = new Point(35, 130);
            confirmTextBox.BackColor = Color.FromArgb(44, 82, 110);
            confirmTextBox.BorderStyle = BorderStyle.FixedSingle;
            confirmTextBox.PasswordChar = '*';
            confirmTextBox.TabIndex = 3;
            this.confirmTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmTextBox_KeyPress);
            this.Controls.Add(confirmTextBox);

            this.ActiveControl = titleLabel;
        }

        private void userTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorLabel.Visible = false;

            /*if (e.KeyChar == (Char)13)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }*/
        }

        private void passTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void confirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text == "")
            {
                errorLabel.Text = "请输入帐号";
                errorLabel.Visible = true;
                return;
            }

            if (passTextBox.Text == "")
            {
                errorLabel.Text = "请输入密码";
                errorLabel.Visible = true;
                //MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (confirmTextBox.Text == "")
            {
                errorLabel.Text = "请确认密码";
                errorLabel.Visible = true;
                return;
            }

            if (passTextBox.Text != confirmTextBox.Text)
            {
                errorLabel.Text = "密码错误";
                errorLabel.Visible = true;
                return;
            }
        }
    }
}
