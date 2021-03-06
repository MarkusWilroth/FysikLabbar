﻿  using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace FysikLabb0 { 
    class Ball {
        Game1 game;
        Rectangle ballRect, ballSource, boxSource;
        Texture2D spriteSheet;
        KeyboardState keyState, oldKeyState;
        Vector2 s0, s, v0, v, convertedS, speedB, speedW, velocity, direction;
        String speedBox, alfaBox;
        Rectangle[] boxPos, numberPos;

        float timer, time, offSet, gravitation, selectedSpeed, alfa, alfaInRad, calc, elast, dir;
        bool isFlying,isMovingDown, isMovingUp, isMovingLeft, isMovingRight;

        public Ball(Texture2D spriteSheet, Rectangle ballRect, Game1 game) {
            this.spriteSheet = spriteSheet;
            this.game = game;
            this.ballRect = ballRect;

            offSet = ballRect.Width / 2;
            
            ballSource = new Rectangle(0, 0, 100, 100);
            boxSource = new Rectangle(310, 0, 200, 100);
            boxPos = new Rectangle[2];
            numberPos = new Rectangle[6];

            elast = 0.8f;
            speedB = new Vector2(0, 0);
            speedW = new Vector2(0, 0);

            v0 = new Vector2(30, 35);
            v = v0;
            gravitation = -9.82f;
            s0 = new Vector2(ballRect.X, ballRect.Y);
            convertedS = new Vector2(0, 0);
            s = s0;
            timer = 0;
            selectedSpeed = 50;
            alfa = 50;
            isFlying = false;
            isMovingDown = true;
            isMovingUp = true;
            isMovingLeft = true;
            isMovingRight = true;
            dir = 1;
            speedBox = "Speed: " + selectedSpeed;
            alfaBox = "Angle: " + alfa;
            

            for (int i = 0; i < boxPos.Length; i++) {
                boxPos[i] = new Rectangle(1700, 800 + (100 * i), 200, 100); //behövs detta ändras till meter??? tillhör inte ekvationen...
            }
        }

        public Vector2 GetPos () {
            return s;
        }

        public void ShootBall(GameTime gameTime) {            
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000f;
            gravitation = (float)(-9.82 * Math.Pow(timer, 2) / 2) * time;
            s.X += v.X * time;
            s.Y += (v.Y) * time + gravitation;

            Console.WriteLine("sträckaX: " + s.X + " SträckaY: "+s.Y);


            if (convertedS.X >= 1875 && isMovingRight) { //Ändra så att den ändrar X-riktning
                v.X *= elast;
                v.X = -v.X;
                isMovingRight = false;
            }
            if (convertedS.X <= 0 && !isMovingRight) { //Ändrar så att den ändrar x-riktning
                v.X *= elast;
                v.X = -v.X;
                isMovingRight = true;
            }
            if (convertedS.Y <= 0 && v.Y<0) {
                dir = -1;
                v.Y *= -elast;
                //v.Y *= dir;
                timer = 0;
                isMovingUp = false;
            }
            if (convertedS.Y >= 975 && v.Y>0) {
                dir = 1;
                v.Y *= -1;
                timer = 0;
                isMovingUp = true;
            }
        }

        public void ChangeValues() {
            if (keyState.IsKeyDown(Keys.W) && oldKeyState.IsKeyUp(Keys.W) && selectedSpeed < 200) {
                selectedSpeed += 10;
            }
            if (keyState.IsKeyDown(Keys.S) && oldKeyState.IsKeyUp(Keys.S) && selectedSpeed > 10) {
                selectedSpeed -= 10;
            }
            if (keyState.IsKeyDown(Keys.E) && oldKeyState.IsKeyUp(Keys.E) && alfa < 90) {
                alfa += 10;
            }
            if (keyState.IsKeyDown(Keys.D) && oldKeyState.IsKeyUp(Keys.D) && alfa > 30) {
                alfa -= 10;
            }

            alfaInRad = (float)((Math.PI / 180) * alfa); //Fixar från grader till radianer
            v0.X = (float)Math.Pow((Math.Pow(selectedSpeed, 2) / 2), 0.5); //första delen av att räkna ut vad v0.X är använder samband mellan ekvationer
            v0.X /= (float)(Math.Tan(alfaInRad));
            calc = (float)(Math.Pow(selectedSpeed, 2) - Math.Pow(v0.X, 2));
            if (calc > 0) {
                v0.Y = (float)(Math.Pow(calc, 0.5));
            }
            else {
                v0.Y = (float)(Math.Pow(((-1)* calc), 0.5));
            }
            v.X = v0.X;
            v.Y = v0.Y;
            

            speedBox = "Speed: " + selectedSpeed;
            alfaBox = "Angle: " + alfa;
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
            s = s0;
        }

        public void Update(GameTime gameTime) {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.R)) {
                game.DestroyBall(s);
            }

            if (!isFlying) {
                if (keyState.IsKeyDown(Keys.Enter) && oldKeyState.IsKeyUp(Keys.Enter)) {
                    isFlying = true;
                    Console.WriteLine("-------------------------------------------------");
                }
                if (keyState.IsKeyDown(Keys.Escape) && oldKeyState.IsKeyUp(Keys.Escape)) {
                    game.Exit();
                }
                convertedS = Conversions.PosToPixel(s0);
                ChangeValues();
                MoveBall();
            }
            else {
                ShootBall(gameTime);
                convertedS = Conversions.PosToPixel(s);
            }

            ballRect.X = (int)(convertedS.X - offSet);
            ballRect.Y = (int)(convertedS.Y - offSet);
            oldKeyState = keyState;

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont) {
            spriteBatch.Draw(spriteSheet, ballRect, ballSource, Color.White);
            for (int i = 0; i < boxPos.Length; i++) {
                spriteBatch.Draw(spriteSheet, boxPos[i], boxSource, Color.White);
                if (i == 0) {
                    spriteBatch.DrawString(spriteFont, speedBox, new Vector2(boxPos[i].X + (boxPos[i].Width / 4), boxPos[i].Y + (boxPos[i].Height / 2)), Color.Black);
                }
                if (i == 1) {
                    spriteBatch.DrawString(spriteFont, alfaBox, new Vector2(boxPos[i].X + (boxPos[i].Width / 4), boxPos[i].Y + (boxPos[i].Height / 2)), Color.Black);
                }

            }
        }
    }
}
