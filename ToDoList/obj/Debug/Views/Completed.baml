   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ToDoList.ViewsToDoList.Views  5          ToDoList.Views.Completed   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ToDoList.Views     5      -   5        .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  CompletedTasks��5   �   
������    
IsReadOnly .    HorizontalGridLinesBrush
 ����    SelectionMode$ Single=�6e      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6b   	   MaxWidth$		 120Q�6n   
   Header$
 
Ukonczono?��6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *Id+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   5      5        5       . $	 265 6P   $		 265Q�6\   $
 Nazwa zadania��6k    67   �� *text+ 5      �� 5      .�5      ��  � ��$
 Wrap=�6G   5      5        5       . $	 422 6P   $		 422Q�6\   $
 Data i godzina��6k    67   �� *data+ 5      �� 5      .�5      ��  � ��$
 Wrap=�6G   5       5"       � ContextMenu 5%      �� 5&      .@�5'      m� -   5        $��	Ukonczono��5'      62   m� 5(      -   5        $��Nieudane��5(      61   5)      5+      5,      5-      