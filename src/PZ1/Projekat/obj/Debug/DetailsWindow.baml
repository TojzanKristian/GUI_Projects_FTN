   M S B A M L   `   `   `  ����C  ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProjekatProjekat  5   	       Projekat.DetailsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekat     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ DetailsWindow��5	   	   $	��350��6   $	��510��6,   
������� � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 �� Triggers
 P� Property P� Value �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth   
BlurRadius��%"  '��       �� 5   
   " ��6   .�5      ��  � �� �#4B00826+   �� 5       � ��
 �����6+   �� 5       � ��$ 10q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ border��6%   #��z��65   $ 10��6_   �� 5      $��2q�6%   ���#9400D3$ 10��6E   �� 5      $��4q�6%   ���#9932CC$ 10��6E   �� 5      $��6q�6%   ���#BA55D3$ 10��6E   �� 5      $��8q�6%   ���#DA70D6$ 10��6E   �� 5      $��10q�6%   ���#EE82EE$ 10��6F   �� 5      $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 � �� . . �5   "   �� $ border��6)    � �� �#9932CC6S   5       P� 5!      
 � {� .  . �5"   "   �� $ border��6)    � �� �#C0C0C06S   �� 5#   "    � �� �#8080806?   �� 5$   "   $ border��6)    �@J�Effect 5%   &     5&   *   $ #BA55D3��6;   $	 270Q�6K   $ 5Q�6[   $ 10Q�6k   5(   #   5)      5+      5-      5.      5/      .��51      � 
�������.+�52   
   �� 
���   �$
��Left=�6!   $��8��6<   $��
10,225,0,0q�6G   $	��Top=�6[   $	��480��6s   �� 55   
   -   5         ��Name$ labelNaslov��55      $��Denver Nuggets��6%   
���2͚�$
��Bold"�6W   $
��Left=�6i   $��10,4,0,0q�6�   $	��Top=�6�   $	��480��6�   $��Center=�6�   $��Center=�6�   $��	Agency FB)�6   $��24(�6  &   System.Windows.Controls.DataGrid  58   
   -   5          Name$ dataGridIgraci��58      
����� �   CanUserSortColumns .     
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  $��Center=�6  $	��158��60  $��5,53,0,0q�6=  $	��Top=�6O  $	��450��6g  ��6+   �� *
DNIgraci+   Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Ime+6J     5=      $ Prezime��6%   $ 60 6R    66   �� *	Prezime+6R     5?      $ Visina��6%   $ 50 6P    65   �� *Visina+6P     5A      $ Datum dodavanja��6%   $	 140 6X    6>   �� *Datum+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5C      $ Slika��6)   $ * 68      CellTemplate 5D      �� 5E      .R�5F      ��  ��Name$	 img��6$   $��40��6J   ��61   �� *Slika+6J   5G      5I      5K      �� 5N   
   -   5          ��Name$  buttonIzlaz��5N      $
��Exit��6&   $��15(�65   $
��Bold"�6C   $
��Left=�6U   $��45��6p   $��175,250,0,0q�6|   $	��Top=�6�   $	��150��6�   
�������
��� ���6�   5O      5P      