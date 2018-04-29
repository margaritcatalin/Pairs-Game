using PairsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace PairsGame.ViewModels
{
    [Serializable]
    public class CardViewModel : BaseViewModel
    {
        [XmlElement]
        public Card model;
        [XmlElement]
        public int Id { get; set; }
        [XmlElement]
        private bool _isViewed;
        [XmlElement]
        private bool _isMatched;
        [XmlElement]
        private bool _isFailed;
        public bool isViewed
        {
            get
            {
                return _isViewed;
            }
            set
            {
                _isViewed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }
        public bool isMatched
        {
            get
            {
                return _isMatched;
            }
            set
            {
                _isMatched = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        public bool isFailed
        {
            get
            {
                return _isFailed;
            }
            set
            {
                _isFailed = value;
                OnPropertyChanged("SlideImage");
                OnPropertyChanged("BorderBrush");
            }
        }

        public bool isSelectable
        {
            get
            {
                if (isMatched)
                    return false;
                if (isViewed)
                    return false;

                return true;
            }
        }

        public string SlideImage
        {
            get
            {
                if (isMatched)
                    return model.ImageSource;
                if (isViewed)
                    return model.ImageSource;


                return "/PairsGame;component/Resources/mystery_image.jpg";
            }
        }
        public Brush BorderBrush
        {
            get
            {
                if (isFailed)
                    return Brushes.Red;
                if (isMatched)
                    return Brushes.Green;
                if (isViewed)
                    return Brushes.Yellow;

                return Brushes.Black;
            }
        }
        public CardViewModel()
        {
        }
        public CardViewModel(Card card)
        {
            model = card;
            Id = card.Id;
        }
        public void MarkMatched()
        {
            isMatched = true;
        }
        public void MarkFailed()
        {
            isFailed = true;
        }
        public void ClosePeek()
        {
            isViewed = false;
            isFailed = false;
            OnPropertyChanged("isSelectable");
            OnPropertyChanged("SlideImage");
        }
        public void PeekAtImage()
        {
            isViewed = true;
            OnPropertyChanged("SlideImage");
        }
    }
}
