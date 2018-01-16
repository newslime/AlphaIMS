using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlphaIMS
{
    public partial class LoginForm : Form
    {
        uTextBox userTextBox;
        uTextBox passTextBox;

        public static bool Login = false;
        public string ReturnUser { get; set; }

        public LoginForm(int x, int y)
        {
            InitializeComponent();

            this.Location = new Point(x, y);
            this.BackColor = Color.FromArgb(45, 57, 83);

            if (Login)
            {
                loginBtn.Text = "登出";
                cancelBtn.Visible = false;
            }
            else
            {
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
                userTextBox.BackColor = Color.FromArgb(43, 43, 43);
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
                passTextBox.BackColor = Color.FromArgb(43, 43, 43);
                passTextBox.BorderStyle = BorderStyle.FixedSingle;
                passTextBox.PasswordChar = '*';
                passTextBox.TabIndex = 2;
                this.passTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passTextBox_KeyPress);
                this.Controls.Add(passTextBox);
            }

            this.ActiveControl = titleLabel;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;

            if (Login)
            {
                Login = false;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (userTextBox.Text == "")
                {
                    //MessageBox.Show("请输入帐号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorLabel.Text = "请输入帐号";
                    errorLabel.Visible = true;
                    return;
                }

                if (passTextBox.Text == "")
                {
                    //MessageBox.Show("请输入密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorLabel.Text = "请输入密码";
                    errorLabel.Visible = true;
                    return;
                }

                if (userTextBox.Text == "admin" && passTextBox.Text == "123456")
                {
                    Login = true;
                    ReturnUser = userTextBox.Text;
                    this.DialogResult = DialogResult.OK;
                    /*AccountForm accountForm = new AccountForm();

                    if (accountForm.ShowDialog(this) == DialogResult.OK)
                    {
                        userTextBox.Text = "";
                        passTextBox.Text = "";
                    }*/
                }
                else
                {
                    errorLabel.Text = "帐号密码错误";
                    errorLabel.Visible = true;
                    //MessageBox.Show("无法使用admin", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                /*else
                {
                    if (Sqlite.SelectAccount(userTextBox.Text, passTextBox.Text) == 0)
                    {
                        Login = true;
                        ReturnUser = userTextBox.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        errorLabel.Text = "帐号密码错误";
                        errorLabel.Visible = true;
                    }
                }*/
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

            /*if (e.KeyChar == (Char)13)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }*/
        }
    }

    public partial class uTextBox : TextBox
    {
        private string _tipText = string.Empty; //提示訊息
        public string TipText
        {
            get { return _tipText; }
            set { _tipText = value; Invalidate(); }
        }

        private Color _tipColor = SystemColors.Highlight; //訊息顏色
        public Color TipColor
        {
            get { return _tipColor; }
            set { _tipColor = value; Invalidate(); }
        }

        private Font _tipFont = DefaultFont; //訊息字型
        public Font TipFont
        {
            get { return _tipFont; }
            set { _tipFont = value; Invalidate(); }
        }

        const int WM_PAINT = 0xF; //繪製的訊息
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT /*&& !string.IsNullOrEmpty(_tipText) && Text.Length == 0*/ && Enabled && !ReadOnly && !Focused) //判斷TextBox的狀態決定要不要顯示提示訊息
            {
                TextFormatFlags formatFlags = TextFormatFlags.Default; //使用原始設定的對齊方式來顯示提示訊息
                formatFlags = TextFormatFlags.Left;

                Rectangle r = this.ClientRectangle;
                r.Inflate(-5, -5);

                TextRenderer.DrawText(Graphics.FromHwnd(Handle), _tipText, _tipFont, r, _tipColor, BackColor, formatFlags); //畫出提示訊息 

                var dc = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    Pen p = new Pen(Color.FromArgb(151, 151, 151));
                    g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                }
            }
        }

        public uTextBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}
