using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace AlphaIMS
{
    public partial class InAdditionForm : Form
    {
        public string ReturnMailList { get; set; }

        public InAdditionForm(int x, int y)
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(45, 57, 83);
            this.Location = new Point(x, y - this.Height + 55);

            ReturnMailList = "";
         
            string xmlFile = Application.StartupPath + "\\Setting.xml";
            if (File.Exists(xmlFile))
            {
                XmlDocument doc;
                XmlNode node;

                doc = new XmlDocument();
                doc.Load(xmlFile);
                node = doc.DocumentElement.SelectSingleNode("/Setting/Smtp/ToMail");
                emailTextBox.Text = node.InnerText;
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (emailCheckBox.Checked)
            {
                string[] mailList = emailTextBox.Text.Split(',');
                Regex regex;
                Match match;

                for (int i = 0; i < mailList.Length; i++)
                {
                    regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    match = regex.Match(mailList[i]);

                    if (!match.Success)
                    {
                        MessageBox.Show("邮件格式错误 " + mailList[i], "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                ReturnMailList = emailTextBox.Text;

                string xmlFile = Application.StartupPath + "\\Setting.xml";
                if (File.Exists(xmlFile))
                {
                    XmlDocument doc;
                    XmlNode toMailNode;

                    doc = new XmlDocument();
                    doc.Load(xmlFile);
                    toMailNode = doc.DocumentElement.SelectSingleNode("/Setting/Smtp/ToMail");
                    toMailNode.InnerText = ReturnMailList;

                    doc.Save(xmlFile);
                }     
            }

            this.DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}