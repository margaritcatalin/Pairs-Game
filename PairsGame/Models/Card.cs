using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PairsGame.Models
{
    [Serializable]
    public class Card
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string ImageSource { get; set; }
    }
}
