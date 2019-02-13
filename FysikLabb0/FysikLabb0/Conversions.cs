using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysikLabb0 {
    class Conversions {
        static public Vector2 screenSize { get; } = new Vector2(1900, 1000);
        static public Vector2 scale { get; } = new Vector2(10, -10); //pixels per meter
        static public Vector2 BottomLeft { get; } = new Vector2(0, 0); //position av nedre vänstera hörnet i meter
        static public Vector2 TopRight { get; } = new Vector2(screenSize.X / scale.X, screenSize.Y / scale.Y); //position av högra hörnet i meter

        static public Vector2 PosToPixel (Vector2 posInMeter) {
            Vector2 temp = new Vector2(posInMeter.X * scale.X, posInMeter.Y * scale.Y + screenSize.Y);
            return temp;
        }
    }
}
