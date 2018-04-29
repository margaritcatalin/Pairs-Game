using Microsoft.Win32;
using PairsGame.Utils;
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
    /// Interaction logic for OpenFile.xaml
    /// </summary>
    public partial class OpenFile : Window
    {
        public Game Game { get; set; }
        public OpenFile(Game game)
        {
            InitializeComponent();
            this.DataContext = game;
            this.Game = game;
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Filter = "Xml Files|*.xml|All Files|*.*";
            fileDialog.DefaultExt = ".xml";
            Nullable<bool> dialogOK = fileDialog.ShowDialog();

            if (dialogOK == true)
            {
                string sFilenames = "";
                foreach (string sFilename in fileDialog.FileNames)
                {
                    sFilenames += ";" + sFilename;
                }
                sFilenames = sFilenames.Substring(1);
                tbxFile.Text = sFilenames;
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (tbxFile.Text.Contains(Game.newGame.GameInfo.Gamer.Name)){
                SerializationGameActions actions = new SerializationGameActions();
                Game.newGame = actions.DeserializeObject(tbxFile.Text);
                Game.LoadGame();
            }
            else
            {
                MessageBox.Show("ERROR!\nNot your save!");
            }
            this.Close();
        }
    }
}
