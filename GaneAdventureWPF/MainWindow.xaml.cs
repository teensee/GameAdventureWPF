using System.Windows;
using System.Windows.Documents;
using Engine.EventArgs;
using Engine.ViewModels;

namespace GaneAdventureWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameSessionViewModel _gameSessionVM;
        public MainWindow()
        {
            InitializeComponent();

            _gameSessionVM = new GameSessionViewModel();

            _gameSessionVM.OnMessageRaised += _gameSessionVM_OnMessageRaised;

            DataContext = _gameSessionVM;

        }

        private void _gameSessionVM_OnMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }

        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            _gameSessionVM.MoveNorth();
        }

        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gameSessionVM.MoveWest();             
        }

        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gameSessionVM.MoveEast();
        }

        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gameSessionVM.MoveSouth();
        }

        private void OnClick_AttackMonster(object sender, RoutedEventArgs e)
        {
            _gameSessionVM.AttackCurrentMonster();
        }

        private void OnClick_DisplayTradeScreen(object sender, RoutedEventArgs e)
        {
            TradeScreen trade = new TradeScreen();
            trade.Owner = this;
            trade.DataContext = _gameSessionVM;
            trade.ShowDialog();
        }
    }
}
