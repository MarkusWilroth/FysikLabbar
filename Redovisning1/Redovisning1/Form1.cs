using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redovisning1 {
    public partial class Form1 : Form {
        BoxObject boxO;
        float friktion;
        bool isPlaying, isAlive;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            isPlaying = false;
            isAlive = true;
        }
        //static public float Fri() {
        //    float friktion = (float)NumericUpDown1.Value;
        //    return friktion;
        //}

        public float GetFri {
            get { return friktion; }
        }

        public bool State {
            get { return isPlaying; }
        }

        public bool AliveState {
            get { return isAlive; }
        }

        private void btn_Start_Click(object sender, EventArgs e) {
            friktion = (float)numericUpDown1.Value;
            isPlaying = true;
            //numericUpDown1.Visible = false; //Ska ändras så att rutan blir grå tills bollen dör
            //Skickar värdet från textrutan till BoxObject, och ändrar isRunning till true
        }

        private void btn_Restart_Click(object sender, EventArgs e) {
            numericUpDown1.Value = 0;
            isAlive = false;
            isPlaying = false;
            //Ändrar värdet som står i textrutan till 0, raderar alla boxar i boxList så att en ny skapas
            //Detta ska även hända om bollen åker utanför... ska vi ha så att man bara kan starta om genom att klicka på denna knapp tror det blir lättast så
        }

        private void btn_Quit_Click(object sender, EventArgs e) {
            //Stänger av programmet
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            if(numericUpDown1.Value >= 1) {
                numericUpDown1.Value = 1;
            }
            if(numericUpDown1.Value <= 0) {
                numericUpDown1.Value = 0;
            }
            //Funderar på om denna går att använda eller inte... Friktionskoefficienten ska vara en double/float vet inte om denna bara ändra heltal
            //Annars ska det gå att ändra värdet här som senare läses in när man startar programmet
            

        }
    }
}
