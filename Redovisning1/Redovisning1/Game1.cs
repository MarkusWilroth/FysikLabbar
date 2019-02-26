using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Redovisning1 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BoxObject boxO;
        List<BoxObject> boxList;
        Texture2D spriteSheet;
        Rectangle groundRect, groundSourceRect;
        Form1 form;
        int screenWidth, screenHeight;
        float rotation;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            boxList = new List<BoxObject>();
            form = new Redovisning1.Form1();
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
            form.Activate();
           
        }

        protected override void Update(GameTime gameTime) {
            if(boxList.Count <= 0) {
                CreateBox();
            }
            boxO.Update(gameTime);
            base.Update(gameTime);
        }
        public void CreateBox() {
            //skapar lådjäveln
            boxO = new BoxObject(spriteSheet, rotation);
            boxList.Add(boxO);
        }

        public void KillBox() {
            //Dödar lådjäveln
            boxList.Clear();
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            foreach (BoxObject boxO in boxList) {
                boxO.Draw(spriteBatch);
            }
            spriteBatch.Draw(spriteSheet, groundRect, groundSourceRect, Color.White, rotation, new Vector2(groundRect.Width / 2, groundRect.Height / 2), SpriteEffects.None, 1);
            form.Show();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
/* B1:
 * En låda glider utför en backe. Backen kan lämpligen vara en rektangel (lång men låg) som lutas en fix vinkel θ = 30◦. Man ska under körning (för varje ny låda) kunna mata in ett värde på kinetiska friktionskoefficienten (µk) tills  * värdet är så stort att lådan slutar glida.
 * 
 * Tolkning
 * En rektangel ska luta 30◦ där en annan rektagel ska glida på tills friktionens värde blir större än lådans kraft. friktionen ska kunnas ändras och programmet ska kunna köras utan omstart! Lådan behöver inte intergera med marken
 * ska bara se ut som om att den åker på den.
 * 
 * To Do List:
 * Fixa forms så att alla knappar och info visas
 * Implementera en Object-klass
 * Implementera en box-klass som har en rektangel med startvärden och en kraft
 * Implementera en väg-klass som har en rektangel med starvärde och ska kunna läsa av friktionen från textrutan, samt ha ett startväde så att den lutar 30◦ (Tänkte att det ska vara här ekvationen händer)
 * Implementera att programmet ska kunna startas om.
 * Ekvationen som ska användas är (velocity += acceleration - friction*velocity
 * 
 * C1:
 * En bil k¨or genom en kurva (del av en cirkel) med viss radie och viss statisk friktionskoefficient mellan d¨ack och v¨agbana. Man ska under körning (för varje ny bil) kunna ¨oka farten tills bilen inte l¨angre klarar kurvan. D˚a skrivs en text
 * ut som s¨ager n˚agot om att det inte gick. Man ska ha tv˚a olika kurvor med olika radie men samma friktionskoefficient att v¨alja mellan. Uppgiften ska l¨osas med en iterativ numerisk metod.
 * 
 * Tolkning
 * 
 * To Do List:
 * 
 */
