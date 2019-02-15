using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysikLabb0 { //Saker behöver snyggas upp inför redovisningen, finns lite onödiga saker här som vi borde sätta oss i discord och ta bort
    class Ball {
        Game1 game;
        Rectangle ballRect, mouseRect, ballSource, boxSource;
        Texture2D spriteSheet;
        MouseState mouseState, oldMouseState;
        KeyboardState keyState, oldKeyState;
        Rectangle[] boxPos, numberPos;
        float time, offSet, gravitation, selectedSpeed, alfa, alfaInRad;
        bool isFlying;
        Vector2 s0, s, v0, v, convertedS;

        public Ball(Texture2D spriteSheet, Rectangle ballRect, Game1 game) {
            this.spriteSheet = spriteSheet;
            this.game = game;
            this.ballRect = ballRect;

            offSet = ballRect.Width / 2;
            
            ballSource = new Rectangle(0, 0, 100, 100);
            boxSource = new Rectangle(310, 0, 200, 100);
            boxPos = new Rectangle[2];
            numberPos = new Rectangle[6];

            v0 = new Vector2(30, 35);
            v = v0;
            gravitation = -9.82f;
            s0 = new Vector2(ballRect.X, ballRect.Y);
            convertedS = new Vector2(0, 0);
            s = s0;
            time = 0;
            selectedSpeed = 45;
            alfa = 10;
            isFlying = false;

            mouseRect = new Rectangle(0, 0, 5, 5);

            for (int i = 0; i < boxPos.Length; i++) {
                boxPos[i] = new Rectangle(1700, 800 + (100 * i), 200, 100); //behövs detta ändras till meter??? tillhör inte ekvationen...
            }
        }

        public Vector2 GetPos () {
            return s;
        }

        public void ShootBall(GameTime gameTime) {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            v.X = v0.X; //Lägg till luftmotstånd?
            v.Y = v0.Y + (gravitation * time);

            s.X = s0.X + (((v0.X + v.X) / 2) * time); //ekvationen som flyttar bollen
            s.Y = s0.Y + (((v0.Y + v.Y) / 2) * time);
            
            
            if (convertedS.X >= 1900 || convertedS.Y >= 1000) { //Kollar om bollen är utanför så att den försvinner... använder inte meter här men borde inte vara några problem
                isFlying = false;
                game.DestroyBall(s);
            }
        }

        public void ChangeValues() {
            if (keyState.IsKeyDown(Keys.W) && oldKeyState.IsKeyUp(Keys.W) && selectedSpeed < 80) {
                selectedSpeed += 10;
            }
            if (keyState.IsKeyDown(Keys.S) && oldKeyState.IsKeyUp(Keys.S) && selectedSpeed > 10) {
                selectedSpeed -= 10;
            }
            if (keyState.IsKeyDown(Keys.E) && oldKeyState.IsKeyUp(Keys.E) && selectedSpeed < 85) {
                selectedSpeed += 5;
            }
            if (keyState.IsKeyDown(Keys.D) && oldKeyState.IsKeyUp(Keys.D) && selectedSpeed > 5) {
                selectedSpeed -= 5;
            }

            alfaInRad = (float)((Math.PI / 180) * alfa);
            v0.X = (float)Math.Pow((Math.Pow(selectedSpeed, 2) / 2), 0.5);
            v0.X /= (float)(Math.Tan(alfaInRad));
            v0.Y = (float)Math.Tan(alfaInRad) * v.X;

        }

        public void MoveBall () { //Fixa så att man inte kan styra bollen utanför skärmen eller inte?
            if (keyState.IsKeyDown(Keys.Up)) {
                s0.Y += 1;
            }
            else if (keyState.IsKeyDown(Keys.Down)) {
                s0.Y -= 1;
            }                                    
            if (keyState.IsKeyDown(Keys.Right)) {
                s0.X += 1;
            }
            else if (keyState.IsKeyDown(Keys.Left)) {
                s0.X -= 1;
            }
        }

        public void Update(GameTime gameTime) {
            mouseState = Mouse.GetState();
            keyState = Keyboard.GetState();

            if (!isFlying) {
                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) {
                    ChangeValues();
                }

                if (keyState.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter)) {
                    isFlying = true;
                }
                convertedS = Conversions.PosToPixel(s0);
                MoveBall(); //använd biltangenterna för att flytta den
            }
            else {
                ShootBall(gameTime);
                convertedS = Conversions.PosToPixel(s);
            }

            ballRect.X = (int)(convertedS.X - offSet);
            ballRect.Y = (int)(convertedS.Y - offSet);
            oldMouseState = mouseState;
            oldKeyState = keyState;

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteSheet, ballRect, ballSource, Color.White);
            for (int i = 0; i < boxPos.Length; i++) {
                spriteBatch.Draw(spriteSheet, boxPos[i], boxSource, Color.White);
            }
        }
    }
}
