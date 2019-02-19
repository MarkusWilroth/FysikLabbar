using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redovisning1 {
    class BoxObject {
        Rectangle groundRect, boxRect, groundSource, boxSource;
        Texture2D spriteSheet;
        bool isRunning;

        public BoxObject(Texture2D spriteSheet) {
            this.spriteSheet = spriteSheet;
            isRunning = false;
            boxRect = new Rectangle(0, 0, 25, 25);
            groundRect = new Rectangle(0, 0, 1000, 25);
        }

        public void Update(GameTime gameTime) {
            //När man klickar på en knapp i forms ska lådan röra sig på groundRect, samt ska det läsas in från en textruta hur stark friktionen är
            //När den åker ska inga värden kunna ändras och när bollen är utanför skärmen eller klickat på restart knappen
            //ska kunna känna av om boxen glider på marken eller inte
            if(isRunning) {
                Fall(gameTime);
            }
            else {
            }
        }

        public void Kill() {

        }

        public void Fall(GameTime gameTime) {

        }

        public void Draw(SpriteBatch sb) {
            //sb.Draw(spriteSheet, boxRect, Color.White);
        }
    }
}
