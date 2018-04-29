using PairsGame.Utils;
using PairsGame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace PairsGame.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    [Serializable]
    public partial class Game : Window
    {
        public GameViewModel newGame;
        public Game(int lineDim, int columnDim)
        {
            InitializeComponent();
            newGame = new GameViewModel();
            newGame.lineDim = lineDim;
            newGame.columnDim = columnDim;
            StartGame();
        }
        public void StartGame()
        {
            newGame.SetupGame(newGame.lineDim, newGame.columnDim);
            CreateTable();
        }
        public void LoadGame()
        {
            CreateTable();
            newGame.Timer.Start();
        }
        public void CreateTable()
        {
            this.DataContext = newGame;
            SoundManager.PlayBackgroundMusic();
            int posD = -1;

            for (var rowsToRemove = cardGrid.RowDefinitions.Count; rowsToRemove > 0; rowsToRemove--)
            {
                cardGrid.RowDefinitions.RemoveAt(0);
            }
            for (var columnsToRemove = cardGrid.ColumnDefinitions.Count; columnsToRemove > 0; columnsToRemove--)
            {
                cardGrid.ColumnDefinitions.RemoveAt(0);
            }
            for (var childrenToRemove = cardGrid.Children.Count; childrenToRemove > 0; childrenToRemove--)
            {
                cardGrid.Children.RemoveAt(0);
            }
            for (int i = 0; i < newGame.lineDim; i++)
                cardGrid.RowDefinitions.Add(new RowDefinition());
            for (int i = 0; i < newGame.columnDim; i++)
                cardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < newGame.lineDim; i++)
                for (int j = 0; j < newGame.columnDim; j++)
                {
                    posD++;
                    string xml = "<Button xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"";
                    xml += " xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"";
                    xml += " Grid.Row=\"" + i + "\" Grid.Column=\"" + j + "\"";
                    xml += " IsEnabled=\"{Binding isSelectable}\"";
                    xml += " DataContext=\"{ Binding MemoryCards[" + posD + "]}\">";
                    xml += " <Button.Template><ControlTemplate>";
                    xml += " <Border ";
                    xml += " BorderBrush=\"{Binding BorderBrush}\" >";
                    xml += "  <Image Stretch = \"Fill\" Source = \"{Binding SlideImage}\" />";
                    xml += " </Border></ControlTemplate></Button.Template></Button>";


                    Stream strm = new MemoryStream(ASCIIEncoding.Default.GetBytes(xml));
                    Button myButton = (Button)System.Windows.Markup.XamlReader.Load(strm);
                    myButton.Click += Slide_Clicked;
                    cardGrid.Children.Add(myButton);
                }
        }
        private void Slide_Clicked(object sender, RoutedEventArgs e)
        {
            var game = DataContext as GameViewModel;
            var button = sender as Button;
            game.ClickedSlide(button.DataContext);
        }
        private void MenuItemFileNewGame_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.PlayIncorrect();
            StartGame();
        }

        private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            SerializationAccountActions actions = new SerializationAccountActions();
            actions.SerializeObject("conturi.xml", (DataContext as AccountsViewModel).UserList);
            Window.GetWindow(this).Close();
        }

        private void MenuItemOptions4x4_Click(object sender, RoutedEventArgs e)
        {
            newGame.lineDim = 4;
            newGame.columnDim = 4;
            StartGame();
        }

        private void MenuItemOptions6x6_Click(object sender, RoutedEventArgs e)
        {
            newGame.lineDim = 6;
            newGame.columnDim = 6;
            StartGame();
        }

        private void MenuItemFileStatistics_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Utilizator:" + (DataContext as GameViewModel).GameInfo.Gamer.Name + 
                "\nJocuri castigate:" + (DataContext as GameViewModel).GameInfo.Gamer.GameWon + 
                "\nJocuri jucate:" + (DataContext as GameViewModel).GameInfo.Gamer.GamePlay);
        }

        private void MenuItemOptionsaxb_Click(object sender, RoutedEventArgs e)
        {
            Dimension dimension = new Dimension(this);
            dimension.ShowDialog();
        }

        private void MenuItemFileOpenGame_Click(object sender, RoutedEventArgs e)
        {
            OpenFile openFiles = new OpenFile(this);
            openFiles.ShowDialog();
        }

        private void MenuItemFileSaveGame_Click(object sender, RoutedEventArgs e)
        {
            SerializationGameActions actions = new SerializationGameActions();
            actions.SerializeObject(newGame.GameInfo.Gamer.Name.ToString()+".xml", newGame);
        }

        private void MenuItemHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            About box = new About();
            box.ShowDialog();
        }
    }
}
