   M S B A M L   `   `   `  ����  Assessment2.App.    (Assessment2.App.Views.EditCustomerWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Edit Customer��5   	   $	��300��6   $	��400��6,   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��First Name:��6   $��0��6'   $��Center=�64   �� 5   
   $��0��5      $��	100,0,0,0q�6   ��5      �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��Surname:��6   $��1��6$   $��Center=�61   �� 5   
   $��1��5      $��	100,0,0,0q�6   ��5      �� *	Surname+$ PropertyChanged=�5      �� 5   
   $��Phone Number:��6   $��2��6)   $��Center=�66   �� 5   
   $��2��5      $��	100,0,0,0q�6   ��5      �� *PhoneNumber+5      �� 5   
   $��Address:��6   $��3��6$   $	��Top=�61   �� 5   
   $��3��5       $��	100,0,0,0q�6   $��60��5!      " �� VerticalScrollBarVisibility$
 Auto=�6    �� AcceptsReturn$
 True��5"       �� TextWrapping$
 Wrap=�6'   ��5      �� *	Address+5"   '   �� 5%   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5&      �� $��Cancel��6   $	��100��6@   $
��10,0q�6L   ��6   �� *CancelCommand+6L   �� 5'      $��Delete��6   $	��100��6@   $
��10,0q�6L   ��6   �� *DeleteCommand+6L   �� 5(      $
��Save��6   $	��100��6<   ��6   �� *SaveCommand+6<   5)      5*      5+      