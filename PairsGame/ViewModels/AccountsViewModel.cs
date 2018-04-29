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
    public class AccountsViewModel : BaseViewModel
    {
        public AccountsViewModel()
        {
            SerializationAccountActions actions = new SerializationAccountActions();
            UserList = new ObservableCollection<Account>();
            UserList = actions.DeserializeObject("conturi.xml");
        }
        [XmlArray]
        public ObservableCollection<Account> UserList { get; set; }
        private int selectedAccount;
        public int SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
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
    }
}
