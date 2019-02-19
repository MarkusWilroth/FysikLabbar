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

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btn_Start_Click(object sender, EventArgs e) {
            //Skickar värdet från textrutan till BoxObject, och ändrar isRunning till true
        }

        private void btn_Restart_Click(object sender, EventArgs e) {
            boxO.Kill();
            //Ändrar värdet som står i textrutan till 0, raderar alla boxar i boxList så att en ny skapas
            //Detta ska även hända om bollen åker utanför... ska vi ha så att man bara kan starta om genom att klicka på denna knapp tror det blir lättast så
        }

        private void btn_Quit_Click(object sender, EventArgs e) {
            //Stänger av programmet
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            //Funderar på om denna går att använda eller inte... Friktionskoefficienten ska vara en double/float vet inte om denna bara ändra heltal
            //Annars ska det gå att ändra värdet här som senare läses in när man startar programmet
        }
    }
}
