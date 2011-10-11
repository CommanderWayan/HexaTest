using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace HexaTest.textureManager
{
    public class TextureXMLWrapper
    {
        //public List<TextureDefintion> texDef;
        public List<Texturedefintion> texDef;

        public TextureXMLWrapper()
        {
            texDef = new List<Texturedefintion>();
        }

        public TextureXMLWrapper(string path)
        {
            importXML(path);
        }

        public TextureXMLWrapper(Dictionary<string, List<string>> dic)
        {
            createFromDictionary(dic);
        }

        public void exportXML(string path)
        {
            var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            var xmlSerializer = new XmlSerializer(typeof(TextureXMLWrapper));
            xmlSerializer.Serialize(fileStream, this);
        }

        public void importXML(string path)
        {
            var fileStream = new FileStream(path, FileMode.Open);
            var xmlSerializer = new XmlSerializer(typeof(TextureXMLWrapper));
            TextureXMLWrapper definitions = (TextureXMLWrapper)xmlSerializer.Deserialize(fileStream);
            this.texDef = definitions.texDef;
        }

        public Dictionary<string, List<string>> getAsDictionary()
        {
            Dictionary<string, List<string>> tmpDic = new Dictionary<string, List<string>>();
            for (int i = 0; i < texDef.Count; i++)
            {
                Texturedefintion actDef = texDef[i];
                tmpDic.Add(actDef.name, actDef.connections);
            }
            return tmpDic;
        }

        public void createFromDictionary(Dictionary<string, List<string>> inDic)
        {
            texDef = new List<Texturedefintion>();
            foreach (KeyValuePair<string, List<string>> kvp in inDic)
            {
                texDef.Add(new Texturedefintion(kvp.Key, kvp.Value));
            }
        }
    }

    public class Texturedefintion
    {
        public string name;
        public List<string> connections;

        public Texturedefintion()
        {
            name = "";
            connections = new List<string>();
            //textureswithpossibilities = new Dictionary<string, List<string>>();
        }

        public Texturedefintion(string name, List<string> connections)
        {
            this.name = name;
            this.connections = connections;
            //this.textureswithpossibilities = texturewithpossibilities;
        }
    }
}
