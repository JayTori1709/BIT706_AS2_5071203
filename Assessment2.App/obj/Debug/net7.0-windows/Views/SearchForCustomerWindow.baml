   M S B A M L   `   `   `  ����  Assessment2.App3    -Assessment2.App.Views.SearchForCustomerWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Search for Customer��5   	   $	��500��6%   $	��600��62    � WindowStartupLocation$ CenterScreen=�6>   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��0��6   $	��400��6   $��0,0,0,10q�6+   $��14(�5      ��5      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6    �� DisplayMemberPath$ FullName��5      $��16(�5      $��0,0,0,10q�5      ��5      �� *	Customers+ �� SelectedItem 5      �� *SelectedCustomer+5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��Cancel��6   $	��100��6H   $
��10,0q�6T   ��6&   �� *CancelCommand+6T   �� 5      $��Select��6   $	��100��6o   ��6&   �� *SelectCommand+{�6H   �� *SelectedCustomer+6o   5      5      5      