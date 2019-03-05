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
        float my, curveR, Fc, Fr, g, v, rotation, time, curve;
        Texture2D spriteSheet;
        Vector2 carPos, startPos;
        Rectangle carRect, carSource;
        Form1 form;

        public CarObject(Form1 form, Texture2D spriteSheet, float rotation) { //ska sedan ha spriteSheet i sig men har inte gjort något sådant
            this.form = form;
            this.spriteSheet = spriteSheet;
            this.rotation = rotation;
            
            g = 9.82f;
            speed = form.GetSpeed();
            v = (float)(speed / 3.6);
            my = form.GetMy();
            curveR = form.GetCurve();
            Fr = my * g;
            Fc = (float)(Math.Pow(v, 2) / curveR);
            carPos = new Vector2(400 * curve, 430);
            startPos = carPos;
            carRect = new Rectangle((int)carPos.X, (int)carPos.Y, 15, 25);
            carSource = new Rectangle(5, 5, 15, 25);
            if (Fr > Fc) {
                Console.WriteLine("Success?");
            }
        }
        public void Update(GameTime gameTime) {
            curve = form.SendCurve();
        }

        public void Drive(GameTime gameTime) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            carPos.X = (float)(startPos.X + (((Fr) * Math.Pow(time, 2)) / 2));
            carPos.Y = (float)(startPos.Y + (((Fr) * Math.Pow(time, 2)) / 2));
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, carRect, carSource, Color.White, rotation, new Vector2(carRect.Width / 2, carRect.Height / 2), SpriteEffects.None, 1);
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
