using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TLABS.Notification
{
    public class Notifier
    {
        public static MessageBoxResult Show(string Text)
        {
            return ShowCore(Text);
        }

        public static MessageBoxResult Show(string Text, string Caption)
        {
            return ShowCore(Text, Caption);
        }

        public static MessageBoxResult ShowCopyable(string Text, string Caption = "Message")
        {
            return ShowCopyableMessageCore(Text, Caption);
        }

        public static MessageBoxResult Show(string Text, string Caption, MessageBoxButton MessageBoxButton)
        {
            return ShowCore(Text, Caption, MessageBoxButton);
        }

        public static MessageBoxResult Show(string Text, string Caption, MessageBoxButton MessageBoxButton, MessageBoxImage MessageBoxImage)
        {
            return ShowCore(Text, Caption, MessageBoxButton, MessageBoxImage);
        }

        public static void ShowErrorMessage(string Text)
        {
            ShowCore(Text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowErrorMessage(string Text, string Caption)
        {
            ShowCore(Text, Caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static MessageBoxResult Ask(string Text, string Caption)
        {
            return ShowCore(Text, Caption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        }

        public static MessageBoxResult Ask(string Text, string Caption, string YesButtonText, string NoButtonText, string CancelButtonText)
        {
            return ShowCore2(Text, Caption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question, YesButtonText, NoButtonText, "Ok", CancelButtonText);
        }
      
        static MessageBoxResult ShowCore(string Text, string Caption = "", MessageBoxButton MessageBoxButton = MessageBoxButton.OK, MessageBoxImage MessageBoxImage = MessageBoxImage.Information)
        {
            MessageBoxResult Result = MessageBoxResult.None;

            MessageWindow MessageWindow = new MessageWindow();
            MessageWindow.MessageText = Text;
            MessageWindow.MessageCaption = Caption;
            MessageWindow.MessageBoxButton = MessageBoxButton;
            MessageWindow.MessageBoxImage = MessageBoxImage;            

            MessageWindow.ShowDialog();
            Result = MessageWindow.Result;

            return Result;
        }

        static MessageBoxResult ShowCore2(string Text, string Caption = "", MessageBoxButton MessageBoxButton = MessageBoxButton.OK, MessageBoxImage MessageBoxImage = MessageBoxImage.Information, string YesButtonText = "Yes", string NoButtonText = "No", string OkButtonText="Ok", string CancelButtonText = "Cancel")
        {
            MessageBoxResult Result = MessageBoxResult.None;

            MessageWindow MessageWindow = new MessageWindow();
            MessageWindow.MessageText = Text;
            MessageWindow.MessageCaption = Caption;
            MessageWindow.MessageBoxButton = MessageBoxButton;
            MessageWindow.MessageBoxImage = MessageBoxImage;

            MessageWindow.YesButtonText = YesButtonText;
            MessageWindow.NoButtonText = NoButtonText;
            MessageWindow.OkButtonText = OkButtonText;
            MessageWindow.CancelButtonText = CancelButtonText;

            MessageWindow.ShowDialog();
            Result = MessageWindow.Result;

            return Result;
        }

        static MessageBoxResult ShowCopyableMessageCore(string Text, string Caption = "", MessageBoxButton MessageBoxButton = MessageBoxButton.OK, MessageBoxImage MessageBoxImage = MessageBoxImage.Information)
        {
            MessageBoxResult Result = MessageBoxResult.None;

            MessageWindow MessageWindow = new MessageWindow();            
            MessageWindow.MessageCaption = Caption;
            MessageWindow.MessageText = Text;
            MessageWindow.txtText.Visibility = Visibility.Collapsed;
            MessageWindow.txtCopyableText.Visibility = Visibility.Visible;
            MessageWindow.MessageBoxButton = MessageBoxButton;
            MessageWindow.MessageBoxImage = MessageBoxImage;

            MessageWindow.ShowDialog();
            Result = MessageWindow.Result;

            return Result;
        }  
    }

    internal static class IconUtilities
    {
        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        public static ImageSource ToImageSource(this Icon icon)
        {
            Bitmap bitmap = icon.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();
            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            if (!DeleteObject(hBitmap))
            {
                throw new Win32Exception();
            }
            return wpfBitmap;
        }
    } 
}
