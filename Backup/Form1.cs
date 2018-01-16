using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Xml;

using System.Net;

namespace AlphaIMS
{
	public partial class Form1 : Form
	{
        static int SelectHeaderRowIndex = -1;
        static int SelectHeaderColumnIndex = -1;
        static string _filepath = "D:\\Table";
        List<TABLECOLUMN> tableColList = new List<TABLECOLUMN>();

		public Form1()
		{
			InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.Text = "AlphaIMS-" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.BackColor = Color.FromArgb(61, 64, 77);
            monthCalendar1.MaxSelectionCount = 1;
            controlPanel.BackColor = Color.FromArgb(45, 57, 83);
            settingPanel.BackColor = Color.FromArgb(45, 57, 83);
            toolTip1.SetToolTip(saveBtn, "储存资料");
            toolTip2.SetToolTip(deleteBtn, "删除表格");
            monthCalendar1.BringToFront();
            userLabel.Text = "";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            string[] AvailableCOMPorts = System.IO.Ports.SerialPort.GetPortNames();
            serialPort1.PortName = AvailableCOMPorts[0];
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.Parity = Parity.None;

            string xmlFile = Application.StartupPath + "\\Setting.xml";
            XmlDocument doc = new XmlDocument();
            if (File.Exists(xmlFile))
            {
                doc.Load(xmlFile);
                XmlNode node = doc.DocumentElement.SelectSingleNode("/Setting/SerialPort/Name");
                if(node != null)
                    serialPort1.PortName = node.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Setting/SerialPort/BaudRate");
                if (node != null)
                    serialPort1.BaudRate = Int32.Parse(node.InnerText);

                node = doc.DocumentElement.SelectSingleNode("/Setting/FilePath");
                if (node != null)
                    _filepath = node.InnerText;

                int size;
                node = doc.DocumentElement.SelectSingleNode("/Setting/Font");
                if (node != null)
                    if (Int32.TryParse(node.InnerText, out size))
                        DataGridView1.DefaultCellStyle.Font = new Font("Microsoft JhengHei", size);
            }
            Directory.CreateDirectory(_filepath);

            try
            {
                Sqlite.Open();
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
            }
		}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tableColList.Clear();

            if (serialPort1.IsOpen)
                serialPort1.Close();

            try
            {
                Sqlite.Close();
            }
            catch (Exception ex)
            {
                EventLog.Write(ex.Message);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            controlPanel.Width = this.Width;

            DataGridView1.Width = this.Width - DataGridView1.Location.X - 20;
            DataGridView1.Height = this.Height - DataGridView1.Location.Y - 50;

            minimizeBtn.Location = new Point(controlPanel.Width - 90, minimizeBtn.Location.Y);
            maximizeBtn.Location = new Point(controlPanel.Width - 65, maximizeBtn.Location.Y);
            closeBtn.Location = new Point(controlPanel.Width - 40, closeBtn.Location.Y);

            deleteBtn.Location = new Point(controlPanel.Width - 120, minimizeBtn.Location.Y + 25);
            settingBtn.Location = new Point(deleteBtn.Location.X - settingBtn.Width - 10, deleteBtn.Location.Y);
            settingPanel.Location = new Point(settingBtn.Location.X + settingBtn.Width - settingPanel.Width, settingBtn.Location.Y + settingBtn.Height + 10);

            saveBtn.Location = new Point(saveBtn.Location.X, DataGridView1.Location.Y + DataGridView1.Height - saveBtn.Height);
            openBtn.Location = new Point(saveBtn.Location.X, saveBtn.Location.Y - openBtn.Height - 10);

            if (this.WindowState == FormWindowState.Maximized)
            {
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.normal;
            }
            else
            {
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.maximize;
            }
        }        

