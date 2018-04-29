using PairsGame.Models;
using PairsGame.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace PairsGame.ViewModels
{
    [Serializable]
    public class CardCollectionViewModel : BaseViewModel
    {
        [XmlArray]
        public ObservableCollection<CardViewModel> MemoryCards { get; set; }
        private CardViewModel SelectedSlide1;
        private CardViewModel SelectedSlide2;
        private DispatcherTimer _peekTimer;
        private DispatcherTimer _openingTimer;
        private const int _peekSeconds = 1;
        private const int _openSeconds = 2;
        public bool areSlidesActive
        {
            get
            {
                if (SelectedSlide1 == null || SelectedSlide2 == null)
                    return true;

                return false;
            }
        }
        public bool AllSlidesMatched
        {
            get
            {
                foreach (var slide in MemoryCards)
                {
                    if (!slide.isMatched)
                        return false;
                }

                return true;
            }
        }
        public bool canSelect { get; set; }


        public CardCollectionViewModel()
        {
            _peekTimer = new DispatcherTimer();
            _peekTimer.Interval = new TimeSpan(0, 0, _peekSeconds);
            _peekTimer.Tick += PeekTimer_Tick;

            _openingTimer = new DispatcherTimer();
            _openingTimer.Interval = new TimeSpan(0, 0, _openSeconds);
            _openingTimer.Tick += OpeningTimer_Tick;
        }
        public void CreateSlides(string imagesPath,int lineDimension,int columnDimension)
        {
            MemoryCards = new ObservableCollection<CardViewModel>();
            var models = GetModelsFrom(@imagesPath);
            for (int i = 0; i < (lineDimension*columnDimension)/2; i++)
            {
                var newSlide = new CardViewModel(models[i]);
                var newSlideMatch = new CardViewModel(models[i]);
                MemoryCards.Add(newSlide);
                MemoryCards.Add(newSlideMatch);
                newSlide.PeekAtImage();
                newSlideMatch.PeekAtImage();
            }
            ShuffleSlides();
            OnPropertyChanged("MemoryCards");
        }
        public void SelectSlide(CardViewModel slide)
        {
            slide.PeekAtImage();

            if (SelectedSlide1 == null)
            {
                SelectedSlide1 = slide;
            }
            else if (SelectedSlide2 == null)
            {
                SelectedSlide2 = slide;
                HideUnmatched();
            }

            SoundManager.PlayCardFlip();
            OnPropertyChanged("areSlidesActive");
        }
        public bool CheckIfMatched()
        {
            if (SelectedSlide1.Id == SelectedSlide2.Id)
            {
                MatchCorrect();
                return true;
            }
            else
            {
                MatchFailed();
                return false;
            }
        }
        private void MatchFailed()
        {
            SelectedSlide1.MarkFailed();
            SelectedSlide2.MarkFailed();
            ClearSelected();
        }
        private void MatchCorrect()
        {
            SelectedSlide1.MarkMatched();
            SelectedSlide2.MarkMatched();
            ClearSelected();
        }
        private void ClearSelected()
        {
            SelectedSlide1 = null;
            SelectedSlide2 = null;
            canSelect = false;
        }
        public void RevealUnmatched()
        {
            foreach (var slide in MemoryCards)
            {
                if (!slide.isMatched)
                {
                    _peekTimer.Stop();
                    slide.MarkFailed();
                    slide.PeekAtImage();
                }
            }
        }
        public void HideUnmatched()
        {
            _peekTimer.Start();
        }
        public void Memorize()
        {
            _openingTimer.Start();
        }
        private List<Card> GetModelsFrom(string relativePath)
        {
            var models = new List<Card>();
            var images = Directory.GetFiles(@relativePath, "*.jpg", SearchOption.AllDirectories);
            var id = 0;

            foreach (string i in images)
            {
                models.Add(new Card() { Id = id, ImageSource = "/PairsGame;component/" + i });
                id++;
            }

            return models;
        }
        private void ShuffleSlides()
        {
            var rnd = new Random();
            for (int i = 0; i < 64; i++)
            {
                MemoryCards.Reverse();
                MemoryCards.Move(rnd.Next(0, MemoryCards.Count), rnd.Next(0, MemoryCards.Count));
            }
        }
        private void OpeningTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in MemoryCards)
            {
                slide.ClosePeek();
                canSelect = true;
            }
            OnPropertyChanged("areSlidesActive");
            _openingTimer.Stop();
        }
        private void PeekTimer_Tick(object sender, EventArgs e)
        {
            foreach (var slide in MemoryCards)
            {
                if (!slide.isMatched)
                {
                    slide.ClosePeek();
                    canSelect = true;
                }
            }
            OnPropertyChanged("areSlidesActive");
            _peekTimer.Stop();
        }
    }
}
