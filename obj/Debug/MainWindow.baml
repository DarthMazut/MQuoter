   M S B A M L   `   `   `  ����B  >MQuoter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MQuoterMQuoter  5   	   7 clr-namespace:MQuoter.PropertiesMQuoter.Properties  5   	       MQuoter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MQuoter     5   	   7
properties clr-namespace:MQuoter.Properties     5   	     � Title$  MQuoter��5	   	   $	��500��6   $	��750��6&    � WindowStyle$
 None=�62    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�6_   .��5      � -   5         �Name$ xe_MainGrid��5      ��5   
   �� 5       �� ImageSource$ 
img/bg.jpg��6    j� Stretch$ UniformToFill=�62    � RowDefinitions 5   
   �� 5      $��24 �6   �� 5      $��* �6   .+�5   
   � -   5        $��xe_TitleBar��5      ��6"   �� !  MQuoter.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 BorderColor� � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��img/MQuoter.png��6   $��20��6-   $��20��68    �� BitmapScalingMode$ HighQuality=�6E   �� 5      $��1��6      ApplicationTitle#��[  6(   $��16(�6Q    �� Padding$ 5,0,0,0q�6_   
���   �6q   �� 5!      $��3��6    �� Orientation$ 
Horizontal=�6)   .+�5"      �� -   5          TitleBarSettings#��[ 5"      6F   �� 5#      -   5         ��Name$ xe_HelpButton��5#        TitleBarHelp#��[ 63   6Y   �� 5$      -   5          TitleBarMinimize#��[ 5$      6F   �� 5%      -   5        $ xe_MinMaxButton��5%        TitleBarMaximize#��[ 65   6_   �� 5&      -   5          TitleBarClose#��[ 5&      6C   5'      5)      �� 5+   
   $��1��6   $��3,0,3,3q�6   $��2��6t   ��68   �� *
Background+ �� ElementName$ xe_TitleBar��._�5-      �  5.      �� 5/      $��* �6'   �� 50      $��* �6'    52      �� 53      $��5* �6$   �� 54      $��3* �6$   .+�57      �� $
��Left=�6   $	��Top=�64   $��5,5,0,0q�6L   $��32��6]   $��32��6h     SmallButton#��[ 6t   ._�58      �� -   5        $��img/delete.png��58      $
��Fill=�64   $��32��6C   $��32��6N   $��Center=�6Z   $��Center=�6w   $ HighQuality=�6�    � ToolTip 59      _� 5:        ToolTipClear#��[ 6&     ToolTipStyle#��[ 6N   5<      5=      �� 5?      $
��Left=�6   $	��Top=�64   $��42,5,0,0q�6L   $��32��6^   $��32��6i   #��[ 6u   ._�5@      �� -	   5        $��img/copy.png��5@      $��24��62   $��24��6=   $��Center=�6I   $��Center=�6f   $ HighQuality=�6�   $
��Fill=�6�    5A      _� 5B       	 ToolTipCopy#��[	 6&   #��[ 6M   5D      5E      �� 5G      $
��Left=�6   $	��Top=�64   $��76,5,0,0q�6L   $��32��6^   $��32��6i   #��[ 6u   ._�5H      �� -
   5        $��img/cursor.png��5H      $��24��64   $��24��6?   $��Center=�6K   $��Center=�6h   $ HighQuality=�6�   $
��Fill=�6�    5I      _� 5J       
 ToolTipCursor#��[
 6&   #��[ 6O   5L      5M      �� 5O      $
��Left=�6   $	��Top=�64   $��	109,5,0,0q�6L   $��32��6_   $��32��6j   #��[ 6v   ._�5P      �� -   5        $��img/sound.png��5P      $��24��63   $��24��6>   $��Center=�6J   $��Center=�6g   $ HighQuality=�6�   $
��Fill=�6�    5Q      _� 5R        ToolTipRead#��[ 6&   #��[ 6M   5T      5U      �� 5W      $
��Left=�6   $	��Top=�64   $��	143,5,0,0q�6L   $��32��6_   $��32��6j   #��[ 6v   ._�5X      �� -   5        $��img/sum.png��5X      $��24��61   $��24��6<   $��Center=�6H   $��Center=�6e   $ HighQuality=�6�   $
��Fill=�6�    5Y      _� 5Z        ToolTipStats#��[ 6&   #��[ 6N   5\      5]      �� 5`      $	��200��6   $	��200��6%   $��Right=�62   $��0,0,40,0q�6N   $��Center=�6`     
MouseImage#��[ 6{   ._�5a      �� -   5        $��img/mouse.png��5a      $
��Fill=�63    5b      _� 5c      #��[ 6&     ToolTipMysh#��[ 6L   5e      5f      �� 5h      $��1��6   $	��200��6)   $	��200��65   $
��Left=�6B   $��40,0,0,0q�6]   $��Center=�6o   #��[ 6�   ._�5i      �� -   5        $��img/teddy.png��5i      $
��Fill=�63    5j      _� 5k      #��[ 6&     
ToolTipMis#��[ 6L   5m      5n      �� 5p      $��2��6   $��1��6-   $��Stretch=�6:   $��Center=�6X    �� CornerRadius$ 15��6s   $	��100��6�   $��	30,0,30,0q�6�     QuoteBox#��[ 6�   ._�5q      �� -   5        $ xe_TextBox_Quote��5q       $��Center=�6:   $��Center=�6U   $��
SegoePring)�6r   $��16(�6�   
�������  	ClearText#��[ 6�   5r      5t      5u      5w      5x      