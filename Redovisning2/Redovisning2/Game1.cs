﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Redovisning2 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Form1 form1;
        CarObject carO;
        int screenWidth, screenHeight;
        bool isPlaying;
        List<CarObject> carList;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            form1 = new Form1();
            carList = new List<CarObject>();
            screenWidth = 1900;
            screenHeight = 1000;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            form1.Activate();
        }

        protected override void Update(GameTime gameTime) {
            isPlaying = form1.GetPlaying();
            if(isPlaying) {
                if(carList.Count <= 0) {
                    CreateCar();
                }
                carO.Update(gameTime);
            }
            else {
                if(carList.Count > 0) {
                    KillCar();
                }
            }
            base.Update(gameTime);
        }

        public void CreateCar() {
            carO = new CarObject(form1);
            carList.Add(carO);
        }

        public void KillCar() {
            carList.Clear();
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            foreach(CarObject carO in carList) {
                carO.Draw(spriteBatch);
            }

            form1.Show();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

/*
 * C1: En bil kör genom en kurva (del av en cirkel) med viss radie och viss statisk friktionskoefficient mellan däck och vägbana. Man ska under körning (för varje
ny bil) kunna öka farten tills bilen inte längre klarar kurvan. Då skrivs en text ut som säger något om att det inte gick. Man ska ha två olika kurvor med olika
radie men samma friktionskoefficient att välja mellan. Uppgiften ska lösas med en iterativ numerisk metod.
 */