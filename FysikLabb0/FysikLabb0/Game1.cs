﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FysikLabb0 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet;
        int screenWidth, screenHeight, startX, startY;
        Rectangle ballRect;
        Vector2 testPos;
        List<Ball> ballList;
        Ball ball;
        Conversions conver;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            screenWidth = 1900;
            screenHeight = 1000;
            IsMouseVisible = true;
            startX = 5;
            startY = 5;
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            ballRect = new Rectangle(startX, startY, 50, 50);
            ballList = new List<Ball>();
        }

        protected override void LoadContent() { //Införa mitt spritSheet
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = Content.Load<Texture2D>("spriteSheet");
        }

        protected override void Update(GameTime gameTime) {
            if(ballList.Count == 0) {
                CreateBall();
            }
            ball.Update(gameTime);
            
            base.Update(gameTime);
        }

        public void CreateBall() {
            ball = new Ball(spriteSheet, ballRect, this);
            ballList.Add(ball);
        }

        public void DestroyBall(Vector2 posRect) {
            ballList.Clear();

        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            foreach(Ball ball in ballList) {
                ball.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

/* Uppgiften: Boll kastas med känd starthastighet från en känd punkt och far i en kastparabelbana. Indata under körningen (för varje nytt kast) ska vara startpunktens x- och y-värde samt fart och vinkel för hastigheten
 * 
 * Som jag tolkar det ska man ha en boll där startvärdet bestämer var bollen börjar på skärmen och vilken riktning den kommer att åka samt hur snabbt den ska åka. Så det behövs en vector2 som kan ändras av startvärdet och en float speed
 * ränkte att riktningen av bollen bestäms av där man pekar med musen. Saker att kolla upp är vad de menar med en kastparabelbana, tror det kan vara att bollen gradvis ska åka neråt eller något. Planen jag har är att placeringen på bollen
 * ibörjan bestäms av där man har musen och högerklickar, hastighetsvärdet bestäms av rutor man klickar på och riktningen bestäms av musens position, för att sedan skjuta bollen trycker man med vänster musknapp
 * 
 * To Do:
 * implementera HUD:en med klickbara rutor som ändrar värdet på bollenshastighet - Behöver lägga in siffror till rutorna eller göra som fabian ville göra
 * implementera så att bollen läser av musens position och flyger mot musen - Fixa så att v0.Y får in värdet från musen så att men hjälp av en ekvation räkna ut vad v0.Y ska vara för att bollen ska träffa musens position
 * 
 * GLÖM INTE ATT ANVÄNDA SI-ENHETERNA och att använda gameTime för att inte räkna tiden på pixlar
 * 
 * Axel alla värden i ekvationen är i meter det enda som är i pixlar är convertedS (conversationS) som används för att rita ut bollen på skärmen. 
 */
