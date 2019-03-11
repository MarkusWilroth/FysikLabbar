using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FysikProjektC1
{
    class Conversions
    {
        static public Vector2 screenSize { get; } = new Vector2(1300, 700);
        static public Vector2 scale { get; } = new Vector2(10, -10);//pixels per meter
        static public Vector2 BottomLeft{ get; } = new Vector2(0, 0);//position av nedre vänstra hörnet i meter
        static public Vector2 TopRight{ get; } = new Vector2(screenSize.X/ scale.X,screenSize.Y/ scale.Y);//position av övre högra hörnet i meter
        static public Vector2 PosToPixel(Vector2 posInMeter)
        {
            Vector2 posInPixels = new Vector2(posInMeter.X* scale.X,posInMeter.Y* scale.Y+ screenSize.Y);
            return posInPixels;
        }
        static public Point PosToPixel(Point posInMeter)
        {
            Point PosInPixels = new Point(posInMeter.X / (int)scale.X, posInMeter.Y / (int)scale.Y + (int)screenSize.Y);
            return PosInPixels;
        }
    }
}
