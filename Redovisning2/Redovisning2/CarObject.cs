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
        float my, curveR, Fc, Fr, g, v, rotation, time, curve, angle, ac, fMax, dir, vel, centripetalAcc;
        Texture2D spriteSheet;
        Vector2 carPos, startPos, convertedPos, aDirection, direction, velocity, centripetalDirection;
        Rectangle carRect, carSource, roadSource;
        Form1 form;

        public CarObject(Form1 form, Texture2D spriteSheet, float rotation) { //ska sedan ha spriteSheet i sig men har inte gjort något sådant
            this.form = form;
            this.spriteSheet = spriteSheet;
            this.rotation = rotation;
            
            g = 9.82f;
            speed = form.GetSpeed(); //Får speed i km/h
            v = (float)(speed / 3.6); //Ändrar det till m/s
            my = form.GetMy(); //Får my
            curveR = form.GetCurve(); //Får radien av cirkeln
            Fr = my * g;
            Fc = (float)(Math.Pow(v, 2) / curveR);
            if (Fr > Fc) {
                Console.WriteLine("Success");
            }

            aDirection = new Vector2(0, 0);
            ac = (float)Math.Pow(v,2) / curveR;
            

            angle = 90;
            time = 0;
            carPos = new Vector2(curveR, 0);
            direction = new Vector2((float)Math.Cos((angle) * Math.PI / 180), (float)Math.Sin((angle) * Math.PI / 180));
            velocity = direction * v;
            startPos = carPos;
            carRect = new Rectangle((int)carPos.X, (int)carPos.Y, 15, 25);
            carSource = new Rectangle(5, 5, 15, 25);
            roadSource = new Rectangle(0, 31, 514, 716);
            
        }
        public void Update(GameTime gameTime) {
            Drive(gameTime);
        }

        public void Drive(GameTime gameTime) {
            time = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            fMax = g * my;
            centripetalAcc = v * v / curveR;

            if (fMax > centripetalAcc)
            {
                centripetalDirection.X = (float)(Math.Cos((angle + 90) * Math.PI / 180) * centripetalAcc * time);
                centripetalDirection.Y = (float)(Math.Sin((angle + 90) * Math.PI / 180) * centripetalAcc * time);
            }

            else
            {
                centripetalDirection.X = (float)(Math.Cos((angle + 90) * Math.PI / 180) * fMax * time);
                centripetalDirection.Y = (float)(Math.Sin((angle + 90) * Math.PI / 180) * fMax * time);
            }
            System.Diagnostics.Debug.WriteLine("Ffmax " + fMax + "  centripetalAcc " + centripetalAcc + ", angle: " + angle + " velocity: " + velocity + " direction: " + direction);
            direction.X = (float)(Math.Cos(angle * Math.PI / 180));
            direction.Y = (float)(Math.Sin(angle * Math.PI / 180));
            direction *= v;
            velocity = direction + centripetalDirection;


            float TURN = (float)Math.Atan2(velocity.Y, velocity.X) * 180 / (float)Math.PI;
            angle = TURN;

            convertedPos = Conversion.PosToPixel(carPos);

            carPos += velocity * time;
            

        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, convertedPos, carSource, Color.White, -(float)(angle * Math.PI / 180 + 90 * Math.PI / 180), new Vector2(carRect.Width / 2, carRect.Height / 2), 1, SpriteEffects.None, 1);
            sb.Draw(spriteSheet, new Vector2(0, 1000), roadSource, Color.White);
        }
    }
}
