   M S B A M L   `   `   `  ����  Assessment2.App+    %Assessment2.App.Views.AddAnimalWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Add Animal��5   	   $	��450��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�65   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $	��0,5q�6;   .+�5      �� $��Name:��6   $	��120��6%   $��16(�61   $��Center=�6?   �� 5      $	��300��6,   $��14(�68   ��6   �� *Name+68   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5      �� $��Type:��6   $	��120��6%   $��16(�61   $��Center=�6?   �� 5      $	��300��6Z   $��14(�6f   ��6   �� *AnimalTypes+ �� SelectedValue 6;   �� *Type+6f   5      �� 5   
   $��2��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5      �� $��Breed:��6   $	��120��6&   $��16(�62   $��Center=�6@   �� 5      $	��300��6-   $��14(�69   ��6   �� *Breed+69   5      �� 5   
   $��3��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5       �� $
��Sex:��6   $	��120��6$   $��16(�60   $��Center=�6>   �� 5!      $	��300��6Y   $��14(�6e   ��6   �� *AnimalSexes+ 6;   �� *Sex+6e   5"      �� 5$   
   $��4��6   $ 
Horizontal=�6"   $	��0,5q�6;   .+�5%      �� $��Owner:��6   $	��120��6&   $��16(�62   $��Center=�6@   �� 5&       �� DisplayMemberPath$ FullName��69    �� SelectedValuePath$ Id��5'      $	��300��6P   $��14(�6\   ��5&      �� *	Customers+ 5'   .   �� *	OwnerId+6\   5(      �� 5*   
   $��6��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5+      �� $��Cancel��6   $	��100��6H   $
��10,0q�6T   ��6&   �� *CancelCommand+6T   �� 5,      $
��Save��6   $	��100��6D   ��6$   �� *SaveCommand+6D   5-      5.      5/      