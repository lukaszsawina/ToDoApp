   M S B A M L   `   `   `  ����B  >ToDoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ToDoApp.ViewsToDoApp.Views  5      "    ToDoApp.Views.MainWindowView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ToDoApp.Views     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5
      � ���#66717E  � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��	Task List��6   $��28(�5      ���#fff �� TextAlignment$
 left=�5      $
��Bold"�5      $��6q�5      �� 5   
   -   5         ��Name$ TaskList��5   �   $��Stretch=�6     Caliburn.Micro.Message   Attach$@ :[Event SelectionChanged]=[Action ChangeSelect($eventArgs)]��6P   $��1��6�   ��62   �� *Tasks+��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      P� 5        P� Property �@��
IsSelected P� Value . . �5!      ��  �� Property � ��	 �� Value	 �#68777D6;   5"      .�5$      ��  � ��	 �#9CAFB763   �� 5'       � ��	 5(      �� 5)      
 �� 
TargetType"
 ��6.   .R�5*   "   �� #��z��6)   $��50��5+       �� CornerRadius$ 5��5,      $	��2 4q�5-      ._�5.   &   �  � ColumnDefinitions 5/   *   �� 50   .   $
��auto �6?   �� 51   .   $��* �6?   �� 52   .   $
��auto �6?   .+�54   *   �� $��0��63      
DoneButton#��[  6C   $��Center=�6g   $��Center=�6�   $3 -[Event Click]=[Action DoneTask($dataContext)]��55   3    � LayoutTransform 56   .   �� 57   2    �� ScaleX$ 2Q�6A    �� ScaleY$ 2Q�6L   59   +   �� 5:   *   $��1��5;   4   $
��Left=�5<   4   $��Center=�5=   4   $��22(�5>   4   $��Light"�5?   4   ��5:   4   �� *
TaskName+5?   4   �� 5@   *   $��2��6N   $��Center=�6^   $��Center=�6{    �� Padding$
 10 0q�6�   ��64   �� *
FullDate+6�   5C   '   5D   #   5F      5H      5I      5L      5P      5Q      