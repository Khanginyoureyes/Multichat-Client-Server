   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   -   5          �Name$  Client��5   	    � WindowState$ Normal=�5   	   
������  � 
ResizeMode$ NoResize=�67    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � Title$ Client��5
   	   $	��600��6   $	��850��6%   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ 
bdMainLeft��5       �� CornerRadius$ 	20 0 0 20��6%   ��5      �� 5      	 �� 
StartPoint$		 0,0&�6&   
 �� EndPoint$	
 1,1&�67   .��5      �  � Color$ #26648E��6#    � Offset$ 0Q�63   � 5      $ #4F8FC0��6#   $	 0.2Q�63   � 5      $ #53D2DC��6#   $	 0.6Q�63   5      ._�5      � -   5         �Name$
 Left��5      $	��285��6!    � RowDefinitions 5      �� 5      $��80 �6$   �� 5      $
��auto �6$   .+�5       d� -   5         d�Name$ tgbMenu��5       $��0��60      ToggleButtonMenu#��[  6=    � Triggers 5!      :� 5"       :� RoutedEvent$ ToggleButton.Checked��6'   .[�5#      �� .��5$   "   �� .��5%   &   W�  �� 
TargetName$
 Left��66    �� TargetProperty$ Width�6S    W� From 2856u   	 W� To 576�    g� Duration$ 0:0:0.3D�6�   5&   #   5'      5(      :� 5*      $ ToggleButton.Unchecked��6'   .[�5+      �� .��5,   "   �� .��5-   &   W� $
 Left��66   $ Width�6S    576u    2856   $ 0:0:0.3D�6�   5.   #   5/      50      52      �� 55      $��1��6   $	��285��6*   .+�56      �� $��YOUR PROFILE��6    $��25(�64   $
��Bold"�6B   $��Center=�6T   A� 57      -   5         A�Name$ elAvatar��57      $	��140��61   $	��140��6=   $��0 10 0 0q�6J   $��Center=�6\   $	��Top=�6y   
�������6�   �� 58      -   5         ��Name$ lbName��58      $
��Name��6,   $��Center=�6;   $��Center=�6X   $��20(�6s   �� 59      -   5        $ lbNationality��59      $��Nationality��63   $��Center=�6I   $��Center=�6f   $��20(�6�   5:      5;      5<      �� 5?   
   -   5        $ bdMainRight��5?      $��1��6&   
�������$ 	0 20 20 0��6I   ._�5@      �  5A      �� 5B      $��* �6$   �� 5C      $��6* �6$   �� 5D      $��70 �6$   .+�5H      �� ���#F0F0F0$ 0 20 0 0��6/   ._�5I      � .+�5J      �� $��Chats��6$   $��40(�61   $
��Bold"�6?   $
��Left=�6Q   $��Center=�6l   $��5 0 0 0q�6�   �� 5K      $��Right=�6%   $	��Top=�6A   $��0 5 10 0q�6Y    �� Orientation$ 
Horizontal=�6k   $��RightToLeft=�6�   .+�5L      �� .+�5M   "   �� -	   5         ��Name$ btClose��5M   )     ButtonClose#���  6:   
 �� Top$ 0��6`   6o   �� 5N   "   -
   5        $ 
btMaximize��5N   )     ButtonMaximize#���  6=    �� Left$ 30��6f   6w   �� 5O   "   -   5        $ 
btMinimize��5O   )     ButtonMinimize#���  6=   $ 60��6f   6w   5P      5Q      5R      5S      �� 5V      -   5         ��Name$ 	lvmessage��5V      $��1��6.   �� 5X      $��2��6   ���#F0F0F0$ 0 0 20 0��6<   ._�5Y      � .+�5Z      �� -   5         ��Name$ 	tbmessage��5Z   %     TextBoxMessage#���  69   �� 5[      -   5        $ btSend��5[   !     
ButtonSend#���  61   6V   5\      5]      5_      5`      5a      5b      