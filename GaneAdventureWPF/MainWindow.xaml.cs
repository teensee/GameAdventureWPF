using System.Windows;
using Engine.ViewModels;

namespace GaneAdventureWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameSessionViewModel _gs;
        public MainWindow()
        {
            _gs = new GameSessionViewModel();
            InitializeComponent();
            DataContext = _gs;
        }

        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            _gs.MoveNorth();
        }

        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gs.MoveWest();             
        }

        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gs.MoveEast();
        }

        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gs.MoveSouth();
        }
        
    }
}
