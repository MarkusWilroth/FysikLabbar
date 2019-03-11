using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FysikProjektC1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D carTex, pixelTex;

        CurvePath curvePath;
        Car car;
        UI_TextBox speedbox;
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)Conversions.screenSize.X;
            graphics.PreferredBackBufferHeight = (int)Conversions.screenSize.Y;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            carTex = Content.Load<Texture2D>("woopwoop");
            pixelTex = Content.Load<Texture2D>("pixel");
            font = Content.Load<SpriteFont>("font");
            curvePath = new CurvePath(50, 5, pixelTex, new Vector2(0, 10));
            car = new Car(carTex, new Vector2(900, 600), 2, 4, 5, curvePath.GetMiddleRadius());
            speedbox = new UI_TextBox("speeeeeed", "m/s", "0", Vector2.Zero, 0, 0, pixelTex, font);
        }


        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            car.Update(gameTime);
            if(KeyMouseReader.KeyPressed(Keys.Left))
            {
                car.Start(new Point(55,10), speedbox.GetValue(), gameTime, curvePath.GetInnerRadius(), 0.75f);
            }
            else if(KeyMouseReader.KeyPressed(Keys.Right))
            {
                car.Start(new Point(55, 10), speedbox.GetValue(), gameTime, curvePath.GetOuterRadius(), 2f);

            }
            speedbox.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            curvePath.Draw(spriteBatch);
            car.Draw(spriteBatch);
            speedbox.Draw(spriteBatch);
            spriteBatch.DrawString(font, car.TimePassed().ToString(), new Vector2(0,40), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
