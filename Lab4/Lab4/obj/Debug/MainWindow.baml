   M S B A M L   `   `   `  ����?  ;Lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab4Lab4  5   	       Lab4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab4     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��0,0,2,0q�6   .+�5
   
   �� -   5         ��Name$ add_str��5
      $#��Добавить запись��6"   $
��Left=�6<   $��43��6W   $��	23,10,0,0q�6c   $	��Top=�6v   $	��145��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datag��5      $
��Left=�6"   $	��295��6=   $��	23,78,0,0q�6J   $	��Top=�6]   $	��644��6u      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 uid��6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *uid+   ClipboardContentBinding 6=   Z� 6`     5      $	 FIO��6`    6%   �� *FIO+ 6=   Z� 6`     5      $
 math��6a    6%   �� *math+ 6>   Z� 6a     5      $
 phys��6a    6%   �� *phys+ 6>   Z� 6a   5      �� 5   
   -   5        $
 open��5      $��Загрузить��6   $
��Left=�63   $��43��6N   $��
173,10,0,0q�6Z   $	��Top=�6n   $	��140��6�   6�   �� 5   
   -   5        $	 red��5      $ ��Редактировать��6   $
��Left=�66   $��43��6Q   $��
318,10,0,0q�6]   $	��Top=�6q   $	��141��6�   6�   �� 5   
   -   5        $	 del��5      $��Удалить��6   $
��Left=�60   $��43��6K   $��
464,10,0,0q�6W   $	��Top=�6k   $	��145��6�   6�   5      5      