   M S B A M L   `   `   `  ����H  DWPF.MainForms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF.MainFormsWPF.MainForms  5   	   )    #WPF.MainForms.SelectWordHangmanForm   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WPF.MainForms     5   	     � Title$  Hangman��5   	   $	��300��6   $	��500��6&   
����  �.��5
      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��Choose a Word��6   $��30(�6)   $��Center=�67   
�������$��1��5   '   �� 5   
   -   5         ��Name$ EnterWordText��5      $��2��6)   $��25(�66   
���   �$��20,40q�5   '   
�������$��40��5      6    �� 5   
   -   5         ��Name$ WhosWord��5      $��0��6&   
�������$��Center=�5      $��12(�61   �� 5   
   -   5         ��Name$ CreateWordButton��5      $��Finished��6+   $��3��5      $��Center=�6   
�������$��18(�5    $   $��3q�62   $��40��5!      $	��Top=�6   5"      5#      5$      