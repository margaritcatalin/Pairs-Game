using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace PairsGame.ViewModels
{
    [Serializable]
    public class TimerViewModel: BaseViewModel
    {
        [XmlElement]
        public DispatcherTimer _playedTimer;
        [XmlElement]
        public TimeSpan _timePlayed;

        private const int _playSeconds = 3;
        [XmlElement]
        public TimeSpan Time
        {
            get
            {
                return _timePlayed;
            }
            set
            {
                _timePlayed = value;
                OnPropertyChanged("Time");
            }
        }
        StatisticsViewModel GameInfo { get; set; }
        public TimerViewModel(TimeSpan time,StatisticsViewModel GameInfo)
        {
            _playedTimer = new DispatcherTimer();
            _playedTimer.Interval = time;
            _playedTimer.Tick += PlayedTimer_Tick;
            _timePlayed = new TimeSpan();
            this.GameInfo = GameInfo;
        }
        public TimerViewModel()
        {
        }
        public void Start()
        {
            _playedTimer.Start();
        }

        public void Stop()
        {
            _playedTimer.Stop();
        }

        private void PlayedTimer_Tick(object sender, EventArgs e)
        {
            Time = _timePlayed.Add(new TimeSpan(0, 0, 1));
            AccountsViewModel Accounts = Views.Account.acVM;
            TimeSpan ts = TimeSpan.FromMinutes(Accounts.MaxTime);
            if (Time.Equals(ts))
            {
                GameInfo.GameStatus(false);
                this.Stop();
            }
        }
    }
}
