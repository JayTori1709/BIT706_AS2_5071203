   M S B A M L   `   `   `  ����  Assessment2.App-    'Assessment2.App.Views.AddCustomerWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Customer��5   	   $	��400��6   $	��500��6+    � WindowStartupLocation$ CenterScreen=�67   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $	��0,5q�6;   .+�5      �� $��First Name:��6   $	��120��6+   $��16(�67   $��Center=�6E   �� 5      $	��300��61   $��14(�6=   ��6   �� *	FirstName+6=   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5      �� $��Surname:��6   $	��120��6(   $��16(�64   $��Center=�6B   �� 5      $	��300��6/   $��14(�6;   ��6   �� *	Surname+6;   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5      �� $��Phone Number:��6   $	��120��6-   $��16(�69   $��Center=�6G   �� 5      $	��300��63   $��14(�6?   ��6   �� *PhoneNumber+6?   5      �� 5!   
   $��3��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5"      �� $��Address:��6   $	��120��6(   $��16(�64   $	��Top=�6B   �� 5#      $	��300��6/   $��80��6;    �� AcceptsReturn$
 True��6G    �� TextWrapping$
 Wrap=�6\   $��14(�6p   ��6   �� *	Address+6p   5$      �� 5'   
   $��4��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5(      �� $��Cancel��6   $	��100��6H   $
��10,0q�6T   ��6&   �� *CancelCommand+6T   �� 5)      $
��Save��6   $	��100��6D   ��6$   �� *SaveCommand+6D   5*      5+      5,      