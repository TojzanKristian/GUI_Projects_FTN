   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5   	   ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5   	   C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5   	       NetworkService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NetworkService     5   	   4views"clr-namespace:NetworkService.Views     5   	   <	viewModel&clr-namespace:NetworkService.ViewModel     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$  ��5
   	   $	��640��6   $	��400��6    � DataContext 5   
   (   "NetworkService.MainWindowViewModel  5   
    � 	Resources 5       �� DataType1  +NetworkService.ViewModel.PotrosnjaViewModel(   "NetworkService.Views.PotrosnjaView3   -NetworkService.ViewModel.DragandDropViewModel*   $NetworkService.Views.DragAndDropView-   'NetworkService.ViewModel.GraphViewModel$   NetworkService.Views.GraphView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5"   
   �� $��0��6   
�������$	��400��67   $��NetworkService��6C   $��Center=�6\   $��Center=�6~   $��Center=�6�   $��Center=�6�   $
��Bold"�6�   $��25(�6�   $��	10,5,10,5q�6�   ]� 5#   
   $��1��6   $��10q�6!   .+�5%      o� 
��� ��$	��Top=�6+   .@�5&      m� $��Network Data��6   $��20,8,5,5q�61   $��Center=�6C   $
��Left=�6^    m� CommandParameter$ Network Data��5'       m� Command 5&   y   �� *
NavCommand+5'      m� 5(      $��Network View��6   $��40,8,5,5q�61   $��Center=�6C   $��Center=�6^   $ Network View��5)       5(   {   �� *
NavCommand+5)      m� 5*      $��
Data Chart��6   $��30,8,5,5q�6/   $��Center=�6A   $��Right=�6\   $ 
Data Chart��5+       5*   x   �� *
NavCommand+5+      5,      5-      � 5.   
   $��2��6    5/      �� 50      $	��450 �6    �� 51      $��50 �6    .+�54      �� $��0��6   ��6*   �� *CurrentViewModel+�� 56       �� Orientation$ 
Horizontal=�6   $��1��62   .+�57      �� -   5        	 ��Name$	 btnHome��57      $��Network Data��6I   $
��Home��6i   $��18(�6x   $��Center=�6�   $��Center=�6�   $��30��6�   $	��100��6�   $��80,5,5,5q�6�   ��6*   �� *
NavCommand+6�   �� 58      -   5        $	 btnUndo��58      $
��Undo��6J   $��18(�6Y   $��Center=�6g   $��Center=�6�   $��30��6�   $	��100��6�   $��30,5,5,5q�6�   ��6*   �� *UndoCommand+6�   59      5:      5;      5<      