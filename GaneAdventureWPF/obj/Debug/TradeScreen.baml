   M S B A M L   `   `   `  ����A  =Engine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE/clr-namespace:Engine.ViewModels;assembly=EngineEngine.ViewModels  5   	   K GGaneAdventureWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GaneAdventureWPFGaneAdventureWPF 5	   	   "   GaneAdventureWPF.TradeScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   F
viewModels/clr-namespace:Engine.ViewModels;assembly=Engine     5   	   0localclr-namespace:GaneAdventureWPF     5	   	     � WindowStartupLocation$  CenterOwner=�5   	    � Title$ Trade Screen��5   	   $	��480��6   $	��640��6+   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��2��5      $��Center=�5      ��5      �� *CurrentTrader.Name+�� 5   
   $��1��6   $��0��6   $��Center=�5      $��Your inventory��5       �� 5"   
   $��1��6   $��1��6   $��Center=�5#      $��Trader inventory��5$      &   System.Windows.Controls.DataGrid  5&   
   $��2��6   $��0��6    $��10q�5'         AutoGenerateColumns .     HeadersVisibility$ Column=�5)         CanUserAddRows .     CanUserDeleteRows .  "   VerticalScrollBarVisibility$
 Auto=�5,      ��5'      �� * CurrentPlayer.GroupedInventory+	   Columns	 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Description��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 51   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 52   %   �� *	Item.Name+  54      $	
 Qty��6%    . $
 Auto 56   %    57   %   �� *
Quantity+  59      $
 Price��6%    . $
 Auto 5;   %    5<   %   �� *
Item.Price+4  .System.Windows.Controls.DataGridTemplateColumn  5=         MinWidth$ 75Q�6)      CellTemplate 5>      �� 5?      .R�5@      �� -   5        $
��Sell��5@   %   5A   %   5B      5D      5F        5H   
   $��2��6   $��1��6    $��10q�5I       .  $ Column=�5K       .   .  $
 Auto=�5N      ��5I      �� * CurrentTrader.GroupedInventory+	 5O        5Q      $
 Description��6%    . $ * 5S   %    5T   %   �� *	Item.Name+  5V      $	
 Qty��6%    . $
 Auto 5X   %    5Y   %   �� *
Quantity+  5[      $
 Price��6%    . $
 Auto 5]   %    5^   %   �� *
Item.Price+  5_      $ 75Q�6)    5`      �� 5a      .R�5b      �� -   5        $	��Buy��5b   %   5c   %   5d      5f      5h      5i      5j      