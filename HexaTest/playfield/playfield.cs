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
		SortedDictionary<string, Texture2D> _texturesMasks;
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
			this._texturesMasks = _texMan.TexturesTerrainMasks;

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
                                                                  counter,
																  _textures.ElementAt(rnd.Next(0, _textures.Count)).Value,
																  _texturesMasks.ElementAt(rnd.Next(0, _texturesMasks.Count)).Value,
																  x,y);
                    }
                    else
                    {
                        _playfield[y, x] = new Hexfield(new Point((int)((Help.Helpers.HexFieldWidth) * (3.0/4.0)) * x,
                                                                 (Help.Helpers.HexFieldHeight * y + Help.Helpers.HexFieldHeight / 2)),
                                                                  counter,
																  _textures.ElementAt(rnd.Next(0, _textures.Count)).Value,
																  _texturesMasks.ElementAt(rnd.Next(0, _texturesMasks.Count)).Value,
																  x,y);
                    }
                }
            }
			setHexEdgeTextures();
            //blendNeighbors();
        }	

		public void Draw(SpriteBatch spriteBatch, Effect AlphaBlendEffect, GraphicsDevice GraphicsDevice)
		{
			for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
			{
				for (int x = 0; x <= _playfield.GetUpperBound(1); x++)
				{
					_playfield[y, x].Draw(spriteBatch, AlphaBlendEffect, GraphicsDevice);
				}
			}
		}
		private void setHexEdgeTextures()
		{
			for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
			{
				for (int x = 0; x <= _playfield.GetUpperBound(1); x++)
				{
					for(int i = 0; i < _playfield[y,x].NeigborCoordinates.Length; i++)
					{
						//DAS GEHT NUR WENN DIE NACHBARN AUCH IM PLAYFIELD LIEGEN!
						Point tempCoord = _playfield[y,x].NeigborCoordinates[i];
						if (tempCoord.X < 0 || tempCoord.Y < 0 || tempCoord.X > _playfield.GetUpperBound(1) || tempCoord.Y > _playfield.GetUpperBound(0))
						{
						}
						else
						{
							_playfield[y, x].setEdgeTexture(i, _playfield[tempCoord.Y, tempCoord.X].Texture);
							_playfield[y,x].setNeighbor (i, _playfield[tempCoord.Y, tempCoord.X]);
						}
					}
				}
			}
		}
        private void blendNeighbors()
        {
            for (int y = 0; y <= _playfield.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= _playfield.GetUpperBound(1); x++)
                {                         
                  
                }				
            }
        }
    }
}
