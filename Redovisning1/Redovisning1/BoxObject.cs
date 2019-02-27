using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Redovisning1 {
    class BoxObject {
        Form1 form1;
        Rectangle boxRect, boxSource;
        Texture2D spriteSheet;
        Vector2 pos, startPos, pixelPos, direction, speed, friction;
        float rotation, time, startSpeed, u, g, fa, fMax, a;

        public BoxObject(Texture2D spriteSheet, float rotation, Form1 form1) {
            this.form1 = form1;
            this.spriteSheet = spriteSheet;
            this.rotation = rotation;
            pos = new Vector2(5, 95);
            startPos = pos;
            g = -9.82f;
            startSpeed = 0;
            time = 0;
            fMax = (float)(g * ((Math.Sin(rotation) - (Math.Cos(rotation)))* u));
            u = 0.1f;
            speed = new Vector2((float)(startSpeed * Math.Cos(rotation)), (float)(startSpeed * Math.Sin(rotation)));
            friction = new Vector2(0, 0);
            boxRect = new Rectangle((int)pos.X, (int)pos.Y, 25, 25);
            boxSource = new Rectangle(0, 1, 25, 25);
            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            u = form1.ReturnFriction();
        }

        public void Update(GameTime gameTime) {
            Fall(gameTime);
            pixelPos = Conversion.PosToPixel(pos);
            boxRect.X = (int)pixelPos.X;
            boxRect.Y = (int)pixelPos.Y;
        }

        public void Fall(GameTime gameTime) {
            fa = (float)(g * (Math.Sin(rotation) - (Math.Cos(rotation) * u)));

            if (fa <= fMax) {
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                friction.X = (float)(-fa * Math.Cos(rotation));
                friction.Y = (float)(fa * Math.Sin(rotation));

                pos.X = (float)(startPos.X + (((friction.X) * Math.Pow(time, 2)) / 2));
                pos.Y = (float)(startPos.Y + (((friction.Y) * Math.Pow(time, 2)) / 2));
            }
           
            
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(spriteSheet, boxRect, boxSource, Color.White, rotation, new Vector2(boxRect.Width / 2, boxRect.Height / 2), SpriteEffects.None, 1);
        }
    }
}
