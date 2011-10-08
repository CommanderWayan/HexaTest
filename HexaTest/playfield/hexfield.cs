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

namespace HexaTest.playfield
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
    class hexfield
    {
        int _index;
        public Point _origin;
        Point _center;
        Texture2D _texture;
        public const int _height = 60;
        public const int _width = 60;
        public Point[] _coordinates;
        hexfield[] _neighbours;

        public hexfield(Point Origin, int Index)
        {
            this._origin = Origin;
            this._center = new Point(this._origin.X + _width / 2, this._origin.Y + _height / 2);
            this._index = Index;
            _coordinates = new Point[]  {(new Point(_origin.X + _width / 3          , _origin.Y)),
                                        (new Point(_origin.X + (int)(_width / 1.5)  , _origin.Y)),
                                        (new Point(_origin.X + _width               , _origin.Y + _height / 2)),
                                        (new Point(_origin.X + (int)(_width / 1.5)  , _origin.Y + _height)),
                                        (new Point(_origin.X + _width / 3           , _origin.Y + _height)),
                                        (new Point(_origin.X                        , _origin.Y + _height / 2))};
        }

        public void setTexture(Texture2D Texture)
        {
            this._texture = Texture;
        }
        public Texture2D getTexture
        {
            get { return this._texture; }
        }

    }
}
