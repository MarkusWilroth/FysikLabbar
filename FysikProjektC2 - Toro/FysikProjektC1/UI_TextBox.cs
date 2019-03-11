using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FysikProjektC1
{
    public class UI_TextBox
    {
        private Rectangle rectangle;
        private Vector2 position;
        private string name;
        private string valueType;
        private string value;
        private SpriteFont font;
        private Texture2D texture;
        private Color fontColor;
        private bool selected;

        public UI_TextBox(string name, string valueType, string defaultValue, Vector2 position, int width, int height, Texture2D texture, SpriteFont font)
        {
            this.name = name;
            this.valueType = valueType;
            this.value = defaultValue;
            this.position = position;
            this.texture = texture;
            this.font = font;
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)font.MeasureString(name + ": " + value).X, (int)font.MeasureString(name + ": " + value).Y);
            fontColor = Color.White;
        }

        public void SetFontColor(Color newColor)
        {
            fontColor = newColor;
        }

        public void Update()
        {
            if (KeyMouseReader.LeftClick())
            {
                if (rectangle.Contains(KeyMouseReader.mouseState.Position))
                {
                    value = "";
                    selected = true;
                    fontColor = Color.Yellow;
                }
                else
                {
                    if(value == "")
                    {
                        value = "0";
                    }
                    selected = false;
                    fontColor = Color.White;
                }
            }
            if (selected)
            {
                try
                {
                    Keys[] key = KeyMouseReader.KeyPressed();
                    if (KeyMouseReader.KeyPressed(Keys.Back))
                    {
                        try
                        {
                            value = value.Remove(value.Length - 1);
                            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)font.MeasureString(name + ": " + value).X, (int)font.MeasureString(name + ": " + value).Y);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    else if (KeyMouseReader.KeyPressed().Length > 0)
                    {
                        foreach (Keys k in key)
                        {
                            if (KeyMouseReader.KeyPressed(k))
                            {
                                if (k == Keys.D0 || k == Keys.NumPad0)
                                    value += "0";
                                if (k == Keys.D1 || k == Keys.NumPad1)
                                    value += "1";
                                if (k == Keys.D2 || k == Keys.NumPad2)
                                    value += "2";
                                if (k == Keys.D3 || k == Keys.NumPad3)
                                    value += "3";
                                if (k == Keys.D4 || k == Keys.NumPad4)
                                    value += "4";
                                if (k == Keys.D5 || k == Keys.NumPad5)
                                    value += "5";
                                if (k == Keys.D6 || k == Keys.NumPad6)
                                    value += "6";
                                if (k == Keys.D7 || k == Keys.NumPad7)
                                    value += "7";
                                if (k == Keys.D8 || k == Keys.NumPad8)
                                    value += "8";
                                if (k == Keys.D9 || k == Keys.NumPad9)
                                    value += "9";
                                if (k == Keys.OemComma)
                                    value += ",";
                                if (k == Keys.OemPeriod)
                                    value += ".";
                                rectangle = new Rectangle((int)position.X, (int)position.Y, (int)font.MeasureString(name + ": " + value).X, (int)font.MeasureString(name + ": " + value).Y);
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        public float GetValue()
        {
            float number = float.Parse(value);
            return number;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, rectangle, Color.Black);
            sb.DrawString(font, name + ": " + value + " " + valueType, position, fontColor);
        }
    }

}