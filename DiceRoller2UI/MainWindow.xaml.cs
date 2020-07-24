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
using DiceRoller.Library;

namespace DiceRoller2UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            VantageType vantageType = GetVantage();
            var diceTray = new DiceTray(diceSelector.Text, diceCount.Text, modifier.Text, vantageType);
            var rollMessage = new RollMessage();
            string message = rollMessage.ComposeMessage(diceTray);
            string caption = rollMessage.ComposeCaption(diceTray);
            MessageBox.Show(this, message, caption);
        }

        private VantageType GetVantage()
        {
            if (Normal.IsChecked == true)
            {
                return VantageType.NoVantage;
            }
            else if (Advantage.IsChecked == true)
            {
                return VantageType.Advantage;
            }
            else if (Disadvantage.IsChecked == true)
            {
                return VantageType.Disadvantage;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
