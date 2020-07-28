using DiceRoller.Library;
using System;
using System.Windows;

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
            var rollMessage = new RollMessage(diceTray);
            string message = $"You Rolled {rollMessage.RollMade}\n" +
                $"Your rolls were {rollMessage.Rolls}\n" +
                $"Result = {rollMessage.Result}";
            MessageBox.Show(this, message, rollMessage.CritMessage);
        }

        private VantageType GetVantage()
        {
            if (Advantage.IsChecked == true)
            {
                return VantageType.Advantage;
            }
            else if (Disadvantage.IsChecked == true)
            {
                return VantageType.Disadvantage;
            }
            else
            {
                return (VantageType.NoVantage);
            }
        }
    }
}
