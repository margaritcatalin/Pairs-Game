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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : UserControl
    {
        private CreateAccViewModel accViewModel;
        public CreateAccount()
        {
            InitializeComponent();
            accViewModel = new CreateAccViewModel();
            this.DataContext = accViewModel;
        }

        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            accViewModel.User.Name = userName.Text;
            if (Image1.IsChecked == true)
            {
                accViewModel.User.ImgUrl = "../Resources/Avatars/Image1.png";
            }
            else if (Image2.IsChecked == true)
            {
                accViewModel.User.ImgUrl = "../Resources/Avatars/Image2.png";
            }
            else if (Image3.IsChecked == true)
            {
                accViewModel.User.ImgUrl = "../Resources/Avatars/Image3.png";
            }
            else if (Image4.IsChecked == true)
            {
                accViewModel.User.ImgUrl = "../Resources/Avatars/Image4.png";
            }
            else if (Image5.IsChecked == true)
            {
                accViewModel.User.ImgUrl = "../Resources/Avatars/Image5.png";
            }
            else if (Image6.IsChecked == true)
            {
                accViewModel.User.ImgUrl = "../Resources/Avatars/Image6.png";
            }
        }
    }
}
