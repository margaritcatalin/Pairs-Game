   M S B A M L   `   `   `  ����D  @PairsGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PairsGame.ViewModelsPairsGame.ViewModels  5   	       PairsGame.Views.Game   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1vm"clr-namespace:PairsGame.ViewModels     5   	     � Title$
  Game��5   	   $	��450��6   $	��800��6#    � 	Resources 5	         SlideBorder �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  
CardButton �� 
TargetType��%�  &	        &	     7   �� 5
   
   " ��6$   .�5      ��  � ��$ 3q�60    5      P� 5       � {� .  . �5      ��  � ��
 �2�2�64   �� 5       � ��$ 3q�68   5      P� 5       � {� . . �5      ��  � ��
 �   �64   5      5      �� 5   
   " ��6.   .R�5      �� 8��  ��6:   �� *BorderBrush+._�5      �� $
��Fill=�6   ��6'   �� *
SlideImage+5      5      5      .��5      ]� ��5   
   �� 5      	 j� Stretch$	 UniformToFill=�6   
 �� ImageSource$9
 3/PairsGame;component/Resources/black_background.jpg��61   .+�5    
   o� -   5        $��MainMenu��5       $	��Top=�6   .@�5!      m� -   5        $��MenuItemFile��5!      $��_File��6+   .@�5"      m� -   5        $��MenuItemFileNewGame��5"      $��	_New Game��66   6I   m� 5#      -   5        $��MenuItemFileOpenGame��5#      $��
_Open Game��67   6K   m� 5$      -   5        $��MenuItemFileSaveGame��5$      $��
_Save Game��67   6K   m� 5%      -   5        $��MenuItemFileStatistics��5%      $��_Statistics��69   6N   �� 5&      m� 5'      -   5        $��MenuItemFileExit��5'      $��_Exit��63   6B   5(      m� 5)      -   5        $��MenuItemOptions��5)      $��_Options��6.   .@�5*      m� -	   5        $��MenuItemOptions4x4��5*      $��
_Table 4x4��65   6I   m� 5+      -
   5        $��MenuItemOptions6x6��5+      $��
_Table 6x6��65   6I   m� 5,      -   5        $��MenuItemOptionsaxb��5,      $��
_Table AxB��65   6I   5-      m� 5.      -   5        $��MenuItemHelp��5.      $��_Help��6+   .@�5/      m� -   5        $��MenuItemHelpAbout��5/      $��_About��64   6D   50      51      ]� 52   
   .+�53      �� $	��Top=�6   $��Center=�6-   
���  ��$��24(�6�   ��6J   �� *
Timer.Time+ �� StringFormat$ 	Time: {0}��6�   � 54      -   5        $��cardGrid��54      $��Bottom=�6$   $��10q�6�    � DataContext 6<   �� *Slides+{�6[   �� *areSlidesActive+ 55      ��%�   '��       �� 56      " ��6   .�57      ��  � ��$ 1q�63   �� 58       � �� 65   �� *	GridRow+�� 59       � �� 68   �� *
GridColumn+5:      5;      5<      5>      5?      5@      