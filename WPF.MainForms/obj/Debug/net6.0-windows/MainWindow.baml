   M S B A M L   `   `   `  ����H  DWPF.MainForms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF.MainFormsWPF.MainForms  5   	       WPF.MainForms.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WPF.MainForms     5   	   -   5          � Title$  MainMenu��5   	   $	��450��6   $	��800��6'   
����  �.��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��230 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��Assets/HangmanAsset.jpg��6   $	��100��62   $��1��6?   $��3��5      $	��Top=�6   �� 5    
   -   5         ��Name$ TimeText��5       $��1��6&   $��1��63   $	��Top=�5!      $��18(�6,   
�������6:   �� 5#   
   $��WELCOME!��6   
�������$��2��5%      $��1��5&      $��Center=�6!   $��60(�5'      $��0,0,0,20q�6"   �� 5)   
   $��2��6   $��2��6"   $��Center=�62   $��2��5*      .+�5+      �� $��Please Choose a game.��6   $��20(�65   
�������6C   �� 5,      $;��5Please select a profile if you havent already done so��6   $��14(�5-      $
��0,20q�6&   
�������64   �� 5.      -   5         ��Name$ CreateProfile��5.      $��Create Profile��6,   $��
90,80,90,0q�5/      $��20(�6)   $��35��6S   �� 50      -   5         ��Name$ ProfilesCombo��50       �� 
IsEditable$ False��6.   $��30,30q�51      $��18(�6&   52      �� 54   
   -   5        $ HangmanButton��54      $��1��6(   $��3��68   $��Hangman��55      $��70,50,70,70q�6#   $��45��68   $��18(�56      $
��Bold"�6   
�������57      �� 5:   
   -   5        $ TetrisButton��5:      $��3��6'   $��3��67   $��70,117,70,117q�5;      $��Tetris��6(   $��	ExtraBold"�69   $��18(�5<      
���   �
�������$��40��5=      $��80��6   6(   �� 5?   
   -   5        $ HighScoresButton��5?      $��3��6+   $��3��6;   $��Bottom=�5@      $��50q�6,   $��38��68   $��High Scores��5A      $��20(�6'   
�������5B      5D      5E      