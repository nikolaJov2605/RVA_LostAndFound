   M S B A M L   `   `   `  ����@  <Front, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Front.ViewsFront.Views  5   	       Front.Views.AddItem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Front.Views     5   	   -   5          � Title$  AddItem��5   	   $	��400��6   $	��488��6&   .��5	      � $��1,2,-6.4,-1.8q�6   .+�5
   
   �� -   5         ��Name$ 
lblCaption��5
      $��Dodaj predmet��6$   $��Center=�6<   $��25,10,24.2,0q�6Y   $	��Top=�6o   $��69��6�   $	��394��6�   $��40(�6�   $��Center=�6�   �� 5   
   -   5        $ lblDatum��5      $��Datum:��6"   $
��Left=�63   $��	10,93,0,0q�6N   $	��Top=�6a   $��85��6y   $��20(�6�   �� 5   
   -   5        $ lblNaziv��5      $��Naziv predmeta:��6"   $
��Left=�6<   $��
10,130,0,0q�6W   $	��Top=�6k   $	��158��6�   $��20(�6�   �� 5   
   -   5        $ lblLokacija��5      $��	Lokacija:��6%   $
��Left=�69   $��
10,172,0,0q�6T   $	��Top=�6h   $��85��6�   $��20(�6�   $��2��6�   �� 5   
   -   5        $ lblOpis��5      $��Opis:��6!   $
��Left=�61   $��
10,209,0,0q�6L   $	��Top=�6`   $��85��6x   $��20(�6�   �� 5   
   -   5        $ 
lblVlasnik��5      $��Korisničko ime vlasnika:��6$   $
��Left=�6G   $��
10,249,0,0q�6b   $	��Top=�6v   $	��221��6�   $��20(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDate��5      $
��Left=�6%   $��236,102,0,0q�6@   $	��Top=�6U   $	��142��6m    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name �� Path	 �� RelativeSource
 �� AncestorType �� StringFormat��%�   '        �� 5      "  6   .�5      ��  � �� 5      �� 5      .R�5   "   �� $ PART_TextBox��6*   ��5   %   �� $ SelectedDate�	 �� "
  $ {0:dd/MM/yyyy}��5      5      5      5      5      �� 5   
   -	   5        $ tbNaziv��5      $
��Left=�6#   $��23��6>   $��236,139,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��241��6�   6�   �� 5   
   -
   5        $ 
tbLokacija��5      $
��Left=�6&   $��23��6A   $��236,181,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��241��6�   6�   �� 5    
   -   5        $ tbOpis��5       $
��Left=�6"   $��23��6=   $��236,218,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��241��6�   6�   �� 5!   
   -   5        $ 	tbVlasnik��5!       �� 
IsReadOnly . $
��Left=�6X   $��23��6s   $��236,258,0,0q�6   $
 Wrap=�6�   $	��Top=�6�   $	��241��6�   ��67   �� *Person.Username+6�   �� 5"   
   -   5         ��Name$ btnRegisterAdd��5"      $��Dodaj��6)   $
��Left=�69   $��
10,309,0,0q�6T   $	��Top=�6h   $	��458��6�   $��33��6�   $��20(�6�   $��Center=�6�   $��Center=�6�   6�   �� 5#   
   -   5        $ 
lblDateErr��5#      $�� ��6$   $
��Left=�6/   $��383,102,0,0q�6J   $	��Top=�6_   $��94��6w   5%      5&      