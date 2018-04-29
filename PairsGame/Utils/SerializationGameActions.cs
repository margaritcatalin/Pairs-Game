using PairsGame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PairsGame.Utils
{
    class SerializationGameActions
    {
        public void SerializeObject(string xmlFileName, GameViewModel entity)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(GameViewModel));
            FileStream fileStr = new FileStream(xmlFileName, FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }

        public GameViewModel DeserializeObject(string xmlFileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(GameViewModel));
            FileStream file = new FileStream(xmlFileName, FileMode.Open);
            var entity = xmlser.Deserialize(file);
            file.Dispose();
            return entity as GameViewModel;
        }
    }
}
