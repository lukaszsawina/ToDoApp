   M S B A M L   `   `   `  ����B  >ToDoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ToDoApp.ViewsToDoApp.Views  5   	       ToDoApp.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ToDoApp.Views     5   	     � Title$  ToDoApp��5   	   $	��800��6   $	��600��6&    � 
ResizeMode$ NoResize=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��2��6   $��0��5      ���#32213A$��50��5       5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5!      �� -   5         ��Name$ EditBtn��5!      $��0��5#      $��0��5$      $
��Edit��5%         	TopButton#��[  5&      {�5"      �� *EditBtnIsEnable+5&      �� 5(      -   5        $ AddBtn��5(      $��0��5)      $��2��5*      $	��New��5+      #��[  5-      y�5,      �� *AddBtnIsVisible+5-      �� 5.      -   5        $ CloseBtn��5.      $��0��5/      $��2��50      $��Close��51      #��[  53      y�52      �� *CloseBtnIsVisible+53      54      �� 58   
   -   5         ��Name$ 
ActiveItem��5:      $��1��58      $��2��59      5;      5=      5>      