   M S B A M L   `   `   `  ����B  >MQuoter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MQuoterMQuoter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ApplicationTitle  TitleBarButtonClose  TitleBarButtonMaximize  TitleBarButtonMinimize  TitleBarButtonRestore  TitleBarButtonHelp  TitleBarButtonSettings  ToolTipMysh  
ToolTipMis 	 ToolTipClear 
 ToolTipCopy  ToolTipCursor  ToolTipRead  ToolTipStats  NoQuotesMis  NoQuotesMysh  NrQuotesMis  NrQuotesMysh  NrAppStartsTime  AboutVersion  	AboutInfo  	ClearText  S� 
MethodName S� 
ObjectType   System.Type  colorsTypeOdp S� MethodParameters S� ObjectInstance  colorPropertiesOdp  MouseBackgroundHoover � Color � Offset  MouseBackground  QuoteDefaultColor �� Color  TitleBarButtons �� 
TargetType �� Property	 �� Value
 �� Triggers P� Property P� Value N� EnterActions g� Duration	 W� To �� TargetProperty N� ExitActions  TitleBarClose �� BasedOn  TitleBarMaximize  TitleBarRestore  TitleBarMinimize   TitleBarHelp ! TitleBarHelpNoAnim " TitleBarSettings # 
MouseImage $ SmallButton % ToolTipStyle & QuoteBox	 �� To�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:MQuoter  5      1system&clr-namespace:System;assembly=mscorlib  5      %�  &	        &	 3     &	 R     &	 v     &	 �     &	 �     &	 �     &	     &	 #    &		 E    &	
 l    &	 �    &	 �    &	 �    &	     &	 I    &	 �    &	 �    &	 �    &	     &	 �    &	 �    &	 H    &	     7  &	 F    &	 �    &	 r	    &	 �	    &	 �    7  7  &	 #    7  7  &	 +    7  7  &	 3    7  7  &	  a    7  7  &	! �    7  &	" �    7  7  &	#     7  7  &	$ �    &	% �    &	& �    ��5      MQuoter - cytaty jego i jej��6J   ��5      Zamknij��69   ��5      Maksymalizuj��6A   ��5	      Minimalizuj��6@   ��5
      Przywróć w dół��6B   ��5      	Pomoc��66   ��5      
Ustawienia��6?   ��5      	Cytat jej��63   ��5      
Cytat jego��63   ��5      Wyczyść cytat��68   ��5      Kopiuj cytat��66   ��5      Zmień kursor��68   ��5      Przeczytaj cytat��6:   ��5      Pokaż statystyki��6;   ��5      /+On nie posiada jeszcze żadnych cytatów :(��6S   ��5      0,Ona nie posiada jeszcze żadnych cytatów :(��6U   ��5      Liczba cytatów jego:��6>   ��5      Liczba cytatów jej:��6>   ��5       Aplikacja była uruchamiana:��6J   ��5      SOMQuoter - cytaty jego i jej
Wesja 1.0
Wszelkie prawa zastrzeżone 
© 2018
    ��5      ��5!      ��Niniejsza aplikacja została wyczarowana przez Pana Misia Czarodzieja dla Ślicznej Pani Myszki. Aplikacja wykorzystuje odpowiednio sformatowany plik "data.dat", który powinien znajdować się w tym samym folderze co plik *.exe. Z pliku wczytywane są cytaty i dzielone na cytaty jego oraz jej. Po kliknięciu na ikonę zostanie wyświetlony odpowiedni cytat. Aplikacja daje dodatkowo możliwość kopiowania cytatu do schowka, zmiany kursora na takie słodkiego miśka xD oraz odczytywania cytatu za pomocą wbudowanego w system Windows syntezatora mowy (niestety umie on czytać tylko po angielsku).
        
Jeśli chcesz zmienić tło aplikacji to utwórz folder "img" i wklej do niego plik *.jpg o nazwie "bg". 
        
Ikonki do aplikacja pochodzą ze strony "http://www.iconarchive.com".
    ��5&      ��5(      lh
MQuoter - cytay jego i jej.
        
Naciśnij ikonę myszy lub miśka aby otrzymać losowy cytat.
    ��5,      S� 5/      $  GetType��6   "   6.    50   
   ��51      tpSystem.Windows.Media.Colors, PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35��55      57      S� 59      8   $  GetProperties��6I   6d   
� 5=      .��5>   
   � $ 	#FFFFFF00��6   $ 0Q�6)   � 5?   
   $ 1Q�6   � 5@   
   $ 	#BFFFFF00��6   $
 0.75Q�6)   5A      
� 5C      .��5D   
   � $ White��6   $ 0Q�6%   � 5E   
   $ 1Q�6   � 5F   
   $ 	#BFFFFFFF��6   $
 0.75Q�6)   5G      �� 5J      $ White��60   �� 5L      " ��6$   .�5M   
   ��  � ��$	 16(�6%   �� 5N   
    � ��$	 24��6%   �� 5O   
    � ��
	 �   �6'   �� 5P   
    �@��TextAlignment$	 Center=�6*   �� 5Q   
    �@��Padding$	 3,0,3,0q�6$   
 5S   
   P� 5T       �@J�IsMouseOver . . �5U      ��  � ��$	 24��6*    5W      �� 5X      .��5Y      �� .��5Z      W� $ 0:0:0.25D�6.   $	 120X�6B   $ Width�6K   5[      5\       5^      �� 5_      .��5`      �� .��5a      W� $ 0:0:0.25D�6.   $ 24X�6B   $ Width�6J   5b      5c      5f      5i      �� 5k      " ��6"   8   
 5l   
   P� 5m       �@J�IsMouseOver . . �5n      ��  � ��
	 ��p��6/   �� 5o       � ��8	  6)   �� 5p       � ��$	 24��6*    5r      �� 5s      .��5t      �� .��5u      W� $ 0:0:0.25D�6.   $ 90X�6B   $ Width�6J   5v      5w       5y      �� 5z      .��5{      �� .��5|      W� $ 0:0:0.25D�6.   $ 24X�6B   $ Width�6J   5}      5~      5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��$	 X��6)   5�      5�      �� 5�      " ��6%   8   
 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
	 �����6/   �� 5�       � ��8	  6)   5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��$		 [ ]��6)   5�      5�      �� 5�      " ��6$   8   
 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
	 �����6/   �� 5�       � ��8	  6)   5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��$		 [ ]��6)   5�      5�      �� 5�      " ��6%   8   
 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
	 �����6/   �� 5�       � ��8	  6)   �� 5�       � ��$	 24��6*    5�      �� 5�      .��5�      �� .��5�      W� $ 0:0:0.25D�6.   $ 90X�6B   $ Width�6J   5�      5�       5�      �� 5�      .��5�      �� .��5�      W� $ 0:0:0.25D�6.   $ 24X�6B   $ Width�6J   5�      5�      5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��$	 _��6)   5�      5�      �� 5�      " ��6!   8   
 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
	 �����6/   �� 5�       � ��8	  6)   �� 5�       � ��$	 24��6*   5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��$	 ?��6)   5�      5�      �� 5�      " ��6'   .�5�   
   ��  � ��$	 16(�6%   �� 5�   
    � ��$	 24��6%   �� 5�   
    � ��
	 �   �6'   �� 5�   
    �@��TextAlignment$	 Center=�6*   �� 5�   
    �@��Padding$	 3,0,3,0q�6$   �� 5�   
    � ��
	 �����6'   �� 5�   
    � ��8	   6!   �� 5�   
    � ��$	 90��6"   5�      �� 5�      " ��6%   8   
 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��
	 �����6/   �� 5�       � ��8	  6)   �� 5�       � ��$	 24��6*    5�      �� 5�      .��5�      �� .��5�      W� $ 0:0:0.25D�6.   $ 90X�6B   $ Width�6J   5�      5�       5�      �� 5�      .��5�      �� .��5�      W� $ 0:0:0.25D�6.   $ 24X�6B   $ Width�6J   5�      5�      5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��$	 *��6)   5�      5�      �� 5�      " ��6   
 5�   
   P� 5�       �@J�IsMouseOver . . �5�      ��  � ��8	   6/   5�      P� 5�       �@J�IsMouseOver .  . �5�      ��  � ��8	  6/   5�      5�      �� 5�      " ��6    
 5   
   P� 5      �@J�IsMouseOver . . �5     ��  � ��
	 � ���60   �� 5      � ��$	 2q�64   �� 5      � ��	 �	#3FFFFF006/   5     5     �� 5	     " _�6!   .�5
  
   ��  � ��	 �	#440000006'   �� 5  
    � ��
	 �����6'   �� 5  
    � ��$	 0q�6,   �� 5  
    � ��$	 Segoe Print)�6'   �� 5  
    � ��$	 12(�6%   �� 5  
    � ��$
	 Bold"�6'   5     �� 5     " ��6   .�5  
   ��  � ��	 �	#7F0000006'   
 5  
   P� 5      �@J�IsMouseOver .  5     �� 5     .��5     �� .��5     �� $ 0:0:0.25D�6-   $ 	#E0000000X�6A   $1 +(Border.Background).(SolidColorBrush.Color)�6P   5     5      5     �� 5     .��5      �� .��5!     �� $ 0:0:0.25D�6-   $ 	#7F000000X�6A   $1 +(Border.Background).(SolidColorBrush.Color)�6P   5"     5#     5&     5(     5*     