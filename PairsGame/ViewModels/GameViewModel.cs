using PairsGame.Models;
using PairsGame.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PairsGame.ViewModels
{
    [Serializable]
    public class GameViewModel : BaseViewModel
    {
        [XmlElement]
        public CardCollectionViewModel Slides { get; set; }
        [XmlElement]
        public TimerViewModel Timer { get; set; }
        [XmlElement]
        public StatisticsViewModel GameInfo { get; set; }
        [XmlElement]
        public int columnDim { get; set; }
        [XmlElement]
        public int lineDim { get; set; }
        public GameViewModel()
        {

        }
        private int maxTime;
        public int MaxTime
        {
            get { return maxTime; }
            set
            {
                maxTime = value;
                OnPropertyChanged("MaxTime");
            }
        }
        public void SetupGame(int lineDim,int columnDim)
        {
            Slides = new CardCollectionViewModel();
            GameInfo = new StatisticsViewModel();
            Timer = new TimerViewModel(new TimeSpan(0, 0, 1), GameInfo);
            Slides.CreateSlides("Resources/Cards/",lineDim, columnDim);
            Slides.Memorize();
            Timer.Start();
            OnPropertyChanged("Slides");
            OnPropertyChanged("Timer");
            OnPropertyChanged("GameInfo");
        }
        public void ClickedSlide(object slide)
        {
            if (Slides.canSelect)
            {
                var selected = slide as CardViewModel;
                Slides.SelectSlide(selected);
            }

            if (!Slides.areSlidesActive)
            {
                if (Slides.CheckIfMatched())
                    GameInfo.Award();
                else
                    GameInfo.Penalize();
            }

            GameStatus();
        }
        private void GameStatus()
        {
            if (GameInfo.Lost == true)
            {
                Slides.RevealUnmatched();
            }
            if (Slides.AllSlidesMatched)
            {
                GameInfo.GameStatus(true);
                Timer.Stop();
            }
        }
    }
}
