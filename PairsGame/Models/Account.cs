using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PairsGame.Models
{
    [Serializable]
   public class Account : INotifyPropertyChanged
    {
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        [XmlAttribute]
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        [XmlAttribute]
        private string imgUrl;
        public string ImgUrl
        {
            get
            {
                return imgUrl;
            }
            set
            {
                imgUrl = value;
                NotifyPropertyChanged("ImgUrl");
            }
        }
        [XmlAttribute]
        private int gamePlay;
        public int GamePlay
        {
            get { return gamePlay; }
            set
            {
                gamePlay = value;
                NotifyPropertyChanged("GamePlayed");
            }
        }
        [XmlAttribute]
        private int gameWon;
        public int GameWon
        {
            get { return gameWon; }
            set
            {
                gameWon = value;
                NotifyPropertyChanged("GameWon");
            }
        }
    }
}
