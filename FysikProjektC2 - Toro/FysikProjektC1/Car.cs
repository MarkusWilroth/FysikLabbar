using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysikProjektC1
{
    class Car
    {
        float timepassed;
        float timeAtStart;

        float timeSinceLast;

        Texture2D tex;
        Rectangle rect;
        Vector2 pos;
        Vector2 realPos;
        Vector2 velocity;
        Vector2 direction;
        float accelerationDueToGravity = 9.82f;
        float mass = 2400;
        float speed;
        float angle;
        float radius;
        int width;
        int length;
        float FriktionsKoefficient;

        public Car(Texture2D tex, Vector2 pos, int width, int length, float speed, float radius)
        {
            this.tex = tex;
            this.pos = pos;
            angle = 30;
            this.speed = speed;
            this.width = width;
            this.length = length;
            this.radius = radius;
            rect = new Rectangle((int)pos.X - tex.Width / 2, (int)pos.Y - tex.Height / 2, width, length);
            FriktionsKoefficient = 0.75f;
            direction = new Vector2((float)Math.Cos((angle) * Math.PI / 180), (float)Math.Sin((angle) * Math.PI / 180));
            velocity = direction * speed;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLast = gameTime.ElapsedGameTime.Milliseconds / 1000f;

            // accelerationDueToGravity;

            float Ffmax = FriktionsKoefficient * accelerationDueToGravity;     
            float centripetalAcceleration = speed * speed / radius;
            Vector2 centripetalDirection;
            string result;
            if (Ffmax > centripetalAcceleration)
            {
                centripetalDirection = new Vector2((float)Math.Cos((angle + 90) * Math.PI / 180), (float)Math.Sin((angle + 90) * Math.PI / 180)) * centripetalAcceleration * timeSinceLast;
                result = "SUCCESS! We're on track!";
            }
            else
            {
                centripetalDirection = new Vector2((float)Math.Cos((angle + 90) * Math.PI / 180), (float)Math.Sin((angle + 90) * Math.PI / 180)) * Ffmax * timeSinceLast;
                result = "FAILURE! We're off track!";
            }
            System.Diagnostics.Debug.WriteLine("Ffmax " + Ffmax + "  centripetalAcc " + centripetalAcceleration + "  Result: " + result);
            direction = new Vector2((float)Math.Cos(angle * Math.PI / 180), (float)Math.Sin(angle * Math.PI / 180)) * speed;
            velocity = direction + centripetalDirection;

            float TURN = (float)Math.Atan2(velocity.Y, velocity.X) * 180 / (float)Math.PI;
            angle = TURN;

            realPos = Conversions.PosToPixel(pos);
            //velocity = radius * angularSpeed;
            pos += velocity * timeSinceLast;




            if (pos.X > 0.1f)
            {
                timepassed += timeSinceLast;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, realPos, new Rectangle(0, 0, tex.Width, tex.Height), Color.White, -(float)(angle * Math.PI / 180 + 90 * Math.PI / 180), new Vector2(rect.Width / 2, rect.Height / 2), 0.2f, SpriteEffects.None, 1);
            //spriteBatch.Draw(tex, new Rectangle((int)realPos.X, (int)realPos.Y, width, length), new Rectangle(0, 0, tex.Width, tex.Height), Color.White, -(float)(angle * Math.PI / 180 + 90 * Math.PI / 180), new Vector2(rect.Width / 2, rect.Height / 2), SpriteEffects.None, 1);)
        }

        public float TimePassed()
        {
            return timepassed;
        }

        public void Start(Point startPos, float speed, GameTime gameTime, float radius, float friktionsKoefficient)
        {
            this.speed = speed;
            this.radius = radius;
            FriktionsKoefficient = friktionsKoefficient;
            pos = new Vector2(radius, 10);
            timepassed = 0;

            rect = new Rectangle((int)pos.X - tex.Width / 2, (int)pos.Y - tex.Height / 2, width, length);
            angle = 90;
            direction = new Vector2((float)Math.Cos((angle) * Math.PI / 180), (float)Math.Sin((angle) * Math.PI / 180));
            //velocity = direction * speed;
        }
    }
}
