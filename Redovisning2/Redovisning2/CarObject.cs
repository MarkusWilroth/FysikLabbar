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
        float my, curveR, Fc, Fr, g, v, rotation, time, curve, angle, w, fMax, dir, vel;
        Texture2D spriteSheet;
        Vector2 carPos, startPos, convertedPos, friction, direction, velocity;
        Rectangle carRect, carSource, roadSource;
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
            curve = form.SendCurve();
            Fr = my * g;
            angle = 0;
            time = 0;
            Fc = (float)(Math.Pow(v, 2) / curveR);
            
            carPos = new Vector2(curveR, 0);
            startPos = carPos;
            fMax = (float)(g * (Math.Sin(rotation) - (Math.Cos(rotation) * my)));
            carRect = new Rectangle((int)carPos.X, (int)carPos.Y, 15, 25);
            carSource = new Rectangle(5, 5, 15, 25);
            roadSource = new Rectangle(0, 31, 514, 716);
            if (Fr > Fc) {
                Console.WriteLine("Success?");
            }
            w = v / curveR;
        }
        public void Update(GameTime gameTime) {
            Drive(gameTime);
            convertedPos = Conversion.PosToPixel(carPos);
            convertedPos.Y -= 25;
        }

        public void Drive(GameTime gameTime) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //angle = (float)(w * time);
            //carPos.X = (float)Math.Cos(angle) * v; //Startar inte där den ska starta och har inte friktion med i uträkningen?!?!
            //carPos.Y = (float)(Math.Sin(angle) * v);

            //Fr = (float)(g * (Math.Sin(angle) - (Math.Cos(angle) * my)));
            direction = new Vector2((float)(Math.Cos(angle)*Math.PI/180), (float)(Math.Sin(angle)*Math.PI/180)*v);
            velocity = direction + friction;
            angle = (float)(Math.Atan2(velocity.Y, velocity.X) * 180/Math.PI);
            Fc = (float)((Math.Pow(v, 2) / curveR));
            friction.X = (float)(Fc * Math.Cos(angle));
            friction.Y = (float)(Fc * Math.Sin(angle));
            

            carPos.X += (float)(velocity.X*time);
                carPos.Y += (float)(velocity.Y*time);




                //carPos.X = (float)(startPos.X + (((Fr) * Math.Pow(time, 2)) / 2));
                //carPos.Y = (float)(startPos.Y + (((Fr) * Math.Pow(time, 2)) / 2));
            
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, convertedPos, carSource, Color.White);
            sb.Draw(spriteSheet, new Vector2(0, 1000), roadSource, Color.White);
        }
    }
}
