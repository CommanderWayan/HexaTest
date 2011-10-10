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
using HexaTest.Help;

namespace HexaTest.textureManager
{	
    

    class TextureNet
    {
		SortedDictionary<string, TextureNode> _nodes;
		Dictionary<string, Texture2D> _textures;
        public TextureNet(ContentManager Content)
        {
			this._nodes = new SortedDictionary<string, TextureNode>();
			_textures = Helpers.LoadContent<Texture2D>(Content, "ground");
			int i = 0;
			foreach (KeyValuePair<string, Texture2D> kvp in _textures)
			{
				_nodes.Add(kvp.Key, new TextureNode(i, kvp.Value));
				i++;
			}
			//So, alle Nodes sind da - jetz müssen sie noch verbunden werden ;)
        }
		/// <summary>
		/// Gets a List with all possible adjacent Textures
		/// </summary>
		/// <param name="Node">The Texture node to search for</param>
		/// <returns>a list with all adjacent possible Texturename WITHOUT the filename extension</returns>
		public List<string> getConnectionsForNode(TextureNode Node)
		{
			return null;
		}
    }
    class TextureNode
    {        
        int _id;
        Texture2D _texture;
		string _texname;
		List<TextureNode>[] _connections;
       
        public TextureNode(int ID ,Texture2D Texture)
        {			
            this._texture = Texture;
			this._texname = _texture.Name;
            this._id = ID;
			this._connections = new List<TextureNode>[6];
			initConnectionList();
        }
		public int ID { get { return this._id; } }
		public string TextureName { get { return this._texname; } }
		public List<TextureNode> connections(Helpers.Neighbors Direction) { return this._connections[(int)Direction]; }

		private void initConnectionList()
		{
			for (int i = 0; i < this._connections.Length; i++)
			{
				_connections[i] = new List<TextureNode>();
			}
		}
		public void setConnection(ref TextureNode NodeToConnectTo,Helpers.Neighbors Direction)
		{
			_connections[(int)Direction].Add(NodeToConnectTo);			
		}
    }    
}
