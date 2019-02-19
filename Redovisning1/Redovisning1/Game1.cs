using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Redovisning1 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BoxObject boxO;
        List<BoxObject> boxList;
        Texture2D spriteSheet;
        Form1 form;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            boxList = new List<BoxObject>();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            IsMouseVisible = true;
           
        }

        protected override void Update(GameTime gameTime) {
            if(boxList.Count <= 0) {
                CreateBox();
            }
            base.Update(gameTime);
        }
        public void CreateBox() {
            //skapar lådjäveln
            boxO = new BoxObject(spriteSheet);
            boxList.Add(boxO);
        }

        public void KillBox() {
            //Dödar lådjäveln
            boxList.Clear();
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            //foreach (BoxObject boxO in boxList) {
            //    boxO.Draw(spriteBatch);
            //}
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
/* B1:
 * En låda glider utför en backe. Backen kan lämpligen vara en rektangel (lång men låg) som lutas en fix vinkel θ = 30◦. Man ska under körning (för varje ny låda) kunna mata in ett värde på kinetiska friktionskoefficienten (µk) tills  * värdet är så stort att lådan slutar glida.
 * 
 * Tolkning
 * En rektangel ska luta 30◦ där en annan rektagel ska glida på tills friktionens värde blir större än lådans kraft. friktionen ska kunnas ändras och programmet ska kunna köras utan omstart!
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
