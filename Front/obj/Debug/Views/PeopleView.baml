   M S B A M L   `   `   `  ����@  <Front, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Front.ViewsFront.Views  5   	       Front.Views.PeopleView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Front.Views     5   	   -   5          � Title$  
PeopleView��5   	   $	��400��6   $	��600��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridPeople��5
         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    SelectionMode$ Single=�6�   $
��Left=�6�   $	��320��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��574��6�   ��6+   �� *People+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Ime��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 62   �� 
 �� Path$

 Name�   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5      ��  �� Property � �� �� Value$ Center=�6K   �� 5       � ��$ 15(�6C   5      5        5      $ Prezime��6%   $ * 6X   	 66   �� $
 LastName� 5      �� 5      "  6    .�5      ��  � ��$ Center=�6K   �� 5       � ��$ 15(�6C   5      5        5      $ Korisničko ime��6%   $ * 6_   	 6=   �� $
 Username� 5      �� 5      "  6    .�5      ��  � ��$ Center=�6K   �� 5        � ��$ 15(�6C   5!      5#        5$      $ Datum rođenja��6%   $ * 6   	 6<   �� $
 	Birthdate� �� StringFormat$ {0:dd/MM/yyyy }�� 5%      �� 5&      "  6    .�5'      ��  � ��$ Center=�6K   �� 5(       � ��$ 15(�6C   5)      5+        5,      $ Uloga��6%   $ * 6R   	 64   �� $

 Role� 5-      �� 5.      "  6    .�5/      ��  � ��$ Center=�6K   �� 50       � ��$ 15(�6C   51      53      55      �� 56   
   -   5         ��Name$ btnAdd��56      $��Dodaj��6!   $
��Left=�61   $��262,335,0,0q�6L   $	��Top=�6a   $	��104��6y   $��25��6�   6�   �� 57   
   -   5        $ 	btnModify��57      $��Izmeni��6$    J� IsHitTestVisible .  
�������$
��Left=�6`   $��371,335,0,0q�6{   $	��Top=�6�   $	��104��6�   $��25��6�   6�   �� 58   
   -   5        $ 	btnDelete��58      $��Obriši��6$    .  
�������$
��Left=�6`   $��480,335,0,0q�6{   $	��Top=�6�   $	��104��6�   $��25��6�   6�   �� 59   
   -   5        $ buttonDetails��59      $��Detalji��6(    .  
�������$
��Left=�6e   $��
10,335,0,0q�6�   $	��Top=�6�   $	��104��6�   $��25��6�   6�   5;      5<      