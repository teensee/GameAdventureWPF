﻿using Engine.Models;
using Engine.ViewModels;
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
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if(item != null)
            {
                Session.CurrentPlayer.Gold += item.Price;
                Session.CurrentTrader.AddItemToInventory(item);
                Session.CurrentPlayer.RemoveItemFromInventory(item);
            }
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if (item != null)
            {
                if (Session.CurrentPlayer.Gold >= item.Price)
                {
                    Session.CurrentPlayer.Gold -= item.Price;
                    Session.CurrentPlayer.AddItemToInventory(item);
                    Session.CurrentTrader.RemoveItemFromInventory(item);
                }

                else
                    MessageBox.Show("You do not have enough gold");

            }
        }
    }
}
