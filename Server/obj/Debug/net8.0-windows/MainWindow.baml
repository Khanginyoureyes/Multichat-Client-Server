   M S B A M L   `   `   `  ����A  =Server, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ServerServer  5   	       Server.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Server     5   	   -   5          � WindowState$  Normal=�5   	   
������  � 
ResizeMode$ NoResize=�67    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � Title$ Server��5
   	   $	��600��6   $	��850��6%   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ 
bdMainLeft��5       �� CornerRadius$ 	20 0 0 20��6%   ��5      �� 5       �� 
StartPoint$	 0,0&�6&   	 �� EndPoint$		 1,1&�67   .��5      � 
 � Color$
 #26648E��6#    � Offset$ 0Q�63   � 5      $
 #4F8FC0��6#   $	 0.2Q�63   � 5      $
 #53D2DC��6#   $	 0.6Q�63   5      ._�5      � -   5         �Name$
 Left��5      $	��285��6!    � RowDefinitions 5      �� 5      $��80 �6$   �� 5      $
��Auto �6$   .+�5!      �� $��1��6   .+�5"      �� $��SERVER CHAT��6    $��30(�63   $��Black"�6A   $��Center=�6T   $��0 50 0 0q�6q   �� 5#      $��/Server-bro.png��6   $��Center=�65   $��Center=�6R   5$      5%      5&      �� 5)   
   -   5        $ bdMainRight��5)      $��1��6&   
�������$ 	0 20 20 0��6I   ._�5*      �  5+      �� 5,      $��* �6$   �� 5-      $��6* �6$   �� 5.      $��70 �6$   .+�52      �� ���#F0F0F0$ 0 20 0 0��6/   ._�53      � .+�54      �� $��Chats��6$   $��40(�61   $
��Bold"�6?   $
��Left=�6Q   $��Center=�6l   $��5 0 0 0q�6�   �� 55      $��Right=�6%   $	��Top=�6A   $��0 5 10 0q�6Y    �� Orientation$ 
Horizontal=�6k   $��RightToLeft=�6�   .+�56      �� .+�57   "   �� -   5         ��Name$ btClose��57   )      ButtonClose#���   6:   
 �� Top$ 0��6`   6o   �� 58   "   -   5        $ 
btMinimize��58   )     ButtonMinimize#���  6=    �� Left$ 30��6f   6w   59      5:      5;      5<      �� 5?      -   5         ��Name$ 	lvmessage��5?      $��1��6.   5@      �� 5C      $��2��6   ���#F0F0F0$ 0 0 20 0��6<   ._�5D      � .+�5E      �� -   5         ��Name$ 	tbmessage��5E   "     TextBoxMessage#���  66   �� 5F      -	   5        $ btSend��5F   !     
ButtonSend#���  61   6V   5G      5H      5I      5J      5K      5L      