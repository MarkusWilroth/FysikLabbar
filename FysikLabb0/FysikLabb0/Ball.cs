using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysikLabb0 {
    class Ball {
        Game1 game;
        Rectangle ballRect, mouseRect, ballSource, boxSource;
        Texture2D spriteSheet;
        MouseState mouseState, oldMouseState;
        KeyboardState keyState, oldKeyState;
        Rectangle[] boxPos, numberPos;
        float ballSpeed, t;
        bool isFlying;
        Vector2 s0, s, v0, v, a;

        public Ball(Texture2D spriteSheet, Rectangle ballRect, Game1 game) {
            this.spriteSheet = spriteSheet;
            this.ballRect = ballRect;
            this.game = game;

            ballSource = new Rectangle(0, 0, 100, 100);
            boxSource = new Rectangle(310, 0, 200, 100);
            boxPos = new Rectangle[6];
            numberPos = new Rectangle[6];
            v0 = new Vector2(5, 0); // 5 m/s i X riktning
            v = v0;
            a = new Vector2(0, 9.82f);
            s0 = new Vector2(ballRect.X, ballRect.Y);
            s = s0;
            t = 0;
            isFlying = false;

            mouseRect = new Rectangle(0, 0, 5, 5);

            for (int i = 0; i < boxPos.Length; i++) {
                boxPos[i] = new Rectangle(1700, 400 + (100 * i), 200, 100); //Detta är i pixlar detta behöver ändras till meter
            }
        }

        public Vector2 GetPos () {
            return s;
        }

        public void ShootBall(GameTime gameTime) {
            t += (float)gameTime.ElapsedGameTime.TotalSeconds;
            s.X = s0.X + (((v0.X + v.X) / 2) * t);
            s.Y = s0.Y + (((v0.Y + v.Y) / 2) * t);

            v.X -= 0.01f; //Luftmotstånd behöver ha exakta siffror
            v.Y = v0.Y + (a.Y * t);
            if (s.X >= 1900 || s.Y >= 1000) {
                isFlying = false;
                game.DestroyBall(s);
            }
        }

        public void ChangeSpeed() {
            mouseRect.X = mouseState.X;
            mouseRect.Y = mouseState.Y;

            for (int i = 0; i < boxPos.Length; i++) {
                if(boxPos[i].Contains(mouseRect)) {
                    v0.X = 5 * i;
                    break;
                }
            }
        }

        public void MoveBall () {
            s0.X = mouseState.X;
            s0.Y = mouseState.Y;

        }

        public void Update(GameTime gameTime) {
            mouseState = Mouse.GetState();
            keyState = Keyboard.GetState();

            if (!isFlying) {
                if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released) {
                    MoveBall();

                }
                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
                    ChangeSpeed();
                }
                if (keyState.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter)) {
                    isFlying = true;
                }
            }
            else {
                ShootBall(gameTime);
            }

            oldMouseState = mouseState;
            oldKeyState = keyState;

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteSheet, s, ballSource, Color.White);
            for (int i = 0; i < boxPos.Length; i++) {
                spriteBatch.Draw(spriteSheet, boxPos[i], boxSource, Color.White);
            }
        }
    }
}
