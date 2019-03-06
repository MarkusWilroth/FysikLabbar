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
        float my, curveR, Fc, Fr, g, v, rotation, time, curve, angle, ac, fMax, dir, vel;
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
            fMax = g * my;

            angle = 0;
            time = 0;
            carPos = new Vector2(curveR, 0);
            velocity = new Vector2(0, 0);
            startPos = carPos;
            carRect = new Rectangle((int)carPos.X, (int)carPos.Y, 15, 25);
            carSource = new Rectangle(5, 5, 15, 25);
            roadSource = new Rectangle(0, 31, 514, 716);
            
        }
        public void Update(GameTime gameTime) {
            Drive(gameTime);
            convertedPos = Conversion.PosToPixel(carPos);
            convertedPos.Y -= 25;
        }

        public void Drive(GameTime gameTime) {
            //angle = (float)(w * time);
            //carPos.X = (float)Math.Cos(angle) * v; //Startar inte där den ska starta och har inte friktion med i uträkningen?!?!
            //carPos.Y = (float)(Math.Sin(angle) * v);

            //Fr = (float)(g * (Math.Sin(angle) - (Math.Cos(angle) * my)));
            time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            angle = (float)(Math.Atan2(velocity.Y, velocity.X) * 180 / Math.PI);

            //aDirection = new Vector2((float)Math.Cos(angle + 90), (float)(Math.Sin(angle + 90) * ac * (Math.Pow(time,2)/2)));
            //direction = new Vector2((float)(Math.Cos(angle)*Math.PI/180), (float)((Math.Sin(angle)*Math.PI/180) * v * (Math.Pow(time, 2) / 2)));

            //velocity = direction + aDirection;
            //angle = (float)(Math.Atan2(velocity.Y, velocity.X) * 180 / Math.PI);

            //carPos.X += (float)(velocity.X);
            //carPos.Y += (float)(velocity.Y);

            centripetalDirection.X = (float)(Fc * Math.Cos(angle) * time);
            centripetalDirection.Y = (float)(Fc * Math.Sin(angle) * time);

            direction = new Vector2((float)(Math.Cos(angle) * Math.PI / 180), (float)((Math.Sin(angle) * Math.PI / 180) * v));
            velocity = direction + centripetalDirection;            

            carPos.X += (float)(velocity.X * time);
            carPos.Y += (float)(velocity.Y * time);

            //carPos.X = (float)(startPos.X + (((Fr) * Math.Pow(time, 2)) / 2));
            //carPos.Y = (float)(startPos.Y + (((Fr) * Math.Pow(time, 2)) / 2));

        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, convertedPos, carSource, Color.White);
            sb.Draw(spriteSheet, new Vector2(0, 1000), roadSource, Color.White);
        }
    }
}
