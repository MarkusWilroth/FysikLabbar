using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redovisning2 {
    public partial class Form1 : Form {
        private bool isPlaying, isQuit;
        private int speed;
        private float my, curveR, curve;

        public Form1() {
            InitializeComponent();
            curveR = 30;
            isQuit = false;
            isPlaying = false;
        }

        private void btn_Kurva1_Click(object sender, EventArgs e) {
            curveR = 50; //radie för kurvarn, ska nog ändras till något annat mer passande senare
            txb_Output.Text = "Aktiverad Kurva: 1";
            curve = 1;
        }

        private void btn_Kurva2_Click(object sender, EventArgs e) {
            curveR = 60;
            txb_Output.Text = "Aktiverad Kurva: 2";
            curve = 1.1f;
        }

        private void btn_Start_Click(object sender, EventArgs e) {
            btn_Kurva1.Enabled = false;
            btn_Kurva2.Enabled = false;
            NUD_Friktion.Enabled = false;
            NUD_Hastighet.Enabled = false;
            isPlaying = true;
        }

        private void btn_Restart_Click(object sender, EventArgs e) {
            btn_Kurva1.Enabled = true;
            btn_Kurva2.Enabled = true;
            NUD_Friktion.Enabled = true;
            NUD_Hastighet.Enabled = true;
            isPlaying = false;
        }

        private void btn_Quit_Click(object sender, EventArgs e) {
            isQuit = true;
        }

        private void NUD_Friktion_ValueChanged(object sender, EventArgs e) {
            my = (float)NUD_Friktion.Value;
        }

        private void NUD_Hastighet_ValueChanged(object sender, EventArgs e) {
            speed = (int)NUD_Hastighet.Value;
        }

        private void txb_Output_TextChanged(object sender, EventArgs e) {

        }

        #region Values
        public float GetMy() {
            return my;
        }

        public float SendCurve() {
            return curve;
        }

        public int GetSpeed() {
            return speed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public float GetCurve() {
            return curveR;
        }

        public bool GetPlaying() {
            return isPlaying;
        }

        public bool GetQuit() {
            return isQuit;
        }
        #endregion

    }
}
