namespace xscj
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.dGVXmCj = new System.Windows.Forms.DataGridView();
            this.btnDelCj = new System.Windows.Forms.Button();
            this.btnInsCj = new System.Windows.Forms.Button();
            this.btnQueCj = new System.Windows.Forms.Button();
            this.tBxCj = new System.Windows.Forms.TextBox();
            this.tBxName = new System.Windows.Forms.TextBox();
            this.cBxKcm = new System.Windows.Forms.ComboBox();
            this.kCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSKcm = new xscj.DSKcm();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.dGVKcCj = new System.Windows.Forms.DataGridView();
            this.tBxKcs = new System.Windows.Forms.TextBox();
            this.tBxXm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQue = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this.pBxZp = new System.Windows.Forms.PictureBox();
            this.dTPCssj = new System.Windows.Forms.DateTimePicker();
            this.rBtnFemale = new System.Windows.Forms.RadioButton();
            this.rBtnMale = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kCTableAdapter = new xscj.DSKcmTableAdapters.KCTableAdapter();
            this.dSKcmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVXmCj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSKcm)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVKcCj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBxZp)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSKcmBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.OldLace;
            this.tabPage2.Controls.Add(this.lblMsg2);
            this.tabPage2.Controls.Add(this.dGVXmCj);
            this.tabPage2.Controls.Add(this.btnDelCj);
            this.tabPage2.Controls.Add(this.btnInsCj);
            this.tabPage2.Controls.Add(this.btnQueCj);
            this.tabPage2.Controls.Add(this.tBxCj);
            this.tabPage2.Controls.Add(this.tBxName);
            this.tabPage2.Controls.Add(this.cBxKcm);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(675, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "成绩管理";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // lblMsg2
            // 
            this.lblMsg2.AutoSize = true;
            this.lblMsg2.Location = new System.Drawing.Point(67, 315);
            this.lblMsg2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(0, 15);
            this.lblMsg2.TabIndex = 10;
            // 
            // dGVXmCj
            // 
            this.dGVXmCj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVXmCj.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVXmCj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVXmCj.Location = new System.Drawing.Point(69, 164);
            this.dGVXmCj.Margin = new System.Windows.Forms.Padding(4);
            this.dGVXmCj.Name = "dGVXmCj";
            this.dGVXmCj.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGVXmCj.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVXmCj.RowTemplate.Height = 23;
            this.dGVXmCj.Size = new System.Drawing.Size(363, 122);
            this.dGVXmCj.TabIndex = 9;
            this.dGVXmCj.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVXmCj_CellContentClick);
            // 
            // btnDelCj
            // 
            this.btnDelCj.Location = new System.Drawing.Point(365, 108);
            this.btnDelCj.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelCj.Name = "btnDelCj";
            this.btnDelCj.Size = new System.Drawing.Size(67, 29);
            this.btnDelCj.TabIndex = 8;
            this.btnDelCj.Text = "删除";
            this.btnDelCj.UseVisualStyleBackColor = true;
            this.btnDelCj.Click += new System.EventHandler(this.btnDelCj_Click);
            // 
            // btnInsCj
            // 
            this.btnInsCj.Location = new System.Drawing.Point(299, 108);
            this.btnInsCj.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsCj.Name = "btnInsCj";
            this.btnInsCj.Size = new System.Drawing.Size(67, 29);
            this.btnInsCj.TabIndex = 7;
            this.btnInsCj.Text = "录入";
            this.btnInsCj.UseVisualStyleBackColor = true;
            this.btnInsCj.Click += new System.EventHandler(this.btnInsCj_Click);
            // 
            // btnQueCj
            // 
            this.btnQueCj.Location = new System.Drawing.Point(299, 30);
            this.btnQueCj.Margin = new System.Windows.Forms.Padding(4);
            this.btnQueCj.Name = "btnQueCj";
            this.btnQueCj.Size = new System.Drawing.Size(67, 29);
            this.btnQueCj.TabIndex = 6;
            this.btnQueCj.Text = "查询";
            this.btnQueCj.UseVisualStyleBackColor = true;
            this.btnQueCj.Click += new System.EventHandler(this.btnQueCj_Click);
            // 
            // tBxCj
            // 
            this.tBxCj.Location = new System.Drawing.Point(129, 110);
            this.tBxCj.Margin = new System.Windows.Forms.Padding(4);
            this.tBxCj.Name = "tBxCj";
            this.tBxCj.Size = new System.Drawing.Size(160, 25);
            this.tBxCj.TabIndex = 5;
            // 
            // tBxName
            // 
            this.tBxName.Location = new System.Drawing.Point(129, 71);
            this.tBxName.Margin = new System.Windows.Forms.Padding(4);
            this.tBxName.Name = "tBxName";
            this.tBxName.Size = new System.Drawing.Size(160, 25);
            this.tBxName.TabIndex = 4;
            // 
            // cBxKcm
            // 
            this.cBxKcm.DataSource = this.kCBindingSource;
            this.cBxKcm.DisplayMember = "KCM";
            this.cBxKcm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBxKcm.FormattingEnabled = true;
            this.cBxKcm.Location = new System.Drawing.Point(129, 32);
            this.cBxKcm.Margin = new System.Windows.Forms.Padding(4);
            this.cBxKcm.Name = "cBxKcm";
            this.cBxKcm.Size = new System.Drawing.Size(160, 23);
            this.cBxKcm.TabIndex = 3;
            this.cBxKcm.ValueMember = "KCM";
            this.cBxKcm.SelectedIndexChanged += new System.EventHandler(this.cBxKcm_SelectedIndexChanged);
            // 
            // kCBindingSource
            // 
            this.kCBindingSource.DataMember = "KC";
            this.kCBindingSource.DataSource = this.dSKcm;
            // 
            // dSKcm
            // 
            this.dSKcm.DataSetName = "DSKcm";
            this.dSKcm.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(67, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "成  绩";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "姓  名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "课程名";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Linen;
            this.tabPage1.Controls.Add(this.lblMsg1);
            this.tabPage1.Controls.Add(this.dGVKcCj);
            this.tabPage1.Controls.Add(this.tBxKcs);
            this.tabPage1.Controls.Add(this.tBxXm);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnQue);
            this.tabPage1.Controls.Add(this.btnUpd);
            this.tabPage1.Controls.Add(this.btnDel);
            this.tabPage1.Controls.Add(this.btnIns);
            this.tabPage1.Controls.Add(this.btnLoadPic);
            this.tabPage1.Controls.Add(this.pBxZp);
            this.tabPage1.Controls.Add(this.dTPCssj);
            this.tabPage1.Controls.Add(this.rBtnFemale);
            this.tabPage1.Controls.Add(this.rBtnMale);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(675, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "学生管理";
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.Location = new System.Drawing.Point(496, 316);
            this.lblMsg1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(0, 15);
            this.lblMsg1.TabIndex = 17;
            // 
            // dGVKcCj
            // 
            this.dGVKcCj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGVKcCj.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dGVKcCj.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dGVKcCj.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVKcCj.Location = new System.Drawing.Point(352, 105);
            this.dGVKcCj.Margin = new System.Windows.Forms.Padding(4);
            this.dGVKcCj.Name = "dGVKcCj";
            this.dGVKcCj.ReadOnly = true;
            this.dGVKcCj.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGVKcCj.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVKcCj.RowTemplate.Height = 23;
            this.dGVKcCj.Size = new System.Drawing.Size(256, 148);
            this.dGVKcCj.TabIndex = 16;
            // 
            // tBxKcs
            // 
            this.tBxKcs.BackColor = System.Drawing.Color.LightGray;
            this.tBxKcs.Enabled = false;
            this.tBxKcs.Location = new System.Drawing.Point(428, 71);
            this.tBxKcs.Margin = new System.Windows.Forms.Padding(4);
            this.tBxKcs.Name = "tBxKcs";
            this.tBxKcs.ReadOnly = true;
            this.tBxKcs.Size = new System.Drawing.Size(132, 25);
            this.tBxKcs.TabIndex = 15;
            // 
            // tBxXm
            // 
            this.tBxXm.Location = new System.Drawing.Point(153, 32);
            this.tBxXm.Margin = new System.Windows.Forms.Padding(4);
            this.tBxXm.Name = "tBxXm";
            this.tBxXm.Size = new System.Drawing.Size(132, 25);
            this.tBxXm.TabIndex = 4;
            this.tBxXm.TextChanged += new System.EventHandler(this.tBxXm_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "已修课程";
            // 
            // btnQue
            // 
            this.btnQue.Location = new System.Drawing.Point(353, 310);
            this.btnQue.Margin = new System.Windows.Forms.Padding(4);
            this.btnQue.Name = "btnQue";
            this.btnQue.Size = new System.Drawing.Size(67, 29);
            this.btnQue.TabIndex = 13;
            this.btnQue.Text = "查询";
            this.btnQue.UseVisualStyleBackColor = true;
            this.btnQue.Click += new System.EventHandler(this.btnQue_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.Location = new System.Drawing.Point(287, 310);
            this.btnUpd.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(67, 29);
            this.btnUpd.TabIndex = 12;
            this.btnUpd.Text = "更新";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(220, 310);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(67, 29);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(153, 310);
            this.btnIns.Margin = new System.Windows.Forms.Padding(4);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(67, 29);
            this.btnIns.TabIndex = 10;
            this.btnIns.Text = "录入";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.Location = new System.Drawing.Point(273, 274);
            this.btnLoadPic.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(79, 29);
            this.btnLoadPic.TabIndex = 9;
            this.btnLoadPic.Text = "浏览...";
            this.btnLoadPic.UseVisualStyleBackColor = true;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // pBxZp
            // 
            this.pBxZp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBxZp.Location = new System.Drawing.Point(153, 152);
            this.pBxZp.Margin = new System.Windows.Forms.Padding(4);
            this.pBxZp.Name = "pBxZp";
            this.pBxZp.Size = new System.Drawing.Size(119, 150);
            this.pBxZp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBxZp.TabIndex = 8;
            this.pBxZp.TabStop = false;
            // 
            // dTPCssj
            // 
            this.dTPCssj.Location = new System.Drawing.Point(153, 106);
            this.dTPCssj.Margin = new System.Windows.Forms.Padding(4);
            this.dTPCssj.Name = "dTPCssj";
            this.dTPCssj.Size = new System.Drawing.Size(141, 25);
            this.dTPCssj.TabIndex = 7;
            // 
            // rBtnFemale
            // 
            this.rBtnFemale.AutoSize = true;
            this.rBtnFemale.Location = new System.Drawing.Point(240, 72);
            this.rBtnFemale.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnFemale.Name = "rBtnFemale";
            this.rBtnFemale.Size = new System.Drawing.Size(43, 19);
            this.rBtnFemale.TabIndex = 6;
            this.rBtnFemale.Text = "女";
            this.rBtnFemale.UseVisualStyleBackColor = true;
            // 
            // rBtnMale
            // 
            this.rBtnMale.AutoSize = true;
            this.rBtnMale.Checked = true;
            this.rBtnMale.Location = new System.Drawing.Point(153, 72);
            this.rBtnMale.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnMale.Name = "rBtnMale";
            this.rBtnMale.Size = new System.Drawing.Size(43, 19);
            this.rBtnMale.TabIndex = 5;
            this.rBtnMale.TabStop = true;
            this.rBtnMale.Text = "男";
            this.rBtnMale.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "照片:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "出生年月:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 82);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 391);
            this.tabControl1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 481);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(683, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // kCTableAdapter
            // 
            this.kCTableAdapter.ClearBeforeFill = true;
            // 
            // dSKcmBindingSource
            // 
            this.dSKcmBindingSource.DataSource = this.dSKcm;
            this.dSKcmBindingSource.Position = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(684, 509);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "学生成绩管理系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVXmCj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSKcm)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVKcCj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBxZp)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSKcmBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMsg2;
        private System.Windows.Forms.DataGridView dGVXmCj;
        private System.Windows.Forms.Button btnDelCj;
        private System.Windows.Forms.Button btnInsCj;
        private System.Windows.Forms.Button btnQueCj;
        private System.Windows.Forms.TextBox tBxCj;
        private System.Windows.Forms.TextBox tBxName;
        private System.Windows.Forms.ComboBox cBxKcm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.DataGridView dGVKcCj;
        private System.Windows.Forms.TextBox tBxKcs;
        private System.Windows.Forms.TextBox tBxXm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQue;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.PictureBox pBxZp;
        private System.Windows.Forms.DateTimePicker dTPCssj;
        private System.Windows.Forms.RadioButton rBtnFemale;
        private System.Windows.Forms.RadioButton rBtnMale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.BindingSource kCBindingSource;
        private DSKcm dSKcm;
        private DSKcmTableAdapters.KCTableAdapter kCTableAdapter;
        private System.Windows.Forms.BindingSource dSKcmBindingSource;
    }
}

