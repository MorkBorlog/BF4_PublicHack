using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YellowMemoryLib;

namespace BF4_PublicHack
{
    public partial class frmMain : Form
    {
        Settings HackSettings = new Settings();
        YellowMemory Mem = new YellowMemory();

        public frmMain()
        {
            InitializeComponent();
        }

        // Wenn der Hack gestartet wird, sollen bestimmte dinge nachgeladen werden!
        private void frmMain_Load( object sender, EventArgs e )
        {
            btnRun.BackColor = Color.White;

            // Setzen wir mal die Gegner Werte
            cBoxESP_Enemys.Checked = HackSettings.Enemy_ESP;
            cBoxESP_Enemys_Lines.Checked = HackSettings.Enemy_Lines;
            cBoxESP_Enemys_Healthbar.Checked = HackSettings.Enemy_Healthbar;
            cBoxESP_Enemys_Distance.Checked = HackSettings.Enemy_Distance;

            // Setzen wir mal die Freund Werte
            cBoxESP_Friends.Checked = HackSettings.Friend_ESP;
            cBoxESP_Friends_Lines.Checked = HackSettings.Friend_Lines;
            cBoxESP_Friends_Healthbar.Checked = HackSettings.Friend_Healthbar;
            cBoxESP_Friends_Distance.Checked = HackSettings.Friend_Distance;

            // Globale Einstellungen setzen
            cBoxAimbot.Checked = HackSettings.Aimbot;
            cBoxNoRecoil.Checked = HackSettings.NoRecoil;
            cBoxShowInfos.Checked = HackSettings.TargetInfo;
            
        }

        private void pictureBox1_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnRun_Click( object sender, EventArgs e )
        {
            if( !Mem.AttackProcess( "bf4" ) ) MessageBox.Show( "Open first the Game please!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
            else
            {
                frmOverlay HackOverlay = new frmOverlay( HackSettings );
                HackOverlay.Show();

                this.Hide();
            }
        }

        private void btnRun_MouseHover( object sender, EventArgs e )
        {
            btnRun.BackColor = Color.Yellow;
        }

        private void btnRun_MouseLeave( object sender, EventArgs e )
        {
            btnRun.BackColor = Color.White;
        }

        private void linkThread_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            System.Diagnostics.Process.Start("http://www.unknowncheats.me/forum/battlefield-4/106461-bf4-x64-public-esp-and-aimbot-hack.html");
        }

        private void cBoxESP_Enemys_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Enemy_ESP = cBoxESP_Enemys.Checked;
        }

        private void cBoxESP_Friends_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Friend_ESP = cBoxESP_Friends.Checked;
        }

        private void cBoxESP_Enemys_Lines_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Enemy_Lines = cBoxESP_Enemys_Lines.Checked;
        }

        private void cBoxESP_Friends_Lines_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Friend_Lines = cBoxESP_Friends_Lines.Checked;
        }

        private void cBoxESP_Enemys_Healthbar_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Enemy_Healthbar = cBoxESP_Enemys_Healthbar.Checked;
        }

        private void cBoxESP_Friends_Healthbar_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Friend_Healthbar = cBoxESP_Friends_Healthbar.Checked;
        }

        private void cBoxESP_Enemys_Distance_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Enemy_Distance = cBoxESP_Enemys_Distance.Checked;
        }

        private void cBoxESP_Friends_Distance_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Friend_Distance = cBoxESP_Friends_Distance.Checked;
        }

        private void cBoxAimbot_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.Aimbot = cBoxAimbot.Checked;
        }

        private void cBoxNoRecoil_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.NoRecoil = cBoxNoRecoil.Checked;
        }

        private void cBoxShowInfos_CheckedChanged( object sender, EventArgs e )
        {
            HackSettings.TargetInfo = cBoxShowInfos.Checked;
        }

        
    }
}
