using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redovisning2 {
    class CarObject {
        int speed; //ska nog vara i km istället för m??
        float my, curveR, Fc, Fr, g, v;
        Vector2 carPos;
        Form1 form;

        public CarObject(Form1 form) { //ska sedan ha spriteSheet i sig men har inte gjort något sådant
            this.form = form;
            g = 9.82f;
            speed = form.GetSpeed();
            my = form.GetMy();
            curveR = form.GetCurve();
            Fr = my * g;
            Fc = (float)(Math.Pow(speed, 2) / curveR);
            if (Fr > Fc) {
                Console.WriteLine("Success?");
            }
        }
        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch sb) {


        }
    }
}
/* Anteckningar från bild:
 * 0m Fr(max) > Fc
    else
    Fr = m*a
    Fr = my*m*g???
 * a = 0c = ?^2/r
 * 
 * Hittat från internet:
 (m*v^2)/r = my*m*g
 v^2 = my*g*r

    För att bilen ska kunna håla sig kvar på vägen måste Fc >= (m*v^2)/r
    Fc = my*m*g;
 */
