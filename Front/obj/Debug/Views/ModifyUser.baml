   M S B A M L   `   `   `  ����@  <Front, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Front.ViewsFront.Views  5   	       Front.Views.ModifyUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Front.Views     5   	   -   5          � Title$  
ModifyUser��5   	   $��353.133��6   $	��420��6-   .��5	      � $��0,0,-0.4,-7.8q�6    � ColumnDefinitions 5
   
   �� 5      $	��41* �6   �� 5      $	��97* �6   .+�5   
   �� -   5         ��Name$ 
lblCaption��5      $��Izmena korisnika��6$   $��Center=�6?   $��-180,10,-190,0q�6\   $	��Top=�6t   $��69��6�   $	��784��6�   $��40(�6�   $��Center=�6�   $��2��6�   �� 5   
   -   5        $ lblIme��5      $
��Ime:��6    $
��Left=�6/   $��	30,94,0,0q�6J   $	��Top=�6]   $��85��6u   $��20(�6�   �� 5   
   -   5        $ 
lblPrezime��5      $��Prezime:��6$   $
��Left=�67   $��
30,136,0,0q�6R   $	��Top=�6f   $��85��6~   $��20(�6�    J� RenderTransformOrigin$ 0.48,-0.163&�6�   �� 5   
   -   5        $ lblDatum��5      $��Datum rođenja:��6"   $
��Left=�6;   $��
30,178,0,0q�6V   $	��Top=�6j   $	��150��6�   $��20(�6�   $��2��6�   �� 5   
   -   5        $ lblUsername��5      $��Korisničko ime:��6%   $
��Left=�6?   $��
30,220,0,0q�6Z   $	��Top=�6n   $	��150��6�   $��20(�6�   $��2��6�   �� 5   
   -   5         ��Name$ tbIme��5      $
��Left=�6!   $��23��6Y   $��61.6,104,0,0q�6e    �� TextWrapping$
 Wrap=�6{   $	��Top=�6�   $	��190��6�   $��1��6�   ��6<   �� *Person.Name+6�   �� 5   
   -   5        $ 	tbPrezime��5      $
��Left=�6%   $��23��6a   $��61.6,146,0,0q�6m   $
 Wrap=�6�   $	��Top=�6�   $	��190��6�   $��1��6�   ��6@   �� *Person.LastName+6�   �� 5   
   -	   5        $ lblBirthdate��5      $
��Left=�6&   $��23��6f   $��61.6,185,0,0q�6r   $	��Top=�6�   $	��190��6�   $��1��6�   ��6A   �� *Person.Birthdate+6�   �� 5   
   -
   5        $ 
lbUsername��5      $
��Left=�6$   $��23��6c   $��61.6,227,0,0q�6o   $	��Top=�6�   $	��190��6�   $��1��6�   ��6?   �� *Person.Username+6�   �� 5   
   -   5         ��Name$ 	btnModify��5      $��Izmeni��6$   $
��Left=�65   $��
10,272,0,0q�6P   $	��Top=�6d   $	��394��6|   $��32��6�   $��20(�6�   $��Center=�6�   $��Center=�6�   $��2��6   5      5      