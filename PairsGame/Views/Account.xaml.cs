using PairsGame.Utils;
using PairsGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PairsGame.Views
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : UserControl
    {
        public static AccountsViewModel acVM { get; set; }
        SerializationAccountActions actions;
        public Game game { get; set; }
        public Account()
        {
            InitializeComponent();
            acVM = new AccountsViewModel();
            gridUserList.ItemsSource = acVM.UserList;
            this.DataContext = acVM;
            actions = new SerializationAccountActions();
        }
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AccountForm(this.DataContext as AccountsViewModel);
            newWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            actions.SerializeObject("conturi.xml", (DataContext as AccountsViewModel).UserList);
            Application.Current.MainWindow.Close();
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as AccountsViewModel).UserList != null)
            {
                if (System.IO.File.Exists((DataContext as AccountsViewModel).UserList[gridUserList.SelectedIndex].Name + ".xml"))
                {
                    try
                    {
                        System.IO.File.Delete((DataContext as AccountsViewModel).UserList[gridUserList.SelectedIndex].Name + ".xml");
                    }
                    catch (System.IO.IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                (DataContext as AccountsViewModel).UserList.RemoveAt(gridUserList.SelectedIndex);
                actions.SerializeObject("conturi.xml", (DataContext as AccountsViewModel).UserList);
            }
        }

        private void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            acVM.MaxTime = Convert.ToInt32(maxTime.Text);
            acVM.SelectedAccount = gridUserList.SelectedIndex;
            this.game = new Game(4, 4);
            game.ShowDialog();
        }
    }
}
