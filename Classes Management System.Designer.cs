namespace WindowsFormsApp1
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.attendanceBtn = new FontAwesome.Sharp.IconButton();
            this.markBtn = new FontAwesome.Sharp.IconButton();
            this.rubriclevelBtn = new FontAwesome.Sharp.IconButton();
            this.assessmentsBtn = new FontAwesome.Sharp.IconButton();
            this.managerubricsBtn = new FontAwesome.Sharp.IconButton();
            this.managecloBtn = new FontAwesome.Sharp.IconButton();
            this.managestudentBtn = new FontAwesome.Sharp.IconButton();
            this.genReportBtn = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.HomeBtn = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.assessmentCompBtn = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeBtn)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(105)))));
            this.panelMenu.Controls.Add(this.assessmentCompBtn);
            this.panelMenu.Controls.Add(this.attendanceBtn);
            this.panelMenu.Controls.Add(this.markBtn);
            this.panelMenu.Controls.Add(this.rubriclevelBtn);
            this.panelMenu.Controls.Add(this.assessmentsBtn);
            this.panelMenu.Controls.Add(this.managerubricsBtn);
            this.panelMenu.Controls.Add(this.managecloBtn);
            this.panelMenu.Controls.Add(this.managestudentBtn);
            this.panelMenu.Controls.Add(this.genReportBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 807);
            this.panelMenu.TabIndex = 0;
            // 
            // attendanceBtn
            // 
            this.attendanceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attendanceBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.attendanceBtn.FlatAppearance.BorderSize = 0;
            this.attendanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attendanceBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.attendanceBtn.IconChar = FontAwesome.Sharp.IconChar.P;
            this.attendanceBtn.IconColor = System.Drawing.Color.White;
            this.attendanceBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.attendanceBtn.IconSize = 64;
            this.attendanceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attendanceBtn.Location = new System.Drawing.Point(0, 651);
            this.attendanceBtn.Name = "attendanceBtn";
            this.attendanceBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.attendanceBtn.Size = new System.Drawing.Size(250, 73);
            this.attendanceBtn.TabIndex = 8;
            this.attendanceBtn.Text = "Attendence";
            this.attendanceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.attendanceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.attendanceBtn.UseVisualStyleBackColor = true;
            this.attendanceBtn.Click += new System.EventHandler(this.attendanceBtn_Click);
            // 
            // markBtn
            // 
            this.markBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.markBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.markBtn.FlatAppearance.BorderSize = 0;
            this.markBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.markBtn.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.markBtn.IconColor = System.Drawing.Color.White;
            this.markBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.markBtn.IconSize = 64;
            this.markBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.markBtn.Location = new System.Drawing.Point(0, 578);
            this.markBtn.Name = "markBtn";
            this.markBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.markBtn.Size = new System.Drawing.Size(250, 73);
            this.markBtn.TabIndex = 7;
            this.markBtn.Text = "Mark";
            this.markBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.markBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.markBtn.UseVisualStyleBackColor = true;
            this.markBtn.Click += new System.EventHandler(this.markBtn_Click);
            // 
            // rubriclevelBtn
            // 
            this.rubriclevelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rubriclevelBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.rubriclevelBtn.FlatAppearance.BorderSize = 0;
            this.rubriclevelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rubriclevelBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.rubriclevelBtn.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.rubriclevelBtn.IconColor = System.Drawing.Color.White;
            this.rubriclevelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.rubriclevelBtn.IconSize = 64;
            this.rubriclevelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rubriclevelBtn.Location = new System.Drawing.Point(0, 505);
            this.rubriclevelBtn.Name = "rubriclevelBtn";
            this.rubriclevelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.rubriclevelBtn.Size = new System.Drawing.Size(250, 73);
            this.rubriclevelBtn.TabIndex = 6;
            this.rubriclevelBtn.Text = "Rubric Levels";
            this.rubriclevelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rubriclevelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rubriclevelBtn.UseVisualStyleBackColor = true;
            this.rubriclevelBtn.Click += new System.EventHandler(this.rubriclevelBtn_Click);
            // 
            // assessmentsBtn
            // 
            this.assessmentsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assessmentsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.assessmentsBtn.FlatAppearance.BorderSize = 0;
            this.assessmentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assessmentsBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.assessmentsBtn.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.assessmentsBtn.IconColor = System.Drawing.Color.White;
            this.assessmentsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.assessmentsBtn.IconSize = 64;
            this.assessmentsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assessmentsBtn.Location = new System.Drawing.Point(0, 432);
            this.assessmentsBtn.Name = "assessmentsBtn";
            this.assessmentsBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.assessmentsBtn.Size = new System.Drawing.Size(250, 73);
            this.assessmentsBtn.TabIndex = 5;
            this.assessmentsBtn.Text = "Assessment";
            this.assessmentsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assessmentsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.assessmentsBtn.UseVisualStyleBackColor = true;
            this.assessmentsBtn.Click += new System.EventHandler(this.assessmentsBtn_Click);
            // 
            // managerubricsBtn
            // 
            this.managerubricsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.managerubricsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.managerubricsBtn.FlatAppearance.BorderSize = 0;
            this.managerubricsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managerubricsBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.managerubricsBtn.IconChar = FontAwesome.Sharp.IconChar.AlignJustify;
            this.managerubricsBtn.IconColor = System.Drawing.Color.White;
            this.managerubricsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.managerubricsBtn.IconSize = 64;
            this.managerubricsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerubricsBtn.Location = new System.Drawing.Point(0, 359);
            this.managerubricsBtn.Name = "managerubricsBtn";
            this.managerubricsBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.managerubricsBtn.Size = new System.Drawing.Size(250, 73);
            this.managerubricsBtn.TabIndex = 4;
            this.managerubricsBtn.Text = "Rubrics";
            this.managerubricsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.managerubricsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.managerubricsBtn.UseVisualStyleBackColor = true;
            this.managerubricsBtn.Click += new System.EventHandler(this.managerubricsBtn_Click);
            // 
            // managecloBtn
            // 
            this.managecloBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.managecloBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.managecloBtn.FlatAppearance.BorderSize = 0;
            this.managecloBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managecloBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.managecloBtn.IconChar = FontAwesome.Sharp.IconChar.DiceD6;
            this.managecloBtn.IconColor = System.Drawing.Color.White;
            this.managecloBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.managecloBtn.IconSize = 64;
            this.managecloBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.managecloBtn.Location = new System.Drawing.Point(0, 286);
            this.managecloBtn.Name = "managecloBtn";
            this.managecloBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.managecloBtn.Size = new System.Drawing.Size(250, 73);
            this.managecloBtn.TabIndex = 3;
            this.managecloBtn.Text = "CLOs";
            this.managecloBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.managecloBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.managecloBtn.UseVisualStyleBackColor = true;
            this.managecloBtn.Click += new System.EventHandler(this.managecloBtn_Click);
            // 
            // managestudentBtn
            // 
            this.managestudentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.managestudentBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.managestudentBtn.FlatAppearance.BorderSize = 0;
            this.managestudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managestudentBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.managestudentBtn.IconChar = FontAwesome.Sharp.IconChar.PeopleRoof;
            this.managestudentBtn.IconColor = System.Drawing.Color.White;
            this.managestudentBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.managestudentBtn.IconSize = 64;
            this.managestudentBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.managestudentBtn.Location = new System.Drawing.Point(0, 213);
            this.managestudentBtn.Name = "managestudentBtn";
            this.managestudentBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.managestudentBtn.Size = new System.Drawing.Size(250, 73);
            this.managestudentBtn.TabIndex = 2;
            this.managestudentBtn.Text = "Students";
            this.managestudentBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.managestudentBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.managestudentBtn.UseVisualStyleBackColor = true;
            this.managestudentBtn.Click += new System.EventHandler(this.managestudentBtn_Click);
            // 
            // genReportBtn
            // 
            this.genReportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.genReportBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.genReportBtn.FlatAppearance.BorderSize = 0;
            this.genReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genReportBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.genReportBtn.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.genReportBtn.IconColor = System.Drawing.Color.White;
            this.genReportBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.genReportBtn.IconSize = 64;
            this.genReportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.genReportBtn.Location = new System.Drawing.Point(0, 140);
            this.genReportBtn.Name = "genReportBtn";
            this.genReportBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.genReportBtn.Size = new System.Drawing.Size(250, 73);
            this.genReportBtn.TabIndex = 1;
            this.genReportBtn.Text = "Reports";
            this.genReportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.genReportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.genReportBtn.UseVisualStyleBackColor = true;
            this.genReportBtn.Click += new System.EventHandler(this.dashboardBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.HomeBtn);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // HomeBtn
            // 
            this.HomeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("HomeBtn.Image")));
            this.HomeBtn.Location = new System.Drawing.Point(12, 12);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(224, 106);
            this.HomeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HomeBtn.TabIndex = 0;
            this.HomeBtn.TabStop = false;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(105)))));
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(250, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1104, 80);
            this.panelTitleBar.TabIndex = 1;
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.White;
            this.lblTitleChildForm.Location = new System.Drawing.Point(82, 34);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(52, 20);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(105)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.SteelBlue;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.SteelBlue;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 50;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(36, 23);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(50, 50);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(73)))), ((int)(((byte)(143)))));
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Controls.Add(this.label2);
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(250, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1104, 727);
            this.panelDesktop.TabIndex = 2;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(440, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(485, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(460, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // assessmentCompBtn
            // 
            this.assessmentCompBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.assessmentCompBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.assessmentCompBtn.FlatAppearance.BorderSize = 0;
            this.assessmentCompBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assessmentCompBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.assessmentCompBtn.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.assessmentCompBtn.IconColor = System.Drawing.Color.White;
            this.assessmentCompBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.assessmentCompBtn.IconSize = 64;
            this.assessmentCompBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assessmentCompBtn.Location = new System.Drawing.Point(0, 724);
            this.assessmentCompBtn.Name = "assessmentCompBtn";
            this.assessmentCompBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.assessmentCompBtn.Size = new System.Drawing.Size(250, 73);
            this.assessmentCompBtn.TabIndex = 9;
            this.assessmentCompBtn.Text = "Assessment Components";
            this.assessmentCompBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assessmentCompBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.assessmentCompBtn.UseVisualStyleBackColor = true;
            this.assessmentCompBtn.Click += new System.EventHandler(this.assessmentCompBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 807);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1376, 860);
            this.Name = "Form1";
            this.Text = "Classes Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HomeBtn)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton genReportBtn;
        private System.Windows.Forms.PictureBox HomeBtn;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton markBtn;
        private FontAwesome.Sharp.IconButton rubriclevelBtn;
        private FontAwesome.Sharp.IconButton assessmentsBtn;
        private FontAwesome.Sharp.IconButton managerubricsBtn;
        private FontAwesome.Sharp.IconButton managecloBtn;
        private FontAwesome.Sharp.IconButton managestudentBtn;
        private FontAwesome.Sharp.IconButton attendanceBtn;
        private FontAwesome.Sharp.IconButton assessmentCompBtn;
    }
}

