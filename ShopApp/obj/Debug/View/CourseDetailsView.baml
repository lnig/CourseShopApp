   M S B A M L   `   `   `  ����B  >ShopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ShopApp.ViewShopApp.View  5      5clr-namespace:ShopApp.ViewModelShopApp.ViewModel  5      $    ShopApp.View.CourseDetailsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ShopApp.View     5      C	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     5      .vmclr-namespace:ShopApp.ViewModel     5        � DataContext  5      .   (ShopApp.ViewModel.CourseDetailsViewModel  5   
   .��5      � 
�������.+�5   
   ��  �� Orientation$ Vertical=�6   $��30 32 30 24q�6,   .+�5      �� $
��Left=�6    �� CornerRadius$ 50��60   
������ $��32��6[   $��32��6g   
�������$��1q�6�   ._�5      �� -   5           	navButton#��[  5      $��32��6<   
������ 
������ .��5      �� $&�� /Assets/Icons/Img/arrow_back.png��6   $��18��6F   5      5      �� 5      $y�	Collapsed=�6A   ��6   �� *SelectedCourse.CourseId+6A   �� 5      ���#171A1F$��32(�6S   $
��Bold"�6a   ��6   �� *SelectedCourse.Title+6a   �� 5      ���#171A1F$��16(�6[   $��Medium"�6i   ��6   �� *SelectedCourse.Category.Name+6i   �� 5      $ 
Horizontal=�6   $��0 12 0 0q�62   .+�5      �� $
��Fill=�6   $+��%/Assets/Illustrations/programming.jpg��6'   $	��720��6V   $	��450��6b   �� 5      $ Vertical=�6   $��14 0 0 0q�64   .+�5      �� $
��Fill=�6   $+��%/Assets/Illustrations/programming.jpg��6+   $	��390��6Z   $	��215��6f   $��0 0 0 20q�6s   �� 5       $
��Fill=�6   $+��%/Assets/Illustrations/programming.jpg��6+   $	��390��6Z   $	��215��6f   5!      5"      �� 5$      $ Vertical=�6   $	��150��60   $
��Left=�6<   $��0 32 0 0q�6W   .+�5%      �� $��Description��6   $��14(�6/   $
��Bold"�6=   $��Center=�6O   $��0 0 0 16q�6l   �� 5&      $	��150��6   ���#171A1F$��4��67   $��0 0 0 -2q�6B   5'      �� 5)      $��1��6   ���#EAECF06#   �� 5+      $ 
Horizontal=�6   .+�5,      �� $ Vertical=�6   $	��715��64   $	��210��6@   .+�5-      �� $��Description��6    $��20(�63   $
��Bold"�6A   $��	0 12 0 12q�6S   �� 5.      $��14(�6    ��6.   �� *SelectedCourse.Description+5/      �� 51      $ Vertical=�6   $��20 0 0 0q�64   .+�52      � $	��389��6   $��0 14 0 0q�6'    � ColumnDefinitions 53      �� 54      $��* �6/   �� 55      $
��Auto �6/   .+�58      �� $
��Left=�6%   $��0��6@   .+�59      �� $��Center=�6O   $
��Left=�6j   $��12q�6�   $��14(�6�   ���#171A1F��6(   �� *SelectedCourse.Author+6�   5:      �� 5<      $��Right=�6%   $ 
Horizontal=�6A   $��1��6Z   $
��12 0q�6j   .+�5=      �� $��Center=�6O   $��14(�6j   ���#171A1F��6(   �� *SelectedCourse.Rating+6x   �� 5>      $ ��/Assets/Icons/Img/star.png��6$   $��14��6H   $��Center=�6T   5?      5@      �� 5B      $ Vertical=�6!   $	��137��68   ���#F8F9FA$��0 16 0 0q�6Z   .+�5C      � $��12 12 12 12q�6    5D      �� 5E   "   $��* �63   �� 5F   "   $
��Auto �63   .+�5H      �� $��Price��6(   $
��Left=�65   $��16(�6P   $��SemiBold"�6^   �� 5I      $��1��6)   $ 
Horizontal=�69   $��Right=�6R   .+�5J   "   �� $��$��6,   $��1��65   $��Right=�6E   $��16(�6a   $��SemiBold"�6o   $��0 0 4 0 q�6�   �� 5K   "   $��1��6R   $��Right=�6b   $��16(�6~   $��SemiBold"�6�   ��6,   �� *SelectedCourse.Prize+6�   5L      5N      5O      5P      5Q      5R      5T      5U      