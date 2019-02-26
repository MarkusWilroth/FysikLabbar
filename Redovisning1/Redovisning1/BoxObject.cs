using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redovisning1 {
    class BoxObject {
        Rectangle boxRect, boxSource;
        Texture2D spriteSheet;
        Vector2 pos, startPos, pixelPos, friction, direction, speed, a, friktion;
        float rotation, time, direction2, startSpeed, u, g;
        bool isRunning;

        public BoxObject(Texture2D spriteSheet, float rotation) {
            this.spriteSheet = spriteSheet;
            this.rotation = rotation;
            isRunning = true;
            pos = new Vector2(5, 95);
            startPos = pos;
            g = -9.82f;
            startSpeed = 0;
            time = 0;
            u = 0.98f;
            a = new Vector2((float)(-g * Math.Cos(rotation)), (float)(g * Math.Sin(rotation)));
            //speed = new Vector2(0,-9.82f);
            speed = new Vector2((float)(startSpeed * Math.Cos(rotation)), (float)(startSpeed * Math.Sin(rotation)));
            friktion = new Vector2(0, 0);
            boxRect = new Rectangle((int)pos.X, (int)pos.Y, 25, 25);
            boxSource = new Rectangle(0, 1, 25, 25);
            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
        }

        public void Update(GameTime gameTime) {
            //När man klickar på en knapp i forms ska lådan röra sig på groundRect, samt ska det läsas in från en textruta hur stark friktionen är
            //När den åker ska inga värden kunna ändras och när bollen är utanför skärmen eller klickat på restart knappen
            //ska kunna känna av om boxen glider på marken eller inte
            if(isRunning) {
                Fall(gameTime);
            }
            else {
                //u = Form1.Fri();
            }
            pixelPos = Conversion.PosToPixel(pos);
            boxRect.X = (int)pixelPos.X;
            boxRect.Y = (int)pixelPos.Y;
        }

        public void Kill() {

        }

        public void Fall(GameTime gameTime) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            friktion.X = (float) (-g * Math.Cos((Math.PI / 180) * 30) * u); //tror man ska ha * time för att Normalkraften ändras men inte säker
            friktion.Y = (float)(g * Math.Sin((Math.PI / 180) * 30) * u);

            //a.X -= friktion.X; //inte helt säker hur vi ska göra här
            //a.Y -= friktion.Y;

            //pos.X = (float)(startPos.X + (((a.X) * Math.Pow(time, 2)) / 2) - (((friktion.X) * Math.Pow(time, 2)) / 2));
            //pos.Y = (float)(startPos.Y + (((a.Y) * Math.Pow(time, 2)) / 2) - (((friktion.Y) * Math.Pow(time, 2)) / 2));

            pos.X = (float)(startPos.X + (((a.X) * Math.Pow(time, 2)) / 2) - friktion.X); //hur skulle hända om man släpper en låda för en backe... den skulle väll fortfarande öka hastigheten även fast det är friktion eller kommer den tillslut att stanna?
            pos.Y = (float)(startPos.Y + (((a.Y) * Math.Pow(time, 2)) / 2) - friktion.Y);

            //pos += speed;
            //pos.X += speed.X * direction.X;
            //pos.Y += speed.Y * direction.Y;

            //pos.X = startPos.X + (((startSpeed + (speed.X * direction.X)) / 2) * time);
            //pos.Y = startPos.Y + (((startSpeed + (speed.Y * direction.Y)) / 2) * time);

            //speed.X *= direction.X;
            //speed.Y *= direction.Y;

            //pos.X = startPos.X + (((startSpeed + speed.X) / 2) * time);
            //pos.Y = startPos.Y + (((startSpeed + speed.Y) / 2) * time);


        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, boxRect, boxSource, Color.White, rotation, new Vector2(boxRect.Width / 2, boxRect.Height / 2), SpriteEffects.None, 1);
        }
    }
}
