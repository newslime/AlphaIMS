namespace AlphaIMS
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lotnumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.machineIdTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.productGroupBox = new System.Windows.Forms.GroupBox();
            this.stationComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.measureGroupBox = new System.Windows.Forms.GroupBox();
            this.HorizontalRadioButton = new System.Windows.Forms.RadioButton();
            this.VerticalRadioButton = new System.Windows.Forms.RadioButton();
            this.measureTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openBtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbBaudRateBox = new System.Windows.Forms.ComboBox();
            this.serialPortBox = new System.Windows.Forms.ComboBox();
            this.settingPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.fontComboBox = new System.Windows.Forms.ComboBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.securityBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.maximizeBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.saveBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.productGroupBox.SuspendLayout();
            this.measureGroupBox.SuspendLayout();
            this.settingPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Image = global::AlphaIMS.Properties.Resources.add;
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.addRowToolStripMenuItem.Text = "新增行";
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Image = global::AlphaIMS.Properties.Resources.delete;
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteRowToolStripMenuItem.Text = "删除行";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.EnableHeadersVisualStyles = false;
            this.DataGridView1.Location = new System.Drawing.Point(201, 71);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView1.Name = "DataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(880, 500);
            this.DataGridView1.TabIndex = 0;
            this.DataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_ColumnHeaderMouseDoubleClick);
            this.DataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_ColumnHeaderMouseClick);
            this.DataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColumnToolStripMenuItem,
            this.deleteColumnToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(116, 48);
            // 
            // addColumnToolStripMenuItem
            // 
            this.addColumnToolStripMenuItem.Image = global::AlphaIMS.Properties.Resources.add;
            this.addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
            this.addColumnToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.addColumnToolStripMenuItem.Text = "新增列";
            this.addColumnToolStripMenuItem.Click += new System.EventHandler(this.addColumnToolStripMenuItem_Click);
            // 
            // deleteColumnToolStripMenuItem
            // 
            this.deleteColumnToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deleteColumnToolStripMenuItem.Image = global::AlphaIMS.Properties.Resources.delete;
            this.deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            this.deleteColumnToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.deleteColumnToolStripMenuItem.Text = "刪除列";
            this.deleteColumnToolStripMenuItem.Click += new System.EventHandler(this.deleteColumnToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "机台编号:";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(15, 160);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(145, 25);
            this.dateTextBox.TabIndex = 8;
            this.dateTextBox.Leave += new System.EventHandler(this.dateTextBox_Leave);
            this.dateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTextBox_KeyPress);
            this.dateTextBox.Enter += new System.EventHandler(this.dateTextBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "日期/班次:";
            // 
            // lotnumberTextBox
            // 
            this.lotnumberTextBox.Location = new System.Drawing.Point(15, 100);
            this.lotnumberTextBox.Name = "lotnumberTextBox";
            this.lotnumberTextBox.Size = new System.Drawing.Size(145, 25);
            this.lotnumberTextBox.TabIndex = 7;
            this.lotnumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lotnumberTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "批号:";
            // 
            // machineIdTextBox
            // 
            this.machineIdTextBox.Location = new System.Drawing.Point(15, 220);
            this.machineIdTextBox.Name = "machineIdTextBox";
            this.machineIdTextBox.Size = new System.Drawing.Size(145, 25);
            this.machineIdTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "客户别";
            // 
            // modelComboBox
            // 
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(15, 100);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(145, 25);
            this.modelComboBox.TabIndex = 4;
            this.modelComboBox.SelectedIndexChanged += new System.EventHandler(this.modelComboBox_SelectedIndexChanged);
            this.modelComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.modelComboBox_KeyPress);
            this.modelComboBox.GotFocus += new System.EventHandler(this.modelComboBox_GotFocus);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "产品型号";
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(15, 160);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(145, 25);
            this.customerComboBox.TabIndex = 5;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            this.customerComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customerComboBox_KeyPress);
            this.customerComboBox.GotFocus += new System.EventHandler(this.customerComboBox_GotFocus);
            // 
            // productGroupBox
            // 
            this.productGroupBox.Controls.Add(this.stationComboBox);
            this.productGroupBox.Controls.Add(this.label7);
            this.productGroupBox.Controls.Add(this.customerComboBox);
            this.productGroupBox.Controls.Add(this.label6);
            this.productGroupBox.Controls.Add(this.modelComboBox);
            this.productGroupBox.Controls.Add(this.label5);
            this.productGroupBox.ForeColor = System.Drawing.Color.White;
            this.productGroupBox.Location = new System.Drawing.Point(10, 75);
            this.productGroupBox.Name = "productGroupBox";
            this.productGroupBox.Size = new System.Drawing.Size(180, 200);
            this.productGroupBox.TabIndex = 21;
            this.productGroupBox.TabStop = false;
            this.productGroupBox.Text = "产品讯息设置";
            // 
            // stationComboBox
            // 
            this.stationComboBox.FormattingEnabled = true;
            this.stationComboBox.Location = new System.Drawing.Point(15, 40);
            this.stationComboBox.Name = "stationComboBox";
            this.stationComboBox.Size = new System.Drawing.Size(145, 25);
            this.stationComboBox.TabIndex = 3;
            this.stationComboBox.SelectedIndexChanged += new System.EventHandler(this.stationComboBox_SelectedIndexChanged);
            this.stationComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stationComboBox_KeyPress);
            this.stationComboBox.GotFocus += new System.EventHandler(this.stationComboBox_GotFocus);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "站別";
            // 
            // measureGroupBox
            // 
            this.measureGroupBox.Controls.Add(this.HorizontalRadioButton);
            this.measureGroupBox.Controls.Add(this.VerticalRadioButton);
            this.measureGroupBox.Controls.Add(this.measureTextBox);
            this.measureGroupBox.Controls.Add(this.label1);
            this.measureGroupBox.Controls.Add(this.lotnumberTextBox);
            this.measureGroupBox.Controls.Add(this.label2);
            this.measureGroupBox.Controls.Add(this.machineIdTextBox);
            this.measureGroupBox.Controls.Add(this.label4);
            this.measureGroupBox.Controls.Add(this.label3);
            this.measureGroupBox.Controls.Add(this.dateTextBox);
            this.measureGroupBox.ForeColor = System.Drawing.Color.White;
            this.measureGroupBox.Location = new System.Drawing.Point(10, 290);
            this.measureGroupBox.Name = "measureGroupBox";
            this.measureGroupBox.Size = new System.Drawing.Size(180, 290);
            this.measureGroupBox.TabIndex = 22;
            this.measureGroupBox.TabStop = false;
            this.measureGroupBox.Text = "量测设置";
            // 
            // HorizontalRadioButton
            // 
            this.HorizontalRadioButton.AutoSize = true;
            this.HorizontalRadioButton.Location = new System.Drawing.Point(80, 260);
            this.HorizontalRadioButton.Name = "HorizontalRadioButton";
            this.HorizontalRadioButton.Size = new System.Drawing.Size(52, 21);
            this.HorizontalRadioButton.TabIndex = 16;
            this.HorizontalRadioButton.Text = "横向";
            this.HorizontalRadioButton.UseVisualStyleBackColor = true;
            this.HorizontalRadioButton.CheckedChanged += new System.EventHandler(this.HorizontalRadioButton_CheckedChanged);
            // 
            // VerticalRadioButton
            // 
            this.VerticalRadioButton.AutoSize = true;
            this.VerticalRadioButton.Checked = true;
            this.VerticalRadioButton.Location = new System.Drawing.Point(15, 260);
            this.VerticalRadioButton.Name = "VerticalRadioButton";
            this.VerticalRadioButton.Size = new System.Drawing.Size(52, 21);
            this.VerticalRadioButton.TabIndex = 15;
            this.VerticalRadioButton.TabStop = true;
            this.VerticalRadioButton.Text = "纵向";
            this.VerticalRadioButton.UseVisualStyleBackColor = true;
            this.VerticalRadioButton.CheckedChanged += new System.EventHandler(this.VerticalRadioButton_CheckedChanged);
            // 
            // measureTextBox
            // 
            this.measureTextBox.Location = new System.Drawing.Point(15, 40);
            this.measureTextBox.Name = "measureTextBox";
            this.measureTextBox.Size = new System.Drawing.Size(145, 25);
            this.measureTextBox.TabIndex = 6;
            this.measureTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.measureTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "测量人";
            // 
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.Color.White;
            this.openBtn.FlatAppearance.BorderSize = 0;
            this.openBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openBtn.Location = new System.Drawing.Point(12, 621);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(180, 30);
            this.openBtn.TabIndex = 15;
            this.openBtn.Text = "连接设备";
            this.openBtn.UseVisualStyleBackColor = false;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(175, 450);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "波特率";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "串行接口";
            // 
            // cbBaudRateBox
            // 
            this.cbBaudRateBox.FormattingEnabled = true;
            this.cbBaudRateBox.Items.AddRange(new object[] {
            "Nikon SC-213/4800",
            "Helios 350V/9600"});
            this.cbBaudRateBox.Location = new System.Drawing.Point(12, 85);
            this.cbBaudRateBox.Name = "cbBaudRateBox";
            this.cbBaudRateBox.Size = new System.Drawing.Size(145, 25);
            this.cbBaudRateBox.TabIndex = 2;
            this.cbBaudRateBox.SelectedIndexChanged += new System.EventHandler(this.cbBaudRateBox_SelectedIndexChanged);
            this.cbBaudRateBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbBaudRateBox_KeyPress);
            // 
            // serialPortBox
            // 
            this.serialPortBox.FormattingEnabled = true;
            this.serialPortBox.Location = new System.Drawing.Point(12, 30);
            this.serialPortBox.Name = "serialPortBox";
            this.serialPortBox.Size = new System.Drawing.Size(145, 25);
            this.serialPortBox.TabIndex = 1;
            this.serialPortBox.SelectedIndexChanged += new System.EventHandler(this.serialPortBox_SelectedIndexChanged);
            this.serialPortBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialPortBox_KeyPress);
            this.serialPortBox.GotFocus += new System.EventHandler(this.serialPortBox_GotFocus);
            // 
            // settingPanel
            // 
            this.settingPanel.Controls.Add(this.label10);
            this.settingPanel.Controls.Add(this.fontComboBox);
            this.settingPanel.Controls.Add(this.label9);
            this.settingPanel.Controls.Add(this.cbBaudRateBox);
            this.settingPanel.Controls.Add(this.label8);
            this.settingPanel.Controls.Add(this.serialPortBox);
            this.settingPanel.Location = new System.Drawing.Point(919, 76);
            this.settingPanel.Name = "settingPanel";
            this.settingPanel.Size = new System.Drawing.Size(170, 180);
            this.settingPanel.TabIndex = 29;
            this.settingPanel.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(15, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "字型大小";
            // 
            // fontComboBox
            // 
            this.fontComboBox.FormattingEnabled = true;
            this.fontComboBox.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.fontComboBox.Location = new System.Drawing.Point(15, 140);
            this.fontComboBox.Name = "fontComboBox";
            this.fontComboBox.Size = new System.Drawing.Size(50, 25);
            this.fontComboBox.TabIndex = 4;
            this.fontComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fontComboBox_KeyPress);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.ForeColor = System.Drawing.Color.White;
            this.userLabel.Location = new System.Drawing.Point(220, 25);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(34, 17);
            this.userLabel.TabIndex = 5;
            this.userLabel.Text = "登入";
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.logoPictureBox);
            this.controlPanel.Controls.Add(this.securityBtn);
            this.controlPanel.Controls.Add(this.minimizeBtn);
            this.controlPanel.Controls.Add(this.userLabel);
            this.controlPanel.Controls.Add(this.maximizeBtn);
            this.controlPanel.Controls.Add(this.deleteBtn);
            this.controlPanel.Controls.Add(this.closeBtn);
            this.controlPanel.Controls.Add(this.settingBtn);
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1082, 70);
            this.controlPanel.TabIndex = 30;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::AlphaIMS.Properties.Resources.logo;
            this.logoPictureBox.Location = new System.Drawing.Point(20, 20);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(150, 31);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // securityBtn
            // 
            this.securityBtn.BackgroundImage = global::AlphaIMS.Properties.Resources.security;
            this.securityBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.securityBtn.FlatAppearance.BorderSize = 0;
            this.securityBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.securityBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.securityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.securityBtn.Location = new System.Drawing.Point(185, 20);
            this.securityBtn.Name = "securityBtn";
            this.securityBtn.Size = new System.Drawing.Size(25, 25);
            this.securityBtn.TabIndex = 4;
            this.securityBtn.UseVisualStyleBackColor = true;
            this.securityBtn.Click += new System.EventHandler(this.securityBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackgroundImage = global::AlphaIMS.Properties.Resources.minimize;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Location = new System.Drawing.Point(991, 20);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(20, 20);
            this.minimizeBtn.TabIndex = 2;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.minimizeBtn_MouseLeave);
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.minimizeBtn_MouseEnter);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.BackgroundImage = global::AlphaIMS.Properties.Resources.maximize;
            this.maximizeBtn.FlatAppearance.BorderSize = 0;
            this.maximizeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.maximizeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeBtn.Location = new System.Drawing.Point(1017, 20);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(20, 20);
            this.maximizeBtn.TabIndex = 3;
            this.maximizeBtn.UseVisualStyleBackColor = true;
            this.maximizeBtn.MouseLeave += new System.EventHandler(this.maximizeBtn_MouseLeave);
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeBtn_Click);
            this.maximizeBtn.MouseEnter += new System.EventHandler(this.maximizeBtn_MouseEnter);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Transparent;
            this.deleteBtn.BackgroundImage = global::AlphaIMS.Properties.Resources.table_delete;
            this.deleteBtn.Enabled = false;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Location = new System.Drawing.Point(956, 44);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(20, 20);
            this.deleteBtn.TabIndex = 32;
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImage = global::AlphaIMS.Properties.Resources.close;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(1047, 20);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(20, 20);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.closeBtn_MouseEnter);
            // 
            // settingBtn
            // 
            this.settingBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingBtn.BackgroundImage = global::AlphaIMS.Properties.Resources.setting;
            this.settingBtn.FlatAppearance.BorderSize = 0;
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Location = new System.Drawing.Point(919, 44);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(20, 20);
            this.settingBtn.TabIndex = 27;
            this.settingBtn.UseVisualStyleBackColor = false;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.White;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(10, 660);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(180, 30);
            this.saveBtn.TabIndex = 33;
            this.saveBtn.Text = "储存及发送";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 702);
            this.ControlBox = false;
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.measureGroupBox);
            this.Controls.Add(this.productGroupBox);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.settingPanel);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.openBtn);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AlphaIMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.productGroupBox.ResumeLayout(false);
            this.productGroupBox.PerformLayout();
            this.measureGroupBox.ResumeLayout(false);
            this.measureGroupBox.PerformLayout();
            this.settingPanel.ResumeLayout(false);
            this.settingPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addColumnToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lotnumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox machineIdTextBox;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.GroupBox productGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox stationComboBox;
        private System.Windows.Forms.GroupBox measureGroupBox;
        private System.Windows.Forms.Button openBtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox measureTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbBaudRateBox;
        private System.Windows.Forms.ComboBox serialPortBox;
        private System.Windows.Forms.RadioButton VerticalRadioButton;
        private System.Windows.Forms.RadioButton HorizontalRadioButton;
        private System.Windows.Forms.Panel settingPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Button maximizeBtn;
        private System.Windows.Forms.Button securityBtn;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button saveBtn;
        public System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox fontComboBox;
	}
}

