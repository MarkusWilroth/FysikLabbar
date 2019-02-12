using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FysikLabb0 {
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int screenWidth, screenHeight, startX, startY;
        Rectangle ballRect, testRect;
        List<Ball> ballList;
        Ball ball;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            screenWidth = 1650;
            screenHeight = 900;
            startX = 200;
            startY = 750;
            ballRect = new Rectangle(startX, startY, 50, 50);
            ballList = new List<Ball>();
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            base.Initialize();
        }

        protected override void LoadContent() { //Införa mitt spritSheet

            spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }

        protected override void Update(GameTime gameTime) {
            if(ballList.Count == 0) {
                CreateBall();
            }
            ball.Update();
            base.Update(gameTime);
        }

        public void CreateBall() {
            ball = new Ball(ballRect);
            ballList.Add(ball);
        }

        public void DestroyBall(Rectangle posRect) {
            foreach (Ball ball in ballList) {
                testRect = ball.GetRect();
                if(testRect == posRect) {
                    ballList.Remove(ball);
                    break;
                }
            }

        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            foreach(Ball ball in ballList) {
                ball.Draw(spriteBatch);
            }
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
 * Skapa bollenklassen
 * implementera bollen i skärmen med startvärden och att dessa värden kan ändras med höger musknapp
 * implementera huden med klickbara rutor som ändrar värdet på bollenshastighet
 * implementera så att bollen läser av musens position och flyger mot musen
 * implementera att bollen försvinner när den är utanför skärmen och att en ny boll skapas
 * implementera en kraft som ändrar bollens riktning?
 * 
 * GLÖM INTE ATT ANVÄNDA SI-ENHETERNA
 */
