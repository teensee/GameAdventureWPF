   M S B A M L   `   `   `  ���� K  GGaneAdventureWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GaneAdventureWPFGaneAdventureWPF  !    GaneAdventureWPF.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:GaneAdventureWPF       � Title$  
MainWindow��$	��768��$
��1024�� � 	Resources    BooleanToVisibility��%   &	        �� .���  � RowDefinitions �� $
��Auto ��� $��* ��� $	��225 � � ColumnDefinitions �� $	��250 ��� $��* �.+�o� $��0��$��0��.@�m� $
��Menu��.@�m� $
��Save��m� $
��Load���� m� $
��Exit��m� $��About��.@�m� $��
Simple FAQ��m� $��	World map��� $��1��$��0��
������ �� ��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Name:���� $��0��$��1������ *CurrentPlayer.Name+�� $��1��$��0��$��Class:���� $��1��$��1������ *CurrentPlayer.CharacterClass+�� $��2��$��0��$��Hit points:���� $��2��$��1������ * CurrentPlayer.CurrentHitPoints+�� $��3��$��0��$��Gold:���� $��3��$��1������ *CurrentPlayer.Gold+�� $��4��$��0��$	��XP:���� $��4��$��1������ * CurrentPlayer.ExperiencePoints+�� $��5��$��0��$��Level:���� $��5��$��1������ *CurrentPlayer.Level+� $��1��$��1��
������� �� $��* ��� $��* � �� $��3* ��� $��2* �.+��� $��0��$��0��$��2��
�������$��1q�._��� -    ��Name$ GameMessages��
�������" �� VerticalScrollBarVisibility$
 Auto=� �� 
IsReadOnly .   �� 
TargetType �� Property	 �� Value��%3   'J�       �� " J�.���  �@��Margin$	 0q��� $��0��$��1��
�������$��1q�._�� $��3q� �� $��25 ��� $��* ��� $
��Auto �.+��� $��0��$��Center=����� *CurrentLocation.Name+�� $��1��$	��125��$	��125������ *CurrentLocation.ImagePath+�� $��2��$��Center=�$
��Wrap=����� *CurrentLocation.Description+�� $��1��$��1��
�������$��1q�$��0,1,0,0q�._��  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��Center=�$
��Auto������ *CurrentMonster.Name+�� $��1��$	��125��$	��125������ *CurrentMonster.ImageName+�� $��2��$��Center=�
 �� Orientation$
 
Horizontal=�y��� *
HasMonster+ �� 	Converter# [  .+��� $��Hit points: ���� ���� *!CurrentMonster.CurrentHitPoints+� $��2��$��0��
�������.+��� .@��� $��	Inventory��.��&   System.Windows.Controls.DataGrid     AutoGenerateColumns .     HeadersVisibility$ Column=����� * CurrentPlayer.GroupedInventory+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Description��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Item.Name+  $	 Qty��$
 Auto  .  �� *
Quantity+  $ Price��$
 Auto  .  �� *
Item.Price+�� $��Quest��.��   .  $ Column=����� *CurrentPlayer.Quests+   $
 Name��$ *  .  �� *PlayerQuest.Name+  $ 	Complete?��$
 Auto  .  �� *isCompleted+� $��2��$��1��
������� �� $��* � �� $��* ��� $	��255 �.+�� $��0��$��0��$��Center=�$��Center=� �� $
��Auto ��� $
��Auto � �� $	��150 ��� $��10 ��� $��50 �.+��� $��0��$��0�� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ ID������ *CurrentPlayer.Weapons+ �� SelectedItem �� *CurrentPlayer.CurrentWeapon+�� -   $��0��$��2��$	��Use��y��� *
HasMonster+# [  � $��0��$��1�� �� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��1��$��North��y��� *HasLocationToNorth+# [  �� -   $��1��$��0��$
��West��y��� *HasLocationToWest+# [  �� -   $��1��$��1��$��Trade��y��� *	HasTrader+# [  �� -   $��1��$��2��$
��East��y��� *HasLocationToEast+# [  �� -   $��2��$��1��$��North��y��� *HasLocationToSouth+# [  