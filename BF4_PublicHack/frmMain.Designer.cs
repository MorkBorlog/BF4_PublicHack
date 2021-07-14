namespace BF4_PublicHack
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cBoxESP_Enemys = new System.Windows.Forms.CheckBox();
            this.gBoxESP = new System.Windows.Forms.GroupBox();
            this.cBoxESP_Enemys_Distance = new System.Windows.Forms.CheckBox();
            this.cBoxESP_Enemys_Healthbar = new System.Windows.Forms.CheckBox();
            this.cBoxESP_Enemys_Lines = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBoxESP_Friends_Distance = new System.Windows.Forms.CheckBox();
            this.cBoxESP_Friends_Healthbar = new System.Windows.Forms.CheckBox();
            this.cBoxESP_Friends_Lines = new System.Windows.Forms.CheckBox();
            this.cBoxESP_Friends = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBoxShowInfos = new System.Windows.Forms.CheckBox();
            this.cBoxNoRecoil = new System.Windows.Forms.CheckBox();
            this.cBoxAimbot = new System.Windows.Forms.CheckBox();
            this.linkThread = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gBoxESP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(165, 126);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(315, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "RUN THIS YELLOW SHIT";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            this.btnRun.MouseLeave += new System.EventHandler(this.btnRun_MouseLeave);
            this.btnRun.MouseHover += new System.EventHandler(this.btnRun_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BF4_PublicHack.Properties.Resources.Yellow;
            this.pictureBox1.Location = new System.Drawing.Point(9, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cBoxESP_Enemys
            // 
            this.cBoxESP_Enemys.AutoSize = true;
            this.cBoxESP_Enemys.Location = new System.Drawing.Point(6, 23);
            this.cBoxESP_Enemys.Name = "cBoxESP_Enemys";
            this.cBoxESP_Enemys.Size = new System.Drawing.Size(47, 17);
            this.cBoxESP_Enemys.TabIndex = 1;
            this.cBoxESP_Enemys.Text = "ESP";
            this.cBoxESP_Enemys.UseVisualStyleBackColor = true;
            this.cBoxESP_Enemys.CheckedChanged += new System.EventHandler(this.cBoxESP_Enemys_CheckedChanged);
            // 
            // gBoxESP
            // 
            this.gBoxESP.Controls.Add(this.cBoxESP_Enemys_Distance);
            this.gBoxESP.Controls.Add(this.cBoxESP_Enemys_Healthbar);
            this.gBoxESP.Controls.Add(this.cBoxESP_Enemys_Lines);
            this.gBoxESP.Controls.Add(this.cBoxESP_Enemys);
            this.gBoxESP.Location = new System.Drawing.Point(165, 7);
            this.gBoxESP.Name = "gBoxESP";
            this.gBoxESP.Size = new System.Drawing.Size(101, 113);
            this.gBoxESP.TabIndex = 3;
            this.gBoxESP.TabStop = false;
            this.gBoxESP.Text = "ENEMYS";
            // 
            // cBoxESP_Enemys_Distance
            // 
            this.cBoxESP_Enemys_Distance.AutoSize = true;
            this.cBoxESP_Enemys_Distance.Location = new System.Drawing.Point(6, 89);
            this.cBoxESP_Enemys_Distance.Name = "cBoxESP_Enemys_Distance";
            this.cBoxESP_Enemys_Distance.Size = new System.Drawing.Size(92, 17);
            this.cBoxESP_Enemys_Distance.TabIndex = 1;
            this.cBoxESP_Enemys_Distance.Text = "Distance Text";
            this.cBoxESP_Enemys_Distance.UseVisualStyleBackColor = true;
            this.cBoxESP_Enemys_Distance.CheckedChanged += new System.EventHandler(this.cBoxESP_Enemys_Distance_CheckedChanged);
            // 
            // cBoxESP_Enemys_Healthbar
            // 
            this.cBoxESP_Enemys_Healthbar.AutoSize = true;
            this.cBoxESP_Enemys_Healthbar.Location = new System.Drawing.Point(6, 67);
            this.cBoxESP_Enemys_Healthbar.Name = "cBoxESP_Enemys_Healthbar";
            this.cBoxESP_Enemys_Healthbar.Size = new System.Drawing.Size(72, 17);
            this.cBoxESP_Enemys_Healthbar.TabIndex = 1;
            this.cBoxESP_Enemys_Healthbar.Text = "Healthbar";
            this.cBoxESP_Enemys_Healthbar.UseVisualStyleBackColor = true;
            this.cBoxESP_Enemys_Healthbar.CheckedChanged += new System.EventHandler(this.cBoxESP_Enemys_Healthbar_CheckedChanged);
            // 
            // cBoxESP_Enemys_Lines
            // 
            this.cBoxESP_Enemys_Lines.AutoSize = true;
            this.cBoxESP_Enemys_Lines.Location = new System.Drawing.Point(6, 45);
            this.cBoxESP_Enemys_Lines.Name = "cBoxESP_Enemys_Lines";
            this.cBoxESP_Enemys_Lines.Size = new System.Drawing.Size(51, 17);
            this.cBoxESP_Enemys_Lines.TabIndex = 1;
            this.cBoxESP_Enemys_Lines.Text = "Lines";
            this.cBoxESP_Enemys_Lines.UseVisualStyleBackColor = true;
            this.cBoxESP_Enemys_Lines.CheckedChanged += new System.EventHandler(this.cBoxESP_Enemys_Lines_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBoxESP_Friends_Distance);
            this.groupBox1.Controls.Add(this.cBoxESP_Friends_Healthbar);
            this.groupBox1.Controls.Add(this.cBoxESP_Friends_Lines);
            this.groupBox1.Controls.Add(this.cBoxESP_Friends);
            this.groupBox1.Location = new System.Drawing.Point(272, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 113);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FRIENDS";
            // 
            // cBoxESP_Friends_Distance
            // 
            this.cBoxESP_Friends_Distance.AutoSize = true;
            this.cBoxESP_Friends_Distance.Location = new System.Drawing.Point(6, 89);
            this.cBoxESP_Friends_Distance.Name = "cBoxESP_Friends_Distance";
            this.cBoxESP_Friends_Distance.Size = new System.Drawing.Size(92, 17);
            this.cBoxESP_Friends_Distance.TabIndex = 1;
            this.cBoxESP_Friends_Distance.Text = "Distance Text";
            this.cBoxESP_Friends_Distance.UseVisualStyleBackColor = true;
            this.cBoxESP_Friends_Distance.CheckedChanged += new System.EventHandler(this.cBoxESP_Friends_Distance_CheckedChanged);
            // 
            // cBoxESP_Friends_Healthbar
            // 
            this.cBoxESP_Friends_Healthbar.AutoSize = true;
            this.cBoxESP_Friends_Healthbar.Location = new System.Drawing.Point(6, 67);
            this.cBoxESP_Friends_Healthbar.Name = "cBoxESP_Friends_Healthbar";
            this.cBoxESP_Friends_Healthbar.Size = new System.Drawing.Size(72, 17);
            this.cBoxESP_Friends_Healthbar.TabIndex = 1;
            this.cBoxESP_Friends_Healthbar.Text = "Healthbar";
            this.cBoxESP_Friends_Healthbar.UseVisualStyleBackColor = true;
            this.cBoxESP_Friends_Healthbar.CheckedChanged += new System.EventHandler(this.cBoxESP_Friends_Healthbar_CheckedChanged);
            // 
            // cBoxESP_Friends_Lines
            // 
            this.cBoxESP_Friends_Lines.AutoSize = true;
            this.cBoxESP_Friends_Lines.Location = new System.Drawing.Point(6, 45);
            this.cBoxESP_Friends_Lines.Name = "cBoxESP_Friends_Lines";
            this.cBoxESP_Friends_Lines.Size = new System.Drawing.Size(51, 17);
            this.cBoxESP_Friends_Lines.TabIndex = 1;
            this.cBoxESP_Friends_Lines.Text = "Lines";
            this.cBoxESP_Friends_Lines.UseVisualStyleBackColor = true;
            this.cBoxESP_Friends_Lines.CheckedChanged += new System.EventHandler(this.cBoxESP_Friends_Lines_CheckedChanged);
            // 
            // cBoxESP_Friends
            // 
            this.cBoxESP_Friends.AutoSize = true;
            this.cBoxESP_Friends.Location = new System.Drawing.Point(6, 23);
            this.cBoxESP_Friends.Name = "cBoxESP_Friends";
            this.cBoxESP_Friends.Size = new System.Drawing.Size(47, 17);
            this.cBoxESP_Friends.TabIndex = 1;
            this.cBoxESP_Friends.Text = "ESP";
            this.cBoxESP_Friends.UseVisualStyleBackColor = true;
            this.cBoxESP_Friends.CheckedChanged += new System.EventHandler(this.cBoxESP_Friends_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBoxShowInfos);
            this.groupBox2.Controls.Add(this.cBoxNoRecoil);
            this.groupBox2.Controls.Add(this.cBoxAimbot);
            this.groupBox2.Location = new System.Drawing.Point(379, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 113);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GLOBAL";
            // 
            // cBoxShowInfos
            // 
            this.cBoxShowInfos.AutoSize = true;
            this.cBoxShowInfos.Location = new System.Drawing.Point(6, 67);
            this.cBoxShowInfos.Name = "cBoxShowInfos";
            this.cBoxShowInfos.Size = new System.Drawing.Size(83, 17);
            this.cBoxShowInfos.TabIndex = 1;
            this.cBoxShowInfos.Text = "Target Infos";
            this.cBoxShowInfos.UseVisualStyleBackColor = true;
            this.cBoxShowInfos.CheckedChanged += new System.EventHandler(this.cBoxShowInfos_CheckedChanged);
            // 
            // cBoxNoRecoil
            // 
            this.cBoxNoRecoil.AutoSize = true;
            this.cBoxNoRecoil.Location = new System.Drawing.Point(6, 45);
            this.cBoxNoRecoil.Name = "cBoxNoRecoil";
            this.cBoxNoRecoil.Size = new System.Drawing.Size(73, 17);
            this.cBoxNoRecoil.TabIndex = 1;
            this.cBoxNoRecoil.Text = "No Recoil";
            this.cBoxNoRecoil.UseVisualStyleBackColor = true;
            this.cBoxNoRecoil.CheckedChanged += new System.EventHandler(this.cBoxNoRecoil_CheckedChanged);
            // 
            // cBoxAimbot
            // 
            this.cBoxAimbot.AutoSize = true;
            this.cBoxAimbot.Location = new System.Drawing.Point(6, 23);
            this.cBoxAimbot.Name = "cBoxAimbot";
            this.cBoxAimbot.Size = new System.Drawing.Size(58, 17);
            this.cBoxAimbot.TabIndex = 1;
            this.cBoxAimbot.Text = "Aimbot";
            this.cBoxAimbot.UseVisualStyleBackColor = true;
            this.cBoxAimbot.CheckedChanged += new System.EventHandler(this.cBoxAimbot_CheckedChanged);
            // 
            // linkThread
            // 
            this.linkThread.AutoSize = true;
            this.linkThread.Location = new System.Drawing.Point(172, 150);
            this.linkThread.Name = "linkThread";
            this.linkThread.Size = new System.Drawing.Size(294, 13);
            this.linkThread.TabIndex = 5;
            this.linkThread.TabStop = true;
            this.linkThread.Text = "Yellow1982 by UnknownCheats.me - Public Free Hack V 0.4";
            this.linkThread.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkThread.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkThread_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 167);
            this.Controls.Add(this.linkThread);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gBoxESP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gBoxESP.ResumeLayout(false);
            this.gBoxESP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cBoxESP_Enemys;
        private System.Windows.Forms.GroupBox gBoxESP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cBoxESP_Friends_Lines;
        private System.Windows.Forms.CheckBox cBoxESP_Friends;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cBoxNoRecoil;
        private System.Windows.Forms.CheckBox cBoxAimbot;
        private System.Windows.Forms.CheckBox cBoxESP_Enemys_Healthbar;
        private System.Windows.Forms.CheckBox cBoxESP_Enemys_Lines;
        private System.Windows.Forms.CheckBox cBoxESP_Enemys_Distance;
        private System.Windows.Forms.CheckBox cBoxShowInfos;
        private System.Windows.Forms.CheckBox cBoxESP_Friends_Distance;
        private System.Windows.Forms.CheckBox cBoxESP_Friends_Healthbar;
        private System.Windows.Forms.LinkLabel linkThread;
    }
}

