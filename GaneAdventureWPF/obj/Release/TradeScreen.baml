   M S B A M L   `   `   `  ���� A  =Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE/clr-namespace:Engine.ViewModels;assembly=EngineEngine.ViewModels  K GGaneAdventureWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GaneAdventureWPFGaneAdventureWPF "   GaneAdventureWPF.TradeScreen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     F
viewModels/clr-namespace:Engine.ViewModels;assembly=Engine     0localclr-namespace:GaneAdventureWPF       � WindowStartupLocation$  CenterOwner=� � Title$ Trade Screen��$	��480��$	��640��.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$��0��$��2��$��Center=����� *CurrentTrader.Name+�� $��1��$��0��$��Center=�$��Your inventory���� $��1��$��1��$��Center=�$��Trader inventory��&   System.Windows.Controls.DataGrid  $��2��$��0��$��10q�   AutoGenerateColumns .     HeadersVisibility$ Column=�   CanUserAddRows .     CanUserDeleteRows .  "   VerticalScrollBarVisibility$
 Auto=����� * CurrentPlayer.GroupedInventory+	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Description��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Item.Name+  $	
 Qty�� . $
 Auto  �� *
Quantity+  $
 Price�� . $
 Auto  �� *
Item.Price+4  .System.Windows.Controls.DataGridTemplateColumn     MinWidth$ 75Q�   CellTemplate �� .R��� -   $
��Sell��  $��2��$��1��$��10q� .  $ Column=� .   .  $
 Auto=����� * CurrentTrader.GroupedInventory+	   $
 Description�� . $ *  �� *	Item.Name+  $	
 Qty�� . $
 Auto  �� *
Quantity+  $
 Price�� . $
 Auto  �� *
Item.Price+  $ 75Q� �� .R��� -   $	��Buy��