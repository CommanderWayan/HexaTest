﻿using System;
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
using HexaTest.Help;

namespace HexaTest.Playfield
{
    /// <summary>
    /// A Hexagonal Field
    /// ---- corners
    ///   0  1
    /// 5      2
    ///   4  3
    ///   
    /// ---- neighbours
    ///    0
    /// 5     1
    /// 4     2
    ///    3
    /// </summary>
    class Hexfield
    {
        int _index;
        Point _origin;
        Point _center;        
        int _height = Help.Helpers.HexFieldHeight;
        int _width = Help.Helpers.HexFieldWidth;
        Point[] _coordinates;
		int _heightlevel = 1;
        Point[] _neighborCoordinates;
		Hexfield[] _neigbors = new Hexfield[6];
		Point _playfieldCoordinate;

		Texture2D _texture;
		Texture2D[] _edgeTextures = new Texture2D[6];
		Texture2D _blendTexture;
		int _priority;

        public Hexfield(Point Origin, int Index, Texture2D Texture,Texture2D BlendTexture, int ArrayX, int ArrayY, int Priority)
        {
			this._priority = Priority;
            this._origin = Origin;
            this._center = new Point(this._origin.X + _width / 2, this._origin.Y + _height / 2);
            this._index = Index;
			this._texture = Texture;
			this._blendTexture = BlendTexture;
            _coordinates = new Point[]  {(new Point(_origin.X + _width / 4						, _origin.Y)),
                                        (new Point(_origin.X + (int)(_width * (3.0/4.0))	, _origin.Y)),
                                        (new Point(_origin.X + _width							, _origin.Y + _height / 2)),
                                        (new Point(_origin.X + (int)(_width * (3.0/4.0))	, _origin.Y + _height)),
                                        (new Point(_origin.X + _width / 4						, _origin.Y + _height)),
                                        (new Point(_origin.X									, _origin.Y + _height / 2))};
			_playfieldCoordinate = new Point(ArrayX, ArrayY);
			_neighborCoordinates = CalcLib.getNeighbors(ArrayX, ArrayY);

        }
		public void Draw(SpriteBatch spriteBatch, Effect AlphaBlendEffect, GraphicsDevice GraphicsDevice)
		{
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);			
			spriteBatch.Draw(_texture, new Rectangle(_origin.X,_origin.Y,_width, _height),Color.White);
			spriteBatch.End();

			
			//jetzt edge texturen malen - wenn denn die eigene priorität niedriger ist
			Vector2 pivot;
			float angle = (float)(Math.PI * 60 / 180.0);	

			for (int i = 0; i < _edgeTextures.Length; i++)
			{
				if (_edgeTextures[i] != null)
				{
					if (_neigbors[i].Priority > this._priority)
					{
						spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);			
						GraphicsDevice.Textures[1] = _blendTexture;
						GraphicsDevice.SamplerStates[1] = SamplerState.LinearClamp;
						AlphaBlendEffect.CurrentTechnique = AlphaBlendEffect.Techniques["AlphaBlend"];
						AlphaBlendEffect.CurrentTechnique.Passes["pass0"].Apply();

						pivot = new Vector2(_edgeTextures[i].Bounds.Center.X, _edgeTextures[i].Bounds.Center.Y);
						
						spriteBatch.Draw(_edgeTextures[i],
										new Rectangle(_origin.X + 40, _origin.Y + 35, _width, _height),
										null,
										Color.White,
										angle * i,
										pivot,
										SpriteEffects.None,
										0f);

						spriteBatch.End();
					}
					
					
				}
			}
			
			
		}
		public void setTexture(Texture2D Texture)
        {
            this._texture = Texture;
        }
        public Texture2D Texture
        {
            get { return this._texture; }
        }
		public int Priority
		{
			get { return this._priority; }
		}
		public Point Origin
		{
			get{return this._origin;}
		}
		public int Height
		{
			get{return this._height;}
		}
		public int Width
		{
			get{return this._width;}
		}
		public Point[] Coordinates
		{
			get { return this._coordinates; }
		}
		public Point[] NeigborCoordinates
		{
			get { return this._neighborCoordinates; }
		}
		public void setEdgeTexture(int Edge, Texture2D EdgeTexture)
		{
			if (Edge > 5)
			{
				throw ( new IndexOutOfRangeException("Edge kann nur 0..5 sein!"));
			}
			else
			{
				_edgeTextures[Edge] = EdgeTexture;
			}
		}
		public void setNeighbor(int NeighborIndex, Hexfield Neighbor)
		{
			if (NeighborIndex > 5)
			{
				throw (new IndexOutOfRangeException("NeighborIndex kann nur 0..5 sein!"));
			}
			else
			{
				_neigbors[NeighborIndex] = Neighbor;
			}
		}
    }
}