        //-------------------------------------ControlPanel-------------------------------------
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackgroundImage = AlphaIMS.Properties.Resources.close_dark;
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.maximize;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.normal;
            }
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackgroundImage = AlphaIMS.Properties.Resources.close;
        }

        private void minimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            minimizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.minimize_dark;
        }

        private void minimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            minimizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.minimize;
        }

        private void maximizeBtn_MouseEnter(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.normal_dark;
            }
            else
            {
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.maximize_dark;
            }
        }

        private void maximizeBtn_MouseLeave(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.normal;
            }
            else
            {
                maximizeBtn.BackgroundImage = AlphaIMS.Properties.Resources.maximize;
            }
        }


        //-------------------------------------Product Setting-------------------------------------
        private void stationComboBox_GotFocus(object sender, EventArgs e)
        {
            stationComboBox.Items.Clear();

            List<string> stations = new List<string>();
            Sqlite.SelectAllStation(ref stations);

            foreach (string station in stations)
            {
                stationComboBox.Items.Add(station);
            }

            stations.Clear();
            stations = null;
        }

        private void stationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView1.Rows.Clear();
            DataGridView1.Columns.Clear();
            modelComboBox.Items.Clear();
            modelComboBox.Text = "";
            customerComboBox.Items.Clear();
            customerComboBox.Text = "";
        }

        private void stationComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!LoginForm.Login)
                e.Handled = true;
        }

        private void modelComboBox_GotFocus(object sender, EventArgs e)
        {
            modelComboBox.Items.Clear();
            if (stationComboBox.Text != "")
            {
                List<string> models = new List<string>();
                Sqlite.SelectAllModelNum(stationComboBox.Text, ref models);

                foreach (string modelNum in models)
                {
                    modelComboBox.Items.Add(modelNum);
                }

                models.Clear();
                models = null;
            }
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView1.Rows.Clear();
            DataGridView1.Columns.Clear();
            customerComboBox.Items.Clear();
            customerComboBox.Text = "";
        }

        private void modelComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!LoginForm.Login)
                e.Handled = true;
        }

        private void customerComboBox_GotFocus(object sender, EventArgs e)
        {
            customerComboBox.Items.Clear();

            if (stationComboBox.Text != "" && modelComboBox.Text != "")
            {
                List<string> customers = new List<string>();
                Sqlite.SelectAllCustomer(stationComboBox.Text, modelComboBox.Text, ref customers);

                foreach (string customer in customers)
                {
                    customerComboBox.Items.Add(customer);
                }

                customers.Clear();
                customers = null;
            }
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stationComboBox.Text != "" && modelComboBox.Text != "")
            {
                int rows = 0;
                int columns = 0;
                TABLECOLUMN tableCol;

                tableColList.Clear();
                DataGridView1.Rows.Clear();
                DataGridView1.Columns.Clear();

                Sqlite.SelectColumnsInfo(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, ref tableColList);
                Sqlite.SelectRowsColumns(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, ref rows, ref columns);
                DataGridView1.ColumnCount = columns;

                int size = Convert.ToInt32(DataGridView1.DefaultCellStyle.Font.Size);

                for (int i = 0; i < columns; i++) 
                {
                    if (i < tableColList.Count)
                    {
                        tableCol = tableColList[i];
                    }
                    else
                    {
                        tableCol = new TABLECOLUMN();
                        tableColList.Add(tableCol);
                    }

                    if (tableCol.Readvalue == 4)
                        DataGridView1.Columns[i].Width = size * 10;
                    else
                        DataGridView1.Columns[i].Width = size * 6;

                    DataGridView1.Columns[i].Name = tableCol.Name;
                    DataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int i = 0; i < rows; i++)
                {
                    string[] row = new string[columns];
                    DataGridView1.Rows.Add(row);
                    DataGridView1.Rows[i].Height = size + 15;
                    DataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

                this.ActiveControl = DataGridView1;
            }
        }

        private void customerComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TABLECOLUMN tableCol;
            if (e.KeyChar == (Char)13)
            {
                if (stationComboBox.Text != "" && modelComboBox.Text != "" && customerComboBox.Text != "")
                {
                    if (Sqlite.SelectProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text) == 1)
                        return;

                    tableColList.Clear();
                    DataGridView1.Rows.Clear();
                    DataGridView1.Columns.Clear();

                    DataGridView1.ColumnCount = 10;
                    int size = Convert.ToInt32(DataGridView1.DefaultCellStyle.Font.Size);

                    for (int i = 0; i < DataGridView1.ColumnCount; i++)
                    {            
                        DataGridView1.Columns[i].Width = size * 6;
                        DataGridView1.Columns[i].Name = Convert.ToChar(i + 65).ToString();
                        DataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                        tableCol = new TABLECOLUMN();
                        tableCol.Name = DataGridView1.Columns[i].Name;

                        tableColList.Add(tableCol);
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        DataGridView1.Rows.Add("");
                        DataGridView1.Rows[i].Height = size + 15;
                        DataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    }

                    DataGridView1.CurrentCell.Selected = false;

                    int rows = DataGridView1.Rows.Count;
                    int columns = DataGridView1.Columns.Count;

                    Sqlite.InsertProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, rows, columns);
                    for (int i = 0; i < tableColList.Count; i++)
                    {
                        tableCol = tableColList[i];
                        Sqlite.InsertColumnInfo(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, i, tableCol);
                    }

                    this.ActiveControl = DataGridView1;
                }
            }
            else
            {
                if (!LoginForm.Login)
                    e.Handled = true;
            }
        }


        //-------------------------------------Measure Setting-------------------------------------
        private void measureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void lotnumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void dateTextBox_Enter(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void dateTextBox_Leave(object sender, EventArgs e)
        {
            if (!monthCalendar1.Focused)
                monthCalendar1.Visible = false;
        }

        private void dateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var monthCalendar = sender as MonthCalendar;
            dateTextBox.Text = string.Format("{0:yyyyMMdd}", monthCalendar.SelectionStart);
            monthCalendar.Visible = false;
            this.SelectNextControl((Control)sender, true, true, true, true);
        }

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            var monthCalendar = sender as MonthCalendar;
            monthCalendar.Visible = false;
        }


        //-------------------------------------DataGridView Event-------------------------------------
        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectHeaderRowIndex = -1;
                if (DataGridView1.Rows[e.RowIndex].HeaderCell.Value != null)
                {
                    SelectHeaderRowIndex = e.RowIndex;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectHeaderColumnIndex = e.ColumnIndex;
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void DataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var cellRectangle = DataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            
            TABLECOLUMN tableCol = tableColList[e.ColumnIndex];
            DataGridView1.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromArgb(72, 180, 225);

            int locationX = this.Location.X + DataGridView1.Location.X + cellRectangle.Location.X + 5;
            int locationY = this.Location.Y + DataGridView1.Location.Y + cellRectangle.Location.Y + cellRectangle.Height + 30;

            ColumnForm form = new ColumnForm(e.ColumnIndex, locationX, locationY, tableCol);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                tableCol.Name = form.ReturnName;
                tableCol.Formula = form.ReturnFormula;
                tableCol.Min = form.ReturnMin;
                tableCol.Max = form.ReturnMax;
                tableCol.Readvalue = form.ReturnReadvalue;
                tableColList[e.ColumnIndex] = tableCol;

                Sqlite.UpdateColumnsInfo(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, e.ColumnIndex, tableCol);

                DataGridView1.Columns[e.ColumnIndex].Name = tableCol.Name;

                int size = Convert.ToInt32(DataGridView1.DefaultCellStyle.Font.Size);

                if(tableCol.Readvalue == 4)
                    DataGridView1.Columns[e.ColumnIndex].Width = size * 10;
                else
                    DataGridView1.Columns[e.ColumnIndex].Width = size * 6;
            }

            DataGridView1.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = SystemColors.Control;
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectHeaderRowIndex > -1)
            {
                DataGridView1.Rows.Insert(SelectHeaderRowIndex);

                for (int i = 0; i < DataGridView1.RowCount; i++)
                    DataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                SelectHeaderRowIndex = -1;

                Sqlite.UpdateProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, DataGridView1.RowCount, DataGridView1.ColumnCount);
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectHeaderRowIndex > -1)
            {
                if (stationComboBox.Text != "" && modelComboBox.Text != "" && customerComboBox.Text != "")
                {
                    DataGridView1.Rows.RemoveAt(SelectHeaderRowIndex);

                    for (int i = 0; i < DataGridView1.RowCount; i++)
                        DataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                    Sqlite.UpdateProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, DataGridView1.RowCount, DataGridView1.ColumnCount);
                }
                SelectHeaderRowIndex = -1;
             }
        }

        private void addColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectHeaderColumnIndex > -1)
            {
                if (stationComboBox.Text != "" && modelComboBox.Text != "" && customerComboBox.Text != "")
                {
                    TABLECOLUMN tableCol = new TABLECOLUMN();
                    tableCol.Name = "New";

                    DataGridViewColumn dtCol = new DataGridViewColumn();
                    dtCol.Name = "New";
                    dtCol.Width = 60;
                    dtCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dtCol.CellTemplate = new DataGridViewTextBoxCell();

                    DataGridView1.Columns.Insert(SelectHeaderColumnIndex, dtCol);

                    tableColList.Insert(SelectHeaderColumnIndex, tableCol);
                    Sqlite.InsertColumnInfo(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, SelectHeaderColumnIndex, tableCol);
                    Sqlite.UpdateProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, DataGridView1.RowCount, DataGridView1.ColumnCount);
                }

                SelectHeaderColumnIndex = -1;
            }
        }

        private void deleteColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectHeaderColumnIndex > -1)
            {
                if (stationComboBox.Text != "" && modelComboBox.Text != "" && customerComboBox.Text != "")
                {
                    tableColList.RemoveAt(SelectHeaderColumnIndex);
                    DataGridView1.Columns.RemoveAt(SelectHeaderColumnIndex);

                    Sqlite.DeleteColumnInfo(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, SelectHeaderColumnIndex);
                    Sqlite.UpdateProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, DataGridView1.RowCount, DataGridView1.ColumnCount);
                }

                SelectHeaderColumnIndex = -1;  
            }
        }


        //-------------------------------------Button Event-------------------------------------
        private void VerticalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ActiveControl = DataGridView1;
        }

        private void HorizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.ActiveControl = DataGridView1;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择表格", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stationComboBox.Text == "")
            {
                MessageBox.Show("请输入站別", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (modelComboBox.Text == "")
            {
                MessageBox.Show("请输入产品型号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (customerComboBox.Text == "")
            {
                MessageBox.Show("请输入客戶別", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lotnumberTextBox.Text == "")
            {
                MessageBox.Show("请输入批号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (machineIdTextBox.Text == "")
            {
                MessageBox.Show("请输入机台编号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int locationX = saveBtn.Location.X + saveBtn.Width + 10;
            int locationY = saveBtn.Location.Y;
            InAdditionForm form = new InAdditionForm(locationX, locationY);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Application.UseWaitCursor = true;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents(); //<-- IMPORTANT 

                string filename = _filepath + String.Format("\\{0}_{1}_{2}_{3}_{4}_{5:yyyyMMddHHmm}.xls", lotnumberTextBox.Text, machineIdTextBox.Text, stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, DateTime.Now);

                saveDataToDB();
                saveFileToExcel(filename);
                if (form.ReturnMailList != "")
                {
                    SendMail(form.ReturnMailList, filename);
                }

                for (int i = 0; i < DataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < DataGridView1.Columns.Count; j++)
                    {
                        DataGridView1[j, i].Value = "";
                    }
                }

                Application.UseWaitCursor = false;
                this.Cursor = Cursors.Default;
                Application.DoEvents(); //<-- IMPORTANT
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (DataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择表格", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stationComboBox.Text == "")
            {
                MessageBox.Show("请输入站別", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (modelComboBox.Text == "")
            {
                MessageBox.Show("请输入产品型号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (customerComboBox.Text == "")
            {
                MessageBox.Show("请输入客戶別", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定删除表格啊?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Sqlite.DeleteProduct(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text);
                for (int i = 0; i < tableColList.Count; i++)
                    Sqlite.DeleteColumnInfo(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, i);

                DataGridView1.Rows.Clear();
                DataGridView1.Columns.Clear();
                stationComboBox.Text = "";
                modelComboBox.Text = "";
                customerComboBox.Text = "";
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                openBtn.Text = "连接设备";
                serialPortBox.Enabled = true;
                cbBaudRateBox.Enabled = true;
            }
            else
            {
                try
                {
                    serialPort1.Open();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("开启失败!\n是否被其他程序开启?\n(" + ")", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.RtsEnable = true;
                        serialPort1.DtrEnable = true;
                        serialPort1.WriteTimeout = 2000;
                        serialPort1.ReadTimeout = 2000;

                        if (serialPort1.BaudRate == 4800)
                            serialPort1.WriteLine("SXYZ" + (char)0x0D);

                        openBtn.Text = "断开设备";
                        serialPortBox.Enabled = false;
                        cbBaudRateBox.Enabled = false;

                        this.ActiveControl = DataGridView1;
                    }
                }
            }
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            settingPanel.Visible = !settingPanel.Visible;

            if (settingPanel.Visible)
            {
                serialPortBox.Text = serialPort1.PortName;

                if (serialPort1.BaudRate == 4800)
                    cbBaudRateBox.SelectedIndex = 0;
                else
                    cbBaudRateBox.SelectedIndex = 1;

                fontComboBox.Text = Convert.ToInt32(DataGridView1.DefaultCellStyle.Font.Size).ToString();
            }
            else
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = serialPortBox.Text;

                    if (cbBaudRateBox.SelectedIndex == 0)
                        serialPort1.BaudRate = 4800;
                    else
                        serialPort1.BaudRate = 9600;
                }

                int oldSize = Convert.ToInt32(DataGridView1.DefaultCellStyle.Font.Size);
                int newSize;

                if (fontComboBox.Text != "")
                {
                    if (Int32.TryParse(fontComboBox.Text, out newSize))
                        DataGridView1.DefaultCellStyle.Font = new Font("Microsoft JhengHei", newSize);
                    else
                        newSize = oldSize;

                    int columns = DataGridView1.Columns.Count;
                    int rows = DataGridView1.Rows.Count;

                    for (int i = 0; i < columns; i++)
                        DataGridView1.Columns[i].Width = (DataGridView1.Columns[i].Width / oldSize) * newSize;

                    for (int j = 0; j < rows; j++)
                    {
                        DataGridView1.Rows[j].Height = newSize + 15;
                    }
                }

                string xmlFile = Application.StartupPath + "\\Setting.xml";
                if (File.Exists(xmlFile))
                {
                    XmlDocument doc;
                    XmlNode nameNode;
                    XmlNode baudrateNode;
                    XmlNode fontNode;

                    doc = new XmlDocument();
                    doc.Load(xmlFile);
                    nameNode = doc.DocumentElement.SelectSingleNode("/Setting/SerialPort/Name");
                    if (nameNode != null)
                        nameNode.InnerText = serialPort1.PortName;

                    baudrateNode = doc.DocumentElement.SelectSingleNode("/Setting/SerialPort/BaudRate");
                    if (baudrateNode != null)
                        baudrateNode.InnerText = serialPort1.BaudRate.ToString();

                    fontNode = doc.DocumentElement.SelectSingleNode("/Setting/Font");
                    if (fontNode != null)
                        fontNode.InnerText = Convert.ToInt32(DataGridView1.DefaultCellStyle.Font.Size).ToString();

                    doc.Save(xmlFile);
                }
            }
        }

        private void securityBtn_Click(object sender, EventArgs e)
        {
            int locationX = securityBtn.Location.X;
            int locationY = controlPanel.Location.Y + controlPanel.Height;
            LoginForm form = new LoginForm(locationX, locationY);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (LoginForm.Login)
                {
                    userLabel.Text = form.ReturnUser;
                    securityBtn.BackgroundImage = AlphaIMS.Properties.Resources.security_logined;
                    deleteBtn.Enabled = true;
                }
                else
                {
                    userLabel.Text = "";
                    securityBtn.BackgroundImage = AlphaIMS.Properties.Resources.security;
                    deleteBtn.Enabled = false;
                }
            }
        }

        private void securityBtn_MouseEnter(object sender, EventArgs e)
        {
            if (!LoginForm.Login)
                securityBtn.BackgroundImage = AlphaIMS.Properties.Resources.security_dark;
        }

        private void securityBtn_MouseLeave(object sender, EventArgs e)
        {
            if (!LoginForm.Login)
                securityBtn.BackgroundImage = AlphaIMS.Properties.Resources.security;
        }

        //-------------------------------------Serial Port-------------------------------------
        private void fontComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= (Char)48 && e.KeyChar <= (Char)57)
                e.Handled = false;
        } 

        private void serialPortBox_GotFocus(object sender, EventArgs e)
        {
            string[] AvailableCOMPorts;

            this.serialPortBox.Items.Clear();

            AvailableCOMPorts = System.IO.Ports.SerialPort.GetPortNames();

            for (int j = 0; j < AvailableCOMPorts.Length; j++)
            {
                this.serialPortBox.Items.Add(AvailableCOMPorts[j]);
            }
        }

        private void serialPortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = serialPortBox.Text;
        }

        private void serialPortBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbBaudRateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBaudRateBox.SelectedIndex == 0)
                serialPort1.BaudRate = 4800;
            else
                serialPort1.BaudRate = 9600;
        }

        private void cbBaudRateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
       
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string readline = "";
            
            if (serialPort1.IsOpen)
            {
                try
                {
                    readline = serialPort1.ReadLine();
                }
                catch (Exception ex)
                {
                    EventLog.Write(ex.Message);
                }
                finally
                {
                    this.BeginInvoke(new EventHandler(delegate
                    {
                        if (DataGridView1.CurrentCell != null)
                        {
                            int column = DataGridView1.CurrentCell.ColumnIndex;
                            int row = DataGridView1.CurrentCell.RowIndex;

                            string value = GetValue(readline, column, row);
                            DataGridView1.CurrentCell.Value = value;
                            DataGridView1.CurrentCell.Selected = false;
                            
                            RefreshFormula(row);

                            NextValue(ref row, ref column);    
                            DataGridView1.CurrentCell = DataGridView1[column, row];
                            DataGridView1.CurrentCell.Selected = true;

                            if(serialPort1.BaudRate == 4800)
                                serialPort1.WriteLine("SXYZ" + (char)0x0D);
                        }
                    }));
                    //Application.DoEvents();
                }
            }
        }


        //-------------------------------------Other-------------------------------------
        private string GetValue(string readline, int column, int row)
        {
            TABLECOLUMN tableCol = tableColList[column];
            double value = 0.0;
            double valueX = 0.0;
            double valueY = 0.0;
            double valueZ = 0.0;
            string alpha = "";
            string result = "0.0";

            if (serialPort1.BaudRate == 9600)
            {
                string[] lines = readline.Split('Y');

                if (lines.Length >= 2)
                {
                    Double.TryParse(Regex.Replace(lines[0].Trim(), "[^0-9.]", ""), out valueX);

                    lines = lines[1].Split('Q');
                    Double.TryParse(Regex.Replace(lines[0].Trim(), "[^0-9.]", ""), out valueY);

                    result = valueX.ToString("f3");
                    if (tableCol != null)
                    {
                        switch (tableCol.Readvalue)
                        {
                            case 0: //read x
                                value = valueX;
                                break;

                            case 1: //read y
                                value = valueY;
                                break;

                            case 4: //read alpha
                                alpha = lines[1].Trim('-');
                                result = alpha;
                                break;
                        }
                    }
                }
            }
            else
            {
                string[] lines = readline.Split(',');

                if (lines.Length >= 3)
                {
                    Double.TryParse(Regex.Replace(lines[0].Trim(), "[^0-9.]", ""), out valueX);
                    Double.TryParse(Regex.Replace(lines[1].Trim(), "[^0-9.]", ""), out valueY);
                    Double.TryParse(Regex.Replace(lines[2].Trim(), "[^0-9.]", ""), out valueZ);

                    result = valueX.ToString("f3");
                    if (tableCol != null)
                    {
                        switch (tableCol.Readvalue)
                        {
                            case 0: //read x
                                value = valueX;
                                break;

                            case 1: //read y
                                value = valueY;
                                break;

                            case 2: //read alpha
                                value = valueZ;
                                break;
                        }
                    }
                }
            }
 
            if (tableCol != null && alpha == "")
            {
                result = value.ToString("f3");
                if (value < tableCol.Min || value > tableCol.Max)
                {
                    DataGridView1[column, row].Style.ForeColor = Color.Red;
                }
                else
                {
                    DataGridView1[column, row].Style.ForeColor = Color.Black;
                }
            }

            return result;
        }

        private void NextValue(ref int row, ref int column)
        {
            if (row == DataGridView1.Rows.Count - 1 && column == DataGridView1.Columns.Count - 1)
                return;

            TABLECOLUMN tableCol;

            if (VerticalRadioButton.Checked)
            {
                if (row >= DataGridView1.Rows.Count - 1)
                {
                    while ((column + 1) <= DataGridView1.Columns.Count - 1)
                    {
                        column++;
                        row = 0;
                        tableCol = tableColList[column];

                        if (tableCol.Formula == "")
                        {
                            break;
                        }
                        else
                        {
                            row = DataGridView1.Rows.Count - 1;
                        }
                    }       
                }
                else
                {
                    row++;
                }
            }
            else
            {
                if (column >= DataGridView1.Columns.Count - 1)
                {
                    if (row < DataGridView1.Rows.Count - 1)
                    {
                        row++;
                        column = 0;
                    }
                }
                else
                {
                    column++;
                }

                tableCol = tableColList[column];

                if (tableCol.Formula != "")
                {
                    if (column >= DataGridView1.Columns.Count - 1)
                    {
                        if (row < DataGridView1.Rows.Count - 1)
                        {
                            row++;
                            column = 0;
                        }
                    }
                    else
                    {
                        column++;
                    }
                }
            }
        }

        private void RefreshFormula(int row)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameter = new CompilerParameters();
            parameter.ReferencedAssemblies.Add("System.dll");
            parameter.GenerateExecutable = false;
            parameter.GenerateInMemory = true;
            CompilerResults result;

            TABLECOLUMN tableCol;
            string line;
            double value;

            for (int i = 0; i < tableColList.Count; i++ )
            {
                tableCol = tableColList[i];

                if (tableCol.Formula == "")
                    continue;

                value = 0.00;
                line = "";
                for (int j = 0; j < tableCol.Formula.Length; j++)
                {
                    int asciie = Convert.ToInt32(tableCol.Formula[j]) - 65;
                    if (asciie >= 0 && asciie <= 25 && asciie < DataGridView1.Columns.Count)
                    {
                        if (DataGridView1[asciie, row].FormattedValue.ToString() == "")
                            line += "0.0";
                        else
                            line += DataGridView1[asciie, row].FormattedValue.ToString();
                    }
                    else
                    {
                        line += tableCol.Formula[j];
                    }
                }

                result = provider.CompileAssemblyFromSource(parameter, CreateCode(line));

                if (result.Errors.Count == 0)
                {
                    Assembly assembly = result.CompiledAssembly;
                    Type AType = assembly.GetType("ANameSpace.AClass");
                    MethodInfo method = AType.GetMethod("AFunc");

                    Double.TryParse(method.Invoke(null, null).ToString(), out value);
                }

                DataGridView1[i, row].Value = value.ToString("f3");

                if (value < tableCol.Min || value > tableCol.Max)
                {
                    DataGridView1[i, row].Style.ForeColor = Color.Red;
                }
                else
                {
                    DataGridView1[i, row].Style.ForeColor = Color.Black;
                }
            }
        }

        private string CreateCode(string para)
        {
            return "using System; namespace ANameSpace{static class AClass{public static object AFunc(){return " + para + ";}}}";
        }

        private void saveDataToDB()
        {
            string result = "";
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < DataGridView1.Columns.Count; j++)
                {
                    result += DataGridView1[j, i].FormattedValue.ToString();

                    if (j == DataGridView1.Columns.Count - 1)
                        result += "\r\n";
                    else
                        result += ",";
                }
            }

            Sqlite.InsertData(stationComboBox.Text, modelComboBox.Text, customerComboBox.Text, result, string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now)); 
        }

        private void saveFileToExcel(string filename)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(true);

                Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlApp.ActiveSheet;
                Excel.Range xlRange = xlWorksheet.UsedRange;

                for (int i = 0; i < DataGridView1.ColumnCount; i++)
                {
                    xlRange = (Excel.Range)xlWorksheet.Cells[1, i + 1];
                    xlRange.Value2 = DataGridView1.Columns[i].HeaderText;

                    xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                for (int j = 0; j < DataGridView1.RowCount; j++)
                {
                    for (int i = 0; i < DataGridView1.ColumnCount; i++)
                    {
                        xlRange = (Excel.Range)xlWorksheet.Cells[j + 2, i + 1];

                        if (DataGridView1[i, j].Value == null)
                        {
                            xlRange.Value2 = "0.0";
                        }
                        else
                        {
                            xlRange.Value2 = DataGridView1[i, j].Value.ToString();
                            xlRange.Font.Color = System.Drawing.ColorTranslator.ToOle(DataGridView1[i, j].Style.ForeColor);
                            DataGridView1[i, j].Value = "";
                        }

                        xlRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }

                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //if (printer)
                //xlWorkbook.PrintOut(1, 1, 1, false, true, false, true, filename);

                if (xlApp != null)
                {
                    xlWorkbook.Close(Type.Missing, filename, Type.Missing);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorksheet);
                    Marshal.ReleaseComObject(xlWorkbook);
                    Marshal.ReleaseComObject(xlApp);
                    xlWorksheet = null;
                    xlWorkbook = null;
                    xlApp = null;
                }

                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendMail(string toMail, string filename)
        {
            string subject;
            string fromMail = "system@zktech.com.cn";

            if (serialPort1.BaudRate == 9600)
            {
                subject = "Helios 350V's table";
            }
            else
            {
                subject = "Nikon SC-213's table";
            }

            MailMessage message = new MailMessage(fromMail, toMail);//MailMessage(寄信者, 收信者)
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;//E-mail編碼
            message.Subject = subject;//E-mail主旨
            message.Body = "";//E-mail內容
            message.Priority = MailPriority.High;
            message.Attachments.Add(new Attachment(filename));

            SmtpClient smtp = new SmtpClient("mailgate.zktech.com.cn");
            //smtp.EnableSsl = true;

            try
            {
                smtp.Send(message);
                MessageBox.Show("邮件已发送", "资讯", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
	}    
}