   M S B A M L   `   `   `  ����   TLABS.Notification&     TLABS.Notification.MessageWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Message box��$	��200��$	��450��$	��450��$	��120��$
��1024�� � SizeToContent$ WidthAndHeight=� � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � WindowStyle$
 None=� J� Opacity$
 0.95Q� � Topmost .  �� BitmapScalingMode$
 Fant=�&   System.Windows.Media.TextOptions	   TextRenderingMode$	 	ClearType=�
 J� SnapsToDevicePixels
 . ��Z�  � 	Resources  �� MergedDictionaries �� Source��  �� $6 0/TLABS.Notification;component/IconResources.xaml?�%    .���� $��10q� �� CornerRadius$ 10�����	#FFFFFDFB
�������$��.5q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   	Direction$ 0Q�   Color$ 	#FF787878��   ShadowDepth$ 0Q�   Opacity$
 0.75Q�._�� $��Stretch=�$��Stretch=� � ColumnDefinitions �� $��80 ���  � RowDefinitions �� $��50 ��� �� $��50 �.+��� -   $��
txtCaption��$��2��$��	30,0,30,0q�$��Center=�$��20(�    NotificationCaptionForeColor#��[  ���� *MessageCaption+�� -   $��MessageIcon��$��0��$��1��$
��Left=�$��Center=�$��36��$��36��$��30,0,0,0q����� *MessageImageSource+�� -   $��txtText��$��1��$��1��$��0,0,30,0q�$
��Wrap=�$��Center=�$��14(�  NotificationTextForeColor#��[ ���� *MessageText+�� -   $��txtCopyableText��$��1��$��1��$��0,0,30,0q� �� TextWrapping$
 Wrap=�$��Center=�$��14(�#��[  �� AcceptsReturn .  �� 
IsReadOnly . ��.  
������ $y�	Collapsed=����� *MessageText+ � FocusVisualStyle Z� �� -   $��ButtonPanel��$��2��$��2��$��	30,0,30,0q� �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��btnYes��$��Center=�$��5,0,5,0q�$��75�����	#FFF6F6F6  ButtonForeColor#��[ y��� *IsYesVisible+.��Yes�� -   $��btnNo��$��Center=�$��5,0,5,0q�$��75�����	#FFF6F6F6#��[ y��� *IsNoVisible+.��No�� -   $��btnOk��$��Center=�$��5,0,5,0q�$��75�����	#FFF6F6F6#��[ y��� *IsOkVisible+.��Ok�� -	   $��	btnCancel��$��Center=�$��5,0,5,0q�$��75�����	#FFF6F6F6#��[ y��� *IsCancelVisible+.��Cancel