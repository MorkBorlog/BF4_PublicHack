namespace BF4_PublicHack
{
    partial class frmOverlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pBoxOverlay = new System.Windows.Forms.PictureBox();
            this.tESP = new System.Windows.Forms.Timer(this.components);
            this.tAimbot = new System.Windows.Forms.Timer(this.components);
            this.tGameChecker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOverlay)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxOverlay
            // 
            this.pBoxOverlay.BackColor = System.Drawing.Color.Black;
            this.pBoxOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxOverlay.Location = new System.Drawing.Point(0, 0);
            this.pBoxOverlay.Name = "pBoxOverlay";
            this.pBoxOverlay.Size = new System.Drawing.Size(111, 70);
            this.pBoxOverlay.TabIndex = 0;
            this.pBoxOverlay.TabStop = false;
            // 
            // tESP
            // 
            this.tESP.Interval = 60;
            this.tESP.Tick += new System.EventHandler(this.tESP_Tick);
            // 
            // tAimbot
            // 
            this.tAimbot.Interval = 1;
            this.tAimbot.Tick += new System.EventHandler(this.tAimbot_Tick);
            // 
            // tGameChecker
            // 
            this.tGameChecker.Interval = 1;
            this.tGameChecker.Tick += new System.EventHandler(this.tGameChecker_Tick);
            // 
            // frmOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(111, 70);
            this.Controls.Add(this.pBoxOverlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOverlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOverlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOverlay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxOverlay;
        private System.Windows.Forms.Timer tESP;
        private System.Windows.Forms.Timer tAimbot;
        private System.Windows.Forms.Timer tGameChecker;
    }
}