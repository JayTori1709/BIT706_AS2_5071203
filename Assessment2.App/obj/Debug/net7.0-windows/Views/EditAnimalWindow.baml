   M S B A M L   `   `   `  ����  Assessment2.App,    &Assessment2.App.Views.EditAnimalWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Edit Animal��5   	   $	��400��6   $	��450��6*   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Name:��6   $��0��6!   $��Center=�6.   �� 5   
   $��0��5      $��	120,5,0,0q�6   $	��250��62   ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5   2   �� 5   
   $��Type:��6   $��1��6!   $��Center=�6.   �� 5   
   $��1��5      $��	120,5,0,0q�6    $	��250��63   ��5      �� *AnimalTypes+ �� SelectedValue 5      �� *Type+5   3   �� 5   
   $��Breed:��6   $��2��6"   $��Center=�6/   �� 5   
   $��2��5      $��	120,5,0,0q�6   $	��250��62   ��5      �� *Breed+$ PropertyChanged=�5   2   �� 5!   
   $
��Sex:��6   $��3��6    $��Center=�6-   �� 5"   
   $��3��5$      $��	120,5,0,0q�6    $	��250��63   ��5"      �� *AnimalSexes+ 5#      �� *Sex+5$   3   �� 5'   
   $��Owner:��6   $��4��6"   $��Center=�6/   �� 5(   
    �� DisplayMemberPath$ FullName��5)       �� SelectedValuePath$ Id��5*      $��4��5,      $��	120,5,0,0q�6    $	��250��63   ��5(      �� *	Customers+ 5+      �� *	OwnerId+5,   3   �� 5/   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�50      �� $��Cancel��6   $��10,0,5,0q�6H   $��80��6Z   ��6&   �� *CancelCommand+6Z   �� 51      $��Delete��6   $	��100��6H   $
��10,0q�6T   ��6&   �� *DeleteCommand+6T   �� 52      $
��Save��6   $��80��6D   ��6$   �� *SaveCommand+6D   53      54      55      