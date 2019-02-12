using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysikLabb0 {
    class Ball {
        Rectangle ballRect;
        Texture2D spriteSheet;

        public Ball(Rectangle ballRect) {
            this.ballRect = ballRect;

        }

        public Rectangle GetRect () {
            return ballRect;
        }

        public void Update() {

        }

        public void Draw(SpriteBatch spriteBatch) {

        }
    }
}
