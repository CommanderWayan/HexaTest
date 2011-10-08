using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using HexaTest.playfield;

namespace HexaTest.playfield
{
    class playfield
    {
        public hexfield[,] _playfield;
        public int _height, _width;

        public playfield(int Height, int Width)
        {
            this._height = Height;
            this._width = Width;
            this._playfield = new hexfield[_height, _width];

            int counter = 0;
            for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= _playfield.GetUpperBound(1); x++, counter++)
                {
                    if ((x % 2) == 0) // gerade
                    {
                        _playfield[y, x] = new hexfield(new Point((int)((2 * hexfield._width) / 3) * x,
                                                                 (hexfield._height) * y),
                                                                  counter);
                    }
                    else
                    {
                        _playfield[y, x] = new hexfield(new Point((int)((2 * hexfield._width) / 3) * x,
                                                                 (hexfield._height * y + hexfield._height / 2)),
                                                                  counter);
                    }
                }
            }
        }
        public void setUniTextureTest(Texture2D tex)
        {
            for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= _playfield.GetUpperBound(1); x++)
                {
                    _playfield[y, x].setTexture(tex);
                }
            }
        }
    }
}
