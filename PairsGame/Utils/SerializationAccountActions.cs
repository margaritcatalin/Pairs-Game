using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PairsGame.Models;
using PairsGame.ViewModels;
namespace PairsGame.Utils
{
    class SerializationAccountActions
    {
        public void SerializeObject(string xmlFileName, ObservableCollection<Account> entity)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(ObservableCollection<Account>));
            FileStream fileStr = new FileStream(xmlFileName, FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }

        public ObservableCollection<Account> DeserializeObject(string xmlFileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(ObservableCollection<Account>));
            FileStream file = new FileStream(xmlFileName, FileMode.Open);
            var entity = xmlser.Deserialize(file);
            file.Dispose();
            return entity as ObservableCollection<Account>;
        }
    }
}
