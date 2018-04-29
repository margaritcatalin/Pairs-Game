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
using System.Windows.Shapes;

namespace PairsGame.Views
{
    /// <summary>
    /// Interaction logic for Dimension.xaml
    /// </summary>
    public partial class Dimension : Window
    {
        Game game { get; set; }
        public Dimension(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.DataContext = game;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.game.newGame.lineDim= Convert.ToInt32(rowsDims.Text);
            this.game.newGame.columnDim = Convert.ToInt32(columnDims.Text);
            this.game.StartGame();
            this.Close();
        }
    }
}
