   M S B A M L   `   `   `  ����@  <Front, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Front.ViewsFront.Views  5   	       Front.Views.Registracija   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Front.Views     5   	   -   5          � Title$  Registracija��5   	   $	��450��6   $	��420��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ 
lblCaption��5
      $��Registracija��6$   $��Center=�6;   $��0,10,-0.4,0q�6X   $	��Top=�6m   $��69��6�   $	��414��6�   $��40(�6�   $��Center=�6�   �� 5   
   -   5        $ lblIme��5      $
��Ime:��6    $
��Left=�6/   $��	30,94,0,0q�6J   $	��Top=�6]   $��85��6u   $��20(�6�   �� 5   
   -   5        $ 
lblPrezime��5      $��Prezime:��6$   $
��Left=�67   $��
30,136,0,0q�6R   $	��Top=�6f   $��85��6~   $��20(�6�    J� RenderTransformOrigin$ 0.48,-0.163&�6�   �� 5   
   -   5        $ lblDatum��5      $��Datum rođenja:��6"   $
��Left=�6;   $��
30,178,0,0q�6V   $	��Top=�6j   $	��150��6�   $��20(�6�   �� 5   
   -   5        $ lblUsername��5      $��Korisničko ime:��6%   $
��Left=�6?   $��
30,220,0,0q�6Z   $	��Top=�6n   $	��150��6�   $��20(�6�   �� 5   
   -   5        $ 	lblPasswd��5      $��Lozinka:��6#   $
��Left=�66   $��
30,262,0,0q�6Q   $	��Top=�6e   $	��150��6}   $��20(�6�   �� 5   
   -   5        $ label��5      $��Uloga:��6   $
��Left=�60   $��
30,304,0,0q�6K   $	��Top=�6_   $	��150��6w   $��20(�6�   �� 5   
   -	   5         ��Name$ tbIme��5      $
��Left=�6!   $��23��6<   $��185,104,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��190��6�   6�   �� 5   
   -
   5        $ 	tbPrezime��5      $
��Left=�6%   $��23��6@   $��185,146,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��190��6�   6�   �� 5   
   -   5        $ 
tbUsername��5      $
��Left=�6&   $��23��6A   $��185,230,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��190��6�   6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��23��6G   $��185,272,0,0q�6S   $	��Top=�6h   $	��190��6�   �� 5   
   -   5         ��Name$ btnRegister��5      $��Registracija��6&   $
��Left=�6=   $��
10,375,0,0q�6X   $	��Top=�6l   $	��394��6�   $��33��6�   $��20(�6�   $��Center=�6�   $��Center=�6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDate��5      $
��Left=�6%   $��185,187,0,0q�6@   $	��Top=�6U   $	��105��6m      SelectedDateFormat$ Short=�6y   	 � 	Resources	 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox
 �� 
TargetType �� Property �� Value �� Path �� RelativeSource �� AncestorType �� StringFormat��%�   '        �� 5      "
  6   .�5      ��  � �� 5      �� 5      .R�5   "   �� $ PART_TextBox��6*   ��5   %   �� $ SelectedDate� �� "  $ {0:dd/MM/yyyy}��5       5"      5#      5$      5%      �� 5&   
   -   5        $ 
lblDateErr��5&      $�� ��6$   $
��Left=�6/   $��295,185,0,0q�6J   $	��Top=�6_   $��94��6w   �� 5'   
   -   5         ��Name$ cbRole��5'       �� SelectedIndex$ 0��6#   $
��Left=�65   $��185,313,0,0q�6P   $	��Top=�6e   $	��120��6}   $��23��6�   .@�5(      �� .��5)      �� $��Izaberite ulogu��6   5*      �� 5+      .��5,      �� $��Administrator��6   5-      �� 5.      .��5/      �� $��Korisnik��6   50      51      52      53      