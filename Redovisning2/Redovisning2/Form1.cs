﻿using System;
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
        private float my, curveR;

        public Form1() {
            InitializeComponent();
            isQuit = false;
            isPlaying = false;
        }

        private void btn_Kurva1_Click(object sender, EventArgs e) {
            curveR = 300; //radie för kurvarn, ska nog ändras till något annat mer passande senare
            txb_Output.Text = "Aktiverad Kurva: 1";

        }

        private void btn_Kurva2_Click(object sender, EventArgs e) {
            curveR = 600;
            txb_Output.Text = "Aktiverad Kurva: 2";

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

        public int GetSpeed() {
            return speed;
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