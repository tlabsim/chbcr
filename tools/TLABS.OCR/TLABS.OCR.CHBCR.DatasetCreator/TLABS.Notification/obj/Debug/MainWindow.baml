   M S B A M L   `   `   `  ����  TLABS.Notification&     TLABS.Notification.MessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Message box��5   	   $	��200��5   	   $	��450��6   $	��450��6"   $	��120��61   $
��1024��6A    � SizeToContent$ WidthAndHeight=�6Q    � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=�5        � AllowsTransparency .  � WindowStyle$
 None=�6_    J� Opacity$
 0.95Q�6�    � Topmost .  �� BitmapScalingMode$
 Fant=�5
   	   &   System.Windows.Media.TextOptions	   TextRenderingMode$	 	ClearType=�60   
 J� SnapsToDevicePixels
 . ��5   r   Z�  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $6 0/TLABS.Notification;component/IconResources.xaml?�6<   %    5      .��5      �� $��10q�6    �� CornerRadius$ 10��6   ���	#FFFFFDFB
�������$��.5q�6Y    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      	Direction$ 0Q�6/      Color$ 	#FF787878��6=      ShadowDepth$ 0Q�6O      Opacity$
 0.75Q�6_   ._�5   
   � $��Stretch=�6   $��Stretch=�6-    � ColumnDefinitions 5      �� 5      $��80 �6#   �� 5       � RowDefinitions 5       �� 5!      $��50 �6    6.   �� 5"      6"   �� 5#      $��50 �6    6.   .+�5&      �� -   5        $��
txtCaption��5&      $��2��6*   $��	30,0,30,0q�6>   $��Center=�6Q   $��20(�6l       NotificationCaptionForeColor#��[  6z   ��6�   �� *MessageCaption+6�   �� 5(      -   5        $��MessageIcon��5(      $��0��6'   $��1��67   $
��Left=�6D   $��Center=�6`   $��36��6{   $��36��6�   $��30,0,0,0q�6�   ��6�   �� *MessageImageSource+6�   �� 5*      -   5        $��txtText��5*      $��1��6'   $��1��67   $��0,0,30,0q�6D   $
��Wrap=�6V   $��Center=�6j   $��14(�6�     NotificationTextForeColor#��[ 6�   ��6�   �� *MessageText+6�   �� 5,      -   5        $��txtCopyableText��5,      $��1��6-   $��1��6=   $��0,0,30,0q�6J    �� TextWrapping$
 Wrap=�6\   $��Center=�6p   $��14(�6�   #��[ 6�    �� AcceptsReturn .  �� 
IsReadOnly . ��.  
������ $y�	Collapsed=�6]  ��6�   �� *MessageText+ � FocusVisualStyle 6A  Z� 6v  �� 5.      -   5        $��ButtonPanel��5.      $��2��6,   $��2��69   $��	30,0,30,0q�6M    �� Orientation$ 
Horizontal=�6`   $��Center=�6y   .+�5/      �� -   5        $��btnYes��5/      $��Center=�6'   $��5,0,5,0q�6B   $��75��6S   ���	#FFF6F6F6  ButtonForeColor#��[ 6x   y�6�   �� *IsYesVisible+��6�   �� *YesButtonText+6  �� 50      -   5        $��btnNo��50      $��Center=�6&   $��5,0,5,0q�6A   $��75��6R   ���	#FFF6F6F6#��[ 6w   y�6�   �� *IsNoVisible+��6�   �� *NoButtonText+6�   �� 51      -	   5        $��btnOk��51      $��Center=�6&   $��5,0,5,0q�6A   $��75��6R   ���	#FFF6F6F6#��[ 6w   y�6�   �� *IsOkVisible+��6�   �� *OkButtonText+6�   �� 52      -
   5        $��	btnCancel��52      $��Center=�6*   $��5,0,5,0q�6E   $��75��6V   ���	#FFF6F6F6#��[ 6{   y�6�   �� *IsCancelVisible+��6�   �� *CancelButtonText+6  53      54      55      56      