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
using HexaTest.Playfield;
using HexaTest.TextureManagement;

namespace HexaTest.Playfield
{
    class Playfield
    {
        Hexfield[,] _playfield;
        int _height, _width;
        SortedDictionary<string, Texture2D> _textures;
        TextureManager _texMan;
        ContentManager _content;

        public Playfield(int Height, int Width, ContentManager Content)
        {
            this._height = Height;
            this._width = Width;
            this._playfield = new Hexfield[_height, _width];
            this._content = Content;
            this._texMan = new TextureManager(Content);
            this._textures = _texMan.TexturesTerrain;

            int counter = 0;
            Random rnd = new Random();

            for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= _playfield.GetUpperBound(1); x++, counter++)
                {
                    if ((x % 2) == 0) // gerade
                    {
                        _playfield[y, x] = new Hexfield(new Point((int)((Help.Helpers.HexFieldWidth) * (3.0/4.0)) * x,
                                                                 (Help.Helpers.HexFieldHeight) * y),
                                                                  counter, _textures.ElementAt(rnd.Next(0, _textures.Count)).Value);
                    }
                    else
                    {
                        _playfield[y, x] = new Hexfield(new Point((int)((Help.Helpers.HexFieldWidth) * (3.0/4.0)) * x,
                                                                 (Help.Helpers.HexFieldHeight * y + Help.Helpers.HexFieldHeight / 2)),
                                                                  counter, _textures.ElementAt(rnd.Next(0, _textures.Count)).Value);
                    }
                }
            }
            blendNeighbors();
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int y = 0; y < _playfield.GetUpperBound(0); y++)
			{
				for (int x = 0; x < _playfield.GetUpperBound(1); x++)
				{
					_playfield[y, x].Draw(spriteBatch);
				}
			}
		}

        private void blendNeighbors()
        {
            for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= _playfield.GetUpperBound(1); x++)
                {
                    Console.WriteLine("i am " + _playfield[y, x].getTexture.Name + " at " + x + "," + y);
                    /*
                     * Nachbarn in richtung:
                     * 0 x  ,   y-1
                     * 1 x+1,   y
                     * 2 x+1,   y+1
                     * 3 x  ,   y+1
                     * 4 x-1,   y+1
                     * 5 x-1,   y
                     * */
                   
                   
                  
                }
				Console.WriteLine("---------------");
            }
        }
    }
}
