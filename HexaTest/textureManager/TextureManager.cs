using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HexaTest.Help;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HexaTest.TextureManagement
{
	/// <summary>
	/// Provides available Textures and their connections between each other
	/// </summary>
	class TextureManager
	{
		SortedDictionary<string, Texture2D> _textures;

		public TextureManager(ContentManager Content)
		{
			_textures = Helpers.LoadContent<Texture2D>(Content, "terrain");
            for (int i = 0; i < _textures.Count; i++)
                _textures.ElementAt(i).Value.Name = _textures.ElementAt(i).Key;
		}

        public SortedDictionary<string, Texture2D> Textures
		{
			get { return this._textures; }
		}
	}
}
