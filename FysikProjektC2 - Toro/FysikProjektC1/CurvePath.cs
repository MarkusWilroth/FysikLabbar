using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysikProjektC1
{
    public class CurvePath
    {
        Texture2D tex;
        Vector2 pos;
        Vector2 realPos;
        Color inner;
        Color outer;
        int radius = 500;
        int width = 50;

        public CurvePath(int radius, int width, Texture2D tex, Vector2 pos)
        {
            this.radius = radius;
            this.width = width;
            this.tex = tex;
            this.pos = pos;
            realPos = Conversions.PosToPixel(pos);
            inner = Color.White;
            outer = Color.White;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (float i = 0; i < 90; i+=0.2f)
            {
                float x = (float)Math.Sin(i * Math.PI / 180) * radius;
                float y = (float)Math.Cos(i * Math.PI / 180) * radius;
                Vector2 pixelPos = Conversions.PosToPixel(new Vector2(x + pos.X, y + pos.Y));
                spriteBatch.Draw(tex, new Rectangle((int)pixelPos.X,(int)pixelPos.Y,5,5), inner);
            }
            for (float i = 0; i < 90; i += 0.2f)
            {
                float x = (float)Math.Sin(i * Math.PI / 180) * (radius+width);
                float y = (float)Math.Cos(i * Math.PI / 180) * (radius+width);
                Vector2 pixelPos = Conversions.PosToPixel(new Vector2(x + pos.X, y + pos.Y));
                spriteBatch.Draw(tex, new Rectangle((int)pixelPos.X, (int)pixelPos.Y, 4, 4), outer);
            }
            spriteBatch.Draw(tex, new Rectangle((int)realPos.X, (int)realPos.Y,10,10), Color.Red);
        }

        public float GetOuterRadius()
        {
            outer = Color.Red;
            inner = Color.White;
            return radius + width;
        }
        public float GetInnerRadius()
        {
            outer = Color.White;
            inner = Color.Red;
            return radius;
        }
        public float GetMiddleRadius()
        {
            float middle = radius + (GetOuterRadius() - radius) / 2;
            return middle;
        }
    }
}
