   M S B A M L   `   `   `  ����K  GGaneAdventureWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GaneAdventureWPFGaneAdventureWPF  5   	       GaneAdventureWPF.WorldMap   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:GaneAdventureWPF     5   	     � WindowStartupLocation$  CenterOwner=�5   	    � Title$ WorldMap��5	   	   $	��450��6   $	��600��6'   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��2��6   $��3��5      $��1q�5      
�������$��1q�5      ._�5!      �� .+�5"      �� $��45,5,0,0q�6   ._�5#      �� $
��Home��6    5$      �� 5%      $	��117��6   $	��103��6$   $E��?D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\Home.png��61   5&      5'      �� 5)   
   $��1��6   $��3��5*      $��1q�5+      
�������$��1q�5-      ._�5/      �� .+�50      �� $��15,5,0,0q�6   ._�51      �� $��Farmer's House��6    52      �� 53      $	��117��6   $	��103��6$   $J��DD:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\Farmhouse.png��61   54      55      �� 57   
   $��0��6   $��3��58      $��1q�59      
�������$��1q�5;      ._�5=      �� .+�5>      �� $��20,5,0,0q�6   ._�5?      �� $��Farmer's Field��6    5@      �� 5A      $	��117��6   $	��103��6$   $K��ED:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\FarmFields.png��61   5B      5C      �� 5E   
   $��2��6   $��2��5F      $��1q�5G      
�������$��1q�5I      ._�5K      �� .+�5L      �� $��45,5,0,0q�6    K� ZIndex$ 1��6+   ._�5M      �� $
��Home��6    5N      �� 5O      $	��117��6   $	��103��6$   $K��ED:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\TownSquare.png��61   5P      5Q      �� 5S   
   $��1��6   $��2��5T      $��1q�5U      
�������$��1q�5W      ._�5Y      �� .+�5Z      �� $��45,5,0,0q�6   $ 1��6+   ._�5[      �� $
��Home��6    5\      �� 5]      $	��117��6   $	��103��6$   $G��AD:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\Trader.png��61   5^      5_      �� 5a   
   $��3��6   $��2��5b      $��1q�5c      
�������$��1q�5e      ._�5g      �� .+�5h      �� $��45,5,0,0q�6   ._�5i      �� $
��Home��6    5j      �� 5k      $	��117��6   $	��103��6$   $I��CD:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\TownGate.png��61   5l      5m      �� 5o   
   $��4��6   $��2��5p      $��1q�5q      
�������$��1q�5s      ._�5u      �� .+�5v      �� $��45,5,0,0q�6   $ 1��6+   ._�5w      �� $
��Home��6    5x      �� 5y      $	��117��6   $	��103��6$   $M��GD:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\SpiderForest.png��61   5z      5{      �� 5}   
   $��2��6   $��1��5~      $��1q�5      
�������$��1q�5�      ._�5�      �� .+�5�      �� $��45,5,0,0q�6   $ 1��6+   ._�5�      �� $
��Home��6    5�      �� 5�      $	��117��6   $	��103��6$   $N��HD:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\HerbalistsHut.png��61   5�      5�      �� 5�   
   $��2��6   $��0��5�      $��1q�5�      
�������$��1q�5�      ._�5�      �� .+�5�      �� $��45,5,0,0q�6   $ 1��6+   ._�5�      �� $
��Home��6    5�      �� 5�      $	��115��6   $	��101��6$   $Q��KD:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\HerbalistsGarden.png��61   5�      5�      5�      5�      