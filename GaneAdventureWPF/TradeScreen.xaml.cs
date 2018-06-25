using Engine.Models;
using Engine.ViewModels;
using System;
using System.Windows;

namespace GaneAdventureWPF
{
    /// <summary>
    /// Логика взаимодействия для TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        public GameSessionViewModel Session => DataContext as GameSessionViewModel;

        public TradeScreen()
        {
            InitializeComponent();
        }

        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = 
                ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if(groupedInventoryItem != null)
            {
                Session.CurrentPlayer.Gold += groupedInventoryItem.Item.Price;
                Session.CurrentTrader.AddItemToInventory(groupedInventoryItem.Item);
                Session.CurrentPlayer.RemoveItemFromInventory(groupedInventoryItem.Item);
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GroupedInventoryItem groupedInventoryItem = ((FrameworkElement)sender).DataContext as GroupedInventoryItem;

            if (groupedInventoryItem != null)
            {
                if (Session.CurrentPlayer.Gold >= groupedInventoryItem.Item.Price)
                {
                    Session.CurrentPlayer.Gold -= groupedInventoryItem.Item.Price;
                    Session.CurrentPlayer.AddItemToInventory(groupedInventoryItem.Item);
                    Session.CurrentTrader.RemoveItemFromInventory(groupedInventoryItem.Item);
                }

                else
                    MessageBox.Show("You do not have enough gold");

            }
        }
    }
}
