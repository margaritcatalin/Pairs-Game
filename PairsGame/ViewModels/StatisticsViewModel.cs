using PairsGame.Models;
using PairsGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace PairsGame.ViewModels
{
    [Serializable]
    public class StatisticsViewModel : BaseViewModel
    {
        SerializationAccountActions actions;
        [XmlElement]
        public AccountsViewModel Accounts { get; set; }
        [XmlElement]
        private Account gamer;
        public Account Gamer
        {
            get { return gamer; }
            set
            {
                gamer = value;
                OnPropertyChanged("Gamer");
            }
        }
        public Boolean Lost { get; set; }
        public StatisticsViewModel()
        {
            this.Lost = false;
            this.Accounts = Views.Account.acVM;
            this.Gamer = Accounts.UserList[Accounts.SelectedAccount];
            Gamer.GamePlay++;
            actions = new SerializationAccountActions();
            actions.SerializeObject("conturi.xml", Accounts.UserList);
        }
        public void GameStatus(bool win)
        {
            if (!win)
            {
                this.Lost = true;
                MessageBox.Show("You Lost!");
            }

            if (win)
            {
                Gamer.GameWon++;
                actions.SerializeObject("conturi.xml", Accounts.UserList);
                MessageBox.Show("You Win!");
            }
            OnPropertyChanged("GameStatus");
        }

        public void Award()
        {
            SoundManager.PlayCorrect();
        }

        public void Penalize()
        {
            SoundManager.PlayIncorrect();
        }
    }
}
