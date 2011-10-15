using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace HexaTest.TextureManagement
{	
    class TextureConnectionManager
    {
        private Dictionary<string, List<string>> dictionary;		

        public TextureConnectionManager()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public TextureConnectionManager(string path)
        {
            dictionary = new TextureManagement.TextureXMLWrapper(path).getAsDictionary();
        }

        public void addTexture(string name)
        {
            if (dictionary.ContainsKey(name))
            {
                throw new ArgumentException("Texture " + name + " already exists", "name");
            }
            List<string> tmpList = new List<string>();
            dictionary.Add(name, tmpList);
        }

        //TODO: check ob connection überhaupt exisitert (z.b. schreibfehler vermeiden)
        public void addConnection(string texture, string connection)
        {
            List<string> tmpList;
            if (!dictionary.ContainsKey(texture))
            {
                throw new ArgumentException("Texture " + texture + " does not exists", "texture");
            }
            if (!dictionary.ContainsKey(connection))
            {
                throw new ArgumentException("Texture " + connection + " does not exists", "connection");
            }
            dictionary.TryGetValue(texture, out tmpList);
            tmpList.Add(connection);
        }

        public List<string> getConnections(string texture)
        {
            List<string> tmpList = null;
            if (!dictionary.ContainsKey(texture))
            {
                throw new ArgumentException("Texture " + texture + " does not exists", "texture");
            }
            dictionary.TryGetValue(texture, out tmpList);
            return tmpList;
        }

        public void save(string path)
        {
            new TextureXMLWrapper(dictionary).exportXML(path);
        }
    }
}
