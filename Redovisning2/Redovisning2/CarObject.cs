using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redovisning2 {
    class CarObject {
        int speed;
        float my, curveR;
        bool isPlaying;
        Vector2 carPos;
        Form1 form;

        public CarObject(Form1 form) { //ska sedan ha spriteSheet i sig men har inte gjort något sådant
            this.form = form;
            speed = form.GetSpeed();
            my = form.GetMy();
            curveR = form.GetCurve();
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
 */
