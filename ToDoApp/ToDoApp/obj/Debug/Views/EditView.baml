   M S B A M L   `   `   `  ����B  >ToDoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ToDoApp.ViewsToDoApp.Views  5          ToDoApp.Views.EditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ToDoApp.Views     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5
      �� .+�5   
   �� $��	Edit Task��6   $��28(�5      ���#fff  �� TextAlignment$
  left=�5      $
��Bold"�5       �� Padding$ 6q�5      ���#66717E5      �� 5   
   $
��Name��6      LabelTextTheme#��[  6    �� 5   
   -   5         ��Name$ EditTaskName��5        TextBoxTheme#��[ 6(   �� 5   
   $��Expiration date��6   #��[  6+   &   System.Windows.Controls.Calendar  5   
   -   5          Name$ ExpirationDate��5      $
��16 0q�5        resizedCalendarItem#��[ 5         SelectedDate 5      �� *ExpirationDate+5      �� 5   
   -   5         ��Name$ Result_info��5   1   $��Center=�6F   ���#f00$��16(�6u   $
��Bold"�6�   $��0 90 0 0q�5   ;   ��5      �� *Result_info+y�5      �� *ResultIsVisible+6;   �� 5   
     	AddButton#��[ 6     Caliburn.Micro.Message   Attach$: 4[Event Click]=[Action ChangeTaskAsync($dataContext)]��6Z   $
��Save��6�   {�64   �� *EditBtnIsEnable+6�   5!      5"      