using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HexaTest.Help;
using HexaTest.TextureManagement;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace HexaTest.TextureManagement
{
	/// <summary>
	/// Provides available Textures and their connections between each other
	/// </summary>
	class TextureManager
	{
		SortedDictionary<string, Texture2D> _texturesTerrain;
		SortedDictionary<string, int> _priorityTerrain;

		public TextureManager(ContentManager Content)
		{
			_texturesTerrain = Helpers.LoadContent<Texture2D>(Content, "terrain");
			_priorityTerrain = new SortedDictionary<string, int>();
			for (int i = 0; i < _texturesTerrain.Count; i++)
			{
				_texturesTerrain.ElementAt(i).Value.Name = _texturesTerrain.ElementAt(i).Key;
				//TODO: Priorität implementieren!!!
				_priorityTerrain.Add(_texturesTerrain.ElementAt(i).Key, 0);
			}
		}

        public SortedDictionary<string, Texture2D> TexturesTerrain
		{
			get { return this._texturesTerrain; }
		}
	}
}
