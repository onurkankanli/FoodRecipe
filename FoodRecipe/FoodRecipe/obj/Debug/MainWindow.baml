   M S B A M L   `   `   `  ����E  AFoodRecipe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FoodRecipe
FoodRecipe  5   	       FoodRecipe.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:FoodRecipe     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  
MainWindow��5	   	   $	��500��6   $	��850��6)   $	��500��65   $	��850��6E    � 
ResizeMode$ CanResizeWithGrip=�6T   .��5      ��  �� Orientation$ Vertical=�6   ��5   
   �� 5       �� ImageSource$ /Images/MainWindow.jpg��6   6@   .+�5   
   �  � RowDefinitions 5   
   �� 5      $��20��6    $	��20* �6/    � ColumnDefinitions 5   
   �� 5      $	��100��6   $
��100* �6.   �� 5      $	��160��6   $
��160* �6.   �� 5      $	��100��6   $
��100* �6.   .+�5   
   �� $��0��6   $��1��6!   $��15(�61   $��Center=�6?   $2��,You can select your meal from the search bar��6\   $��
ExtraBlack"�6�   6�   �� 5   
   -   5         ��Name$ btnBack��5   ?   $��0��6   $��0��6    �� 	IsDefault . +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $��45��6J   $	��120��6V   +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 10��5      $��15(�6G   $
��Back��6U   6d   �� 5!   
   -   5        $ btnQuit��5!   ?   $��3��6   $��0��6!    . $ Depth0=�5"      $��45��6J   $	��120��6V   
���   �$	 10��5#      $��15(�6G   $
��Quit��6U   6d   5$      �� 5&   
   $ Vertical=�6   $	��400��6,   $	��400��69   .+�5'      �� -   5        
 ��Name$
 comboBox��5'      $��Center=�6*   $��	0 15 0 75q�6G   $	��Top=�6Z   $	��250��6r    �� SelectedValuePath$ Content��5(       �� 
IsEditable .   �� IsTextSearchCaseSensitive .   �� IsTextSearchEnabled .   �� SelectedValue 64   ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$
 Text�5*      �� 5,   
   -   5         ��Name$ FoodList��5,   8   $��10q�6   $	��270��6   $	��350��6,    �� View 5-      �� 5.      .P�5/      �� $��Image��6%    �� Width$	 120��64    �� CellTemplate 50      �� 51      .R�52   "   �� ��6(   �� *ImgSrc+53      55      �� 56      $��ID��6%   $ 50��61    �� DisplayMemberBinding 6<   �� *MealId+�� 57      $
��Name��6)   $	 150��67    6C   �� *
MealName+58      5:      5;      5<      5>      