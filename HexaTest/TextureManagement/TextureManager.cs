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
		SortedDictionary<string, Texture2D> _texturesTerrainMasks;

		SortedDictionary<string, int> _priorityTerrain;

		public TextureManager(ContentManager Content)
		{
			_texturesTerrain = Helpers.LoadContent<Texture2D>(Content, "terrain");
			_texturesTerrainMasks = Helpers.LoadContent<Texture2D>(Content, "terrain-masks");
			_priorityTerrain = new SortedDictionary<string, int>();

			for (int i = 0; i < _texturesTerrain.Count; i++)
			{
				_texturesTerrain.ElementAt(i).Value.Name = _texturesTerrain.ElementAt(i).Key;
				//TODO: Priorität implementieren!!!
				_priorityTerrain.Add(_texturesTerrain.ElementAt(i).Key, new Random().Next(0,_texturesTerrain.Count));
			}
			for (int i = 0; i < _texturesTerrainMasks.Count; i++)
			{
				_texturesTerrainMasks.ElementAt(i).Value.Name = _texturesTerrainMasks.ElementAt(i).Key;
			}
		}

		public SortedDictionary<string, Texture2D> TexturesTerrain
		{
			get { return this._texturesTerrain; }
		}
		public SortedDictionary<string, Texture2D> TexturesTerrainMasks
		{
			get { return this._texturesTerrainMasks; }
		}
		public SortedDictionary<string, int> PriorityTerrain
		{
			get { return this._priorityTerrain; }
		}
	}
}
