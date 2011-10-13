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
        Texture2D _texture;
        int _height = Help.Helpers.HexFieldHeight;
        int _width = Help.Helpers.HexFieldWidth;
        Point[] _coordinates;
		int _heightlevel = 1;
        Hexfield[] _neighbours;

        public Hexfield(Point Origin, int Index, Texture2D Texture)
        {
            this._origin = Origin;
            this._center = new Point(this._origin.X + _width / 2, this._origin.Y + _height / 2);
            this._index = Index;
			this._texture = Texture;
            _coordinates = new Point[]  {(new Point(_origin.X + _width / 3          , _origin.Y)),
                                        (new Point(_origin.X + (int)(_width / 1.5)  , _origin.Y)),
                                        (new Point(_origin.X + _width               , _origin.Y + _height / 2)),
                                        (new Point(_origin.X + (int)(_width / 1.5)  , _origin.Y + _height)),
                                        (new Point(_origin.X + _width / 3           , _origin.Y + _height)),
                                        (new Point(_origin.X                        , _origin.Y + _height / 2))};
        }
        //TODO: Draw hier mit reinnehmen - damit lassen sich dann auch die nachbartexturen drüberlegen ;););)
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, new Rectangle(_origin.X,_origin.Y,_width, _height),Color.White);
		}
        public void setTexture(Texture2D Texture)
        {
            this._texture = Texture;
        }
        public Texture2D getTexture
        {
            get { return this._texture; }
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

    }
}
