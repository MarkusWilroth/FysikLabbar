using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Redovisning1 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BoxObject boxO;
        List<BoxObject> boxList;
        Texture2D spriteSheet;
        Rectangle groundRect, groundSourceRect;
        Form1 form1;
        int screenWidth, screenHeight;
        float rotation;
        bool isAlive, isRunning, quit;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            boxList = new List<BoxObject>();
            form1 = new Form1();
            groundSourceRect = new Rectangle(0, 48, 1900, 25);
            groundRect = new Rectangle(0, 50, 1900, 25);
            rotation = (float)((Math.PI / 180) * 30);
            screenWidth = 1900;
            screenHeight = 1000;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
            spriteSheet = Content.Load<Texture2D>("spriteSheet");
            form1.Activate();
        }

        protected override void Update(GameTime gameTime) {
            isAlive = form1.AliveState();
            isRunning = form1.RunningState();
            quit = form1.Quit();
            if (!isAlive) {
                KillBox();
            }
            if(isRunning) {
                if (boxList.Count <= 0) {
                    CreateBox();
                }
                boxO.Update(gameTime);
            }
            if(quit) {
                Exit();
            }
            
            base.Update(gameTime);
        }
        public void CreateBox() {
            boxO = new BoxObject(spriteSheet, rotation, form1);
            boxList.Add(boxO);
        }

        public void KillBox() {
            boxList.Clear();
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            foreach (BoxObject boxO in boxList) {
                boxO.Draw(spriteBatch);
            }
            spriteBatch.Draw(spriteSheet, groundRect, groundSourceRect, Color.White, rotation, new Vector2(groundRect.Width / 2, groundRect.Height / 2), SpriteEffects.None, 1);
            form1.Show();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
