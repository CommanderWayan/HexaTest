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

namespace HexaTest.textureManager
{
    /*
     * gegenüberliegend
     * 0 <-> 3
     * 1 <-> 4
     * 2 <-> 5
     * */
    enum Neighbors
    {
        N = 0,
        NE,
        SE,
        S,
        SW,
        NW
    }
    class textureNet
    {
        public textureNet()
        {
        }
    }
    class textureNode
    {        
        int _id;
        Texture2D _texture;
        //6 elemente - siehe enum Neighbor
        List<textureNodeConnection[]> connectionsForHexSides;        
        public textureNode(int ID ,Texture2D texture)
        {
            connectionsForHexSides = new List<textureNodeConnection[]>(6);
            this._texture = texture;
            this._id = ID;
        }

        public void setNeighbor(Neighbors direction, textureNodeConnection connection)
        {
            //beginnode der connection bin ICH THIS            
        }
    }
    class textureNodeConnection
    {
        int _id;        
        textureNode _beginNode;
        textureNode _endNode;
        Neighbors _direction;
        public textureNodeConnection(int ID, Neighbors Direction, textureNode BeginNode, textureNode EndNode)
        {
            this._id = ID;
            this._beginNode = BeginNode;
            this._endNode = EndNode;
            this._direction = Direction;
        }
        /// <summary>
        /// Connects 2 Texture Nodes
        /// </summary>
        private void connect2Nodes()
        {
            //in erstes node gehen und sich eintragen, dann in 2.
            //direction beachten - beim 2. node muss sie gegenüberliegend sein!!
            //:direction ist die aus richtung ERSTER Node!
            
        }
    }
}
