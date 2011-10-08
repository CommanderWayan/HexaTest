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
using HexaTest.Helpers;

namespace HexaTest.textureManager
{	
    

    class textureNet
    {
		SortedDictionary<string, textureNode> _nodes;
		Dictionary<string, Texture2D> _textures;
        public textureNet(ContentManager Content)
        {
			this._nodes = new SortedDictionary<string, textureNode>();
			_textures = helpers.LoadContent<Texture2D>(Content, "ground");
			int i = 0;
			foreach (KeyValuePair<string, Texture2D> kvp in _textures)
			{
				_nodes.Add(kvp.Key, new textureNode(i, kvp.Value));
				i++;
			}
			//So, alle Nodes sind da - jetz müssen sie noch verbunden werden ;)
        }
    }
    class textureNode
    {        
        int _id;
        Texture2D _texture;
		string _texname;
		List<textureNode>[] _connections;
       
        public textureNode(int ID ,Texture2D Texture)
        {           
			
            this._texture = Texture;
			this._texname = _texture.Name;
            this._id = ID;
			this._connections = new List<textureNode>[6];
			initConnectionList();
        }
		public int ID { get { return this._id; } }
		public string TextureName { get { return this._texname; } }
		public List<textureNode> connections(helpers.Neighbors Direction) { return this._connections[(int)Direction]; }

		private void initConnectionList()
		{
			for (int i = 0; i < this._connections.Length; i++)
			{
				_connections[i] = new List<textureNode>();
			}
		}
		public void setConnection(ref textureNode NodeToConnectTo,helpers.Neighbors Direction)
		{
			_connections[(int)Direction].Add(NodeToConnectTo);			
		}
    }    
}
