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
        public List<TextureDefintion> texDef;

        public TextureXMLWrapper()
        {
            texDef = new List<TextureDefintion>();
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
    }

    public class TextureDefintion
    {
        public string name;
        public uint id;
        public uint type;
        public int[] direction = new int[6];

        public TextureDefintion()
        {
            name = "";
            id = 0;
            type = 0;
            direction = new int[6];
        }

        public TextureDefintion(string name, uint id, uint type, int[] direc)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            this.direction = direc;
        }
    }
}
