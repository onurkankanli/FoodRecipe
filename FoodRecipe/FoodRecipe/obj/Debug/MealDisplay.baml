   M S B A M L   `   `   `  ����E  AFoodRecipe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FoodRecipe
FoodRecipe  5   	       FoodRecipe.MealDisplay   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:FoodRecipe     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
�������  � Title$  MealDisplay��5	   	   $	��750��6   $	��900��6*   $	��750��66   $	��900��6F    � 
ResizeMode$ CanResizeWithGrip=�6U   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   � $��0 0 0 30q�6    � RowDefinitions 5      �� 5      $��20��6    $	��20* �6/    � ColumnDefinitions 5      �� 5      $	��100��6#   $
��100* �62   �� 5      $	��100��6#   $
��100* �62   �� 5      $	��100��6#   $
��100* �62   .+�5      �� -   5         ��Name$ btnBack��5   C   $��0��6   $��0��6%    �� 	IsDefault . +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5      $��45��6J   $	��120��6V   
���   �+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5      $��15(�6G   $
��Back��6U   6d   �� 5      -   5        $ btnQuit��5   C   $��3��6   $��0��6%    . $ Depth0=�5      $��45��6J   $	��120��6V   
���   �$ 10��5      $��15(�6G   $
��Quit��6U   6d   �� 5       $��1��6   $��0��6)   .+�5!      �� -   5        	 ��Name$	 	mealTitle��5!      $
��Wrap=�6/   
 �� TextAlignment$
 Center=�6C   $
��Bold"�6Z   $��24(�6l   6|   �� 5"      -   5        $	 mealID��5"      $
 Center=�6-   $
��Bold"�6D   $��18(�6V   6f   5#      5$      � 5&   
    5(      �� 5)      $��20��6    $	��20* �6/    5,      �� 5-      $	��100��6#   $
��100* �62   �� 5.      $	��100��6#   $
��100* �62   �� 5/      $	��100��6#   $
��100* �62   .+�52      �� -   5         ��Name$ foodIMG��52   J   $��2��6   $��0��6$   $	��200��61   $	��200��6=   6]   �� 54      -   5         ��Name$ myStack��54   K   $��10 10 10 10q�6   $��0��6.   $��0��6>   
�������.+�55      �� $��10 10 10 10q�6   $��25(�61   
�������$��
ExtraBlack"�6[   $��General info��6s   6�   56      &   System.Windows.Controls.DataGrid  58      -   5        $��	InstrGrid��59      $��0��58      $��1��6$   $   HorizontalScrollBarVisibility$ Hidden=�64   "   VerticalScrollBarVisibility$ Hidden=�6[   $	��200��6�   $	��200��6�   $��Center=�6�   $	��Top=�59   "      	RowHeight$ 30Q�6:      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6I   
�������   GridLinesVisibility$
 None=�6x   5:      5;      �� 5=   
   $��10 10 10 10q�6   .+�5>      �� $��10 10 10 10q�6   
�������$��
ExtraBlack"�6I   $��Recipe: ��6a   $��25(�6q   6�   �� 5?      -   5        $	 Recipe_Instructions��5?   S   $��Center=�6   
�������6r   5@      5B      5C      