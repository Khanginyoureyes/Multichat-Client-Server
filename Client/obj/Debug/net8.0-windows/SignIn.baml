   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.SignIn   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  SignIn��5   	   $	��600��6   $	��850��6%   
������  � 
ResizeMode$ NoResize=�6J    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � WindowState$ Normal=�66    � WindowStartupLocation$ CenterScreen=�6K   .��5
      ��  �� CornerRadius$ 30��6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      � 	 � Color$	 #26648E��6   
 � Offset$
 0Q�6/   � 5      $	 #4F8FC0��6   $	
 0.2Q�6/   � 5      $	 #53D2DC��6   $	
 0.6Q�6/   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��/Programming-rafiki.png��6   $��Center=�65   $��Center=�6R   � 5      $��1��6    � RowDefinitions 5      �� 5      $��60 �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5#      �� $��0��6   $��Right=�6*   $	��Top=�6F   $��0 5 10 0q�6^    �� Orientation$ 
Horizontal=�6p   $��RightToLeft=�6�   .+�5$      �� .+�5%      �� -   5         ��Name$ btClose��5%   !      ButtonClose#���   62   
 �� Top$ 0��6X   6g   �� 5&      -   5        $ 
btMinimize��5&   !     ButtonMinimize#���  65    �� Left$ 30��6^   6o   5'      5(      �� 5)      $��1��6   $��ĐĂNG NHẬP��6)   $
��Left=�6:   $��	70 60 0 0q�6U   $��30(�6h   $
��Bold"�6v   �� 5+      $��2��6   $��
70 10 70 0q�6*   .+�5,      �� $
��Left=�6    $��Email:��6;   $��20(�6I   $
��Bold"�6W   �� 5-      -   5         ��Name$ txtEmail��5-        TextBoxInformation#���  60   �� 5.      $
��Left=�6    $��	Password:��6;   $��20(�6L   $
��Bold"�6Z   $��0 10 0 0q�6l   G� 5/      -   5         G�Name$ txtPassword��5/   "     PasswordBox#���  67   50      �� 52      $��3��6   $��	70 0 70 0q�6*   .+�53      �� -   5        $ btSignIn��53      $��3��6/   $��Đăng Nhập��6<   $��20(�6P   $��Center=�6^   $	��Top=�6{   $	��170��6�   $��50��6�   $��0 30 0 0q�6�    � Cursor$
 Hand��6�   ��54      �� 55       �� 
TargetType" ��6.   .R�56   "   � .+�57   &   �� 
����ح�$ 20��6D   $��1q�6V    J� Effect 58   *   3  -System.Windows.Media.Effects.DropShadowEffect  59   .      Color$ Black��6?      
BlurRadius$ 10Q�6M      	Direction$	 320Q�6]      ShadowDepth$ 5Q�6m      Opacity$	 0.5Q�6}   5;   '   �� 5<   &   $��Center=�67   $��Center=�6T   5=   #   5>      5@      �� 5A      $��Hoặc��6    $��Center=�6,   $��25(�6I   $��	0 10 0 10q�6W   �� 5B      -   5        $ btSignUp��5B      $��3��6/   $��
Đăng Ký��6<   $��20(�6N   $��Center=�6\   $	��Top=�6y   $	��170��6�   $��50��6�   $
 Hand��6�   ��5C      �� 5D      " ��6.   .R�5E   "   � .+�5F   &   �� 
����ح�$ 20��6D   $��1q�6V    5G   *     5H   .   $ Black��6?   $ 10Q�6M   $	 320Q�6]   $ 5Q�6m   $	 0.5Q�6}   5J   '   �� 5K   &   $��Center=�67   $��Center=�6T   5L   #   5M      5O      5P      5R      5S      5T      5V      