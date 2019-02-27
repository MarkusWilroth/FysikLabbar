using System;
using System.Windows.Forms;

namespace Redovisning1 {
    public partial class Form1 : Form {
        BoxObject boxO;
        private float friction;
        private bool isPlaying, isAlive, quit;

        public Form1() {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e) {
            isPlaying = false;
            isAlive = true;
            quit = false;
        }

        #region Values
        public float ReturnFriction() {
            return friction;
        }

        public bool RunningState() {
            return isPlaying;
        }

        public bool AliveState() {
            return isAlive;
        }

        public bool Quit() {
            return quit;
        }
        #endregion

        private void btn_Start_Click(object sender, EventArgs e) {
            friction = (float)numericUpDown1.Value;
            isPlaying = true;
            isAlive = true;
        }

        private void btn_Restart_Click(object sender, EventArgs e) {
            numericUpDown1.Value = 0;
            isAlive = false;
            isPlaying = false;
        }

        private void btn_Quit_Click(object sender, EventArgs e) {
            quit = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            if(numericUpDown1.Value >= 1) {
                numericUpDown1.Value = 1;
            }
            if(numericUpDown1.Value <= 0) {
                numericUpDown1.Value = 0;
            }  
        }
    }
}
