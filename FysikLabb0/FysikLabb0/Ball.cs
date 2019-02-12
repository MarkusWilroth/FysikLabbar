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
        Rectangle ballRect, mouseRect, ballSource, boxSource;
        Texture2D spriteSheet;
        MouseState mouseState, oldMouseState;
        Rectangle[] boxPos, numberPos;
        float ballSpeed;

        public Ball(Texture2D spriteSheet, Rectangle ballRect) {
            this.spriteSheet = spriteSheet;
            this.ballRect = ballRect;
            ballSource = new Rectangle(0, 0, 100, 100);
            boxSource = new Rectangle(310, 0, 200, 100);
            boxPos = new Rectangle[6];
            numberPos = new Rectangle[6];
            ballSpeed = 5;
            mouseRect = new Rectangle(0, 0, 5, 5);

            for (int i = 0; i < boxPos.Length; i++) {
                boxPos[i] = new Rectangle(1700, 430 + (100 * i), 200, 100);
            }
        }

        public Rectangle GetRect () {
            return ballRect;
        }

        public void ShootBall() {

        }

        public void ChangeSpeed() {
            mouseRect.X = mouseState.X;
            mouseRect.Y = mouseState.Y;

            for (int i = 0; i < boxPos.Length; i++) {
                if(boxPos[i].Contains(mouseRect)) {
                    ballSpeed = 5 * i;
                    break;
                }
            }
        }

        public void MoveBall () {
            ballRect.X = mouseState.X;
            ballRect.Y = mouseState.Y;

        }

        public void Update() {
            mouseState = Mouse.GetState();

            if(mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released) {
                MoveBall();

            }
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
                ChangeSpeed();
            }

            oldMouseState = mouseState;

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteSheet, ballRect, ballSource, Color.White);
            for (int i = 0; i < boxPos.Length; i++) {
                spriteBatch.Draw(spriteSheet, boxPos[i], boxSource, Color.White);
            }
        }
    }
}
