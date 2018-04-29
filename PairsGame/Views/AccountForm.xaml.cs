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
using System.Windows.Shapes;
using PairsGame.Models;
using PairsGame.ViewModels;
namespace PairsGame.Views
{
    /// <summary>
    /// Interaction logic for AccountForm.xaml
    /// </summary>
    public partial class AccountForm : Window
    {
        public AccountForm(AccountsViewModel accountsViewModel)
        {
            InitializeComponent();
            this.DataContext = accountsViewModel;
        }

        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            //AccountsViewModel start = DataContext as AccountsViewModel;
            string source = "../Resources/Avatars/Image1.png";
            if (Image1.IsChecked == true)
            {
                source = "../Resources/Avatars/Image1.png";
            }
            else if (Image2.IsChecked == true)
            {
                source = "../Resources/Avatars/Image2.png";
            }
            else if (Image3.IsChecked == true)
            {
                source = "../Resources/Avatars/Image3.png";
            }
            else if (Image4.IsChecked == true)
            {
                source = "../Resources/Avatars/Image4.png";
            }
            else if (Image5.IsChecked == true)
            {
                source = "../Resources/Avatars/Image5.png";
            }
            else if (Image6.IsChecked == true)
            {
                source = "../Resources/Avatars/Image6.png";
            }
            Models.Account User = new Models.Account
            {
                Name = userName.Text,
                ImgUrl = source


            };
            (DataContext as AccountsViewModel).UserList.Add(User);
            this.Close();
        }
    }
}
