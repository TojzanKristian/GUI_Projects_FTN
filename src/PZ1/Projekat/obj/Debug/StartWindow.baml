   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5   	       Projekat.StartWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekat     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ 
Start Page��5	   	   $	��350��6   $	��515��6)   
������� � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� RadiusX	 �� RadiusY
 � 	Resources3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   Color �� Triggers P� Property P� Value �� 
TargetName��%c  '��       �� 5   
   " ��6   .�5      ��  � �� �	#FFFFFF006+   �� 5       � ��
 �����6+   �� 5       � ��$ 10q�6(   �� 5       � ��$ 0q�60   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ BackgroundRectangle��6(   $ 10��6E   $	 10��6R   #��z��6_   #��z��6�   #��z��6�   �� 5      $��Center=�6/   $��Center=�6L   5      
 5      ���� 5      '��       " ��6$   .�5   "   ��  �@��CornerRadius$ 10��6A   5      �� 5      '�       " �6$   .�5    "   ��  � ��$ -5q�6;   �� 5!   "    �@J�Effect 5"   &     5#   *   $ 15Q�6;   $ 0Q�6K   $	 0.7Q�6[   $ Black��6i   5%   #   5&      5'       5(      P� 5)       �@J�IsMouseOver . . �5*   "   �� $ BackgroundRectangle��6)    � �� �	#FFFFFF006n   5+      P� 5,       � �� . . �5-   "   �� $ BackgroundRectangle��6)    � �� �	#FF9ACD326Z   5.      50      52      53      54      .��56      � .+�57   
   �� 
���   �$
��Left=�6!   $��8��6<   $��
10,225,0,0q�6G   $	��Top=�6[   $	��460��6s   �� 5:   
   -   5         ��Name$ labelNaslov��5:      $��Denver Nuggets��6%   
���2͚�$
��Bold"�6W   $
��Left=�6i   $��	10,4,0,10q�6�   $	��Top=�6�   $	��460��6�   $��Center=�6�   $��Center=�6�   $��	Agency FB)�6  $��24(�6  &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ dataGridIgraci��5=      
����� �   CanUserSortColumns .     
IsReadOnly .    AutoGenerateColumns .     SelectionMode$ Extended=�6�   
���   �   CanUserResizeRows .     CanUserAddRows .     CanUserDeleteRows .  $��2q�6     ColumnHeaderHeight$ 25Q�61  $	��460��6I     CanUserResizeColumns .     CanUserReorderColumns .  $��10,50,10,120q�6�  ��6=   �� *Igraci+   Columns 5>      4  .System.Windows.Controls.DataGridTemplateColumn  5@      ,  &System.Windows.Controls.DataGridColumn    Header$  CheckBox��6)   !   Width5  /System.Windows.Controls.DataGridLengthConverter$! 80 6;   "   CellTemplate" 5A      �� 5B      .R�5C      �� # �� Orientation$# Vertical=�6)   $��Center=�6@   $��Center=�6]   .+�5D   "   �� $ ��Name$$ 
cbBrisanje��6+   -   5        % d� 	IsChecked$% FalseY�5D   ?   $��Center=�6Q   $��Center=�6l   6�   5E      5F      5H        5K      $  	HyperLink��6)   $! 80 6<   " 5L      �� 5M      .R�5N      �� $��Center=�6(   $��Center=�6C   �� 5O   "   -   5        ��5O   ,   �� *Url+.�6`   .�5P   &   �� $
��Link��60   $��Center=�6<   $��Center=�6W   5Q   #   5R      5S      5U        5X      $  Slika��6)   $! * 68   " 5Y      �� 5Z      .R�5[      �� & ��Name$	& img��6$   $��50��6J   ��61   �� *Slika+6J   5\      5^      0  *System.Windows.Controls.DataGridTextColumn  5a      $  Datum dodavanja��6%   $! * 6>   '   CanUserResize' .  (   FontSize$( 10Q�6^   1  +System.Windows.Controls.DataGridBoundColumn)   Binding) 6l   �� *Datum+5c      �� 5f   
   -   5        * ��Name$* buttonDodavanje��5f      $	��Add��6*   $
��Left=�68   $��50,260,0,15q�6S   $	��Top=�6h   $��98��6�   $��28��6�   
�������
���   �6�   �� 5h   
   -   5        $* buttonObrisi��5h      $
��Left=�6'   $��200,260,0,15q�6B   $	��Top=�6X   $	��110��6p   $��28��6|   $��Delete��6�   
�������
���   �6�   �� 5j   
   -   5        $* buttonIzlaz��5j      $
��Exit��6&   $
��Left=�65   $��28��6P   $��360,260,0,15q�6\   $	��Top=�6r   $��94��6�   
�������
���   �6�   5k      5l      