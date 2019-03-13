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
            
            //convertedPos.Y -= 25;
        }

        public void Drive(GameTime gameTime) {
            //angle = (float)(w * time);
            //carPos.X = (float)Math.Cos(angle) * v; //Startar inte där den ska starta och har inte friktion med i uträkningen?!?!
            //carPos.Y = (float)(Math.Sin(angle) * v);

            //Fr = (float)(g * (Math.Sin(angle) - (Math.Cos(angle) * my)));

            //aDirection = new Vector2((float)Math.Cos(angle + 90), (float)(Math.Sin(angle + 90) * ac * (Math.Pow(time,2)/2)));
            //direction = new Vector2((float)(Math.Cos(angle)*Math.PI/180), (float)((Math.Sin(angle)*Math.PI/180) * v * (Math.Pow(time, 2) / 2)));

            //velocity = direction + aDirection;
            //angle = (float)(Math.Atan2(velocity.Y, velocity.X) * 180 / Math.PI);

            //carPos.X += (float)(velocity.X);
            //carPos.Y += (float)(velocity.Y);

            time = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            float fMax = g * my;
            float centripetalAcc = v * v / curveR;
            Vector2 centripetalDirection;

            if (fMax > centripetalAcc)
            {
                //centripetalDirection = new Vector2((float)Math.Cos((angle + 90) * Math.PI / 180), (float)Math.Sin((angle + 90) * Math.PI / 180) * centripetalAcc * time);
                centripetalDirection.X = (float)(Math.Cos((angle + 90) * Math.PI / 180) * centripetalAcc * time);
                centripetalDirection.Y = (float)(Math.Sin((angle + 90) * Math.PI / 180) * centripetalAcc * time);
            }

            else
            {
                centripetalDirection = new Vector2((float)Math.Cos((angle + 90) * Math.PI / 180), (float)Math.Sin((angle + 90) * Math.PI / 180) * fMax * time);
            }
            System.Diagnostics.Debug.WriteLine("Ffmax " + fMax + "  centripetalAcc " + centripetalAcc + ", angle: " + angle + " velocity: " + velocity + " direction: " + direction);
            direction.X = (float)(Math.Cos(angle * Math.PI / 180));
            direction.Y = (float)(Math.Sin(angle * Math.PI / 180));
            direction *= v;
            //direction = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)(Math.Sin(angle * Math.PI / 180)) * v);
            velocity = direction + centripetalDirection;


            float TURN = (float)Math.Atan2(velocity.Y, velocity.X) * 180 / (float)Math.PI;
            angle = TURN;

            convertedPos = Conversion.PosToPixel(carPos);

            carPos += velocity * time;

            //carPos.X = (float)(startPos.X + (((Fr) * Math.Pow(time, 2)) / 2));
            //carPos.Y = (float)(startPos.Y + (((Fr) * Math.Pow(time, 2)) / 2));

        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, convertedPos, carSource, Color.White, -(float)(angle * Math.PI / 180 + 90 * Math.PI / 180), new Vector2(carRect.Width / 2, carRect.Height / 2), 1, SpriteEffects.None, 1);
            sb.Draw(spriteSheet, new Vector2(0, 1000), roadSource, Color.White);
        }
    }
}
