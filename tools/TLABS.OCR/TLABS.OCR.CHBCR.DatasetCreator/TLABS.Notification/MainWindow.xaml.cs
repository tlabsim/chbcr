using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System;

namespace TLABS.Notification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window, INotifyPropertyChanged
    {    
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Window Control
        bool IsMouseDown
        {
            get;
            set;
        }

        System.Drawing.Point MouseDownLocation
        {
            get;
            set;
        }

        System.Drawing.Point MouseDownWindowLocation
        {
            get;
            set;
        }
        #endregion
        
        public MessageBoxResult Result = MessageBoxResult.None;
        
        string _MessageCaption = string.Empty;
        public string MessageCaption
        {
            get
            {
                return _MessageCaption;
            }
            set
            {
                _MessageCaption = value;
                NotifyPropertyChange("MessageCaption");
            }
        }

        string _MessageText = string.Empty;
        public string MessageText
        {
            get
            {
                return _MessageText;
            }
            set
            {
                _MessageText = value;
                NotifyPropertyChange("MessageText");
            }
        }

        MessageBoxButton _MessageBoxButton = MessageBoxButton.OK;
        public MessageBoxButton MessageBoxButton
        {
            get
            {
                return _MessageBoxButton;
            }
            set
            {
                _MessageBoxButton = value;

                switch (_MessageBoxButton)
                {
                    case System.Windows.MessageBoxButton.OK:

                        IsYesVisible = Visibility.Collapsed;
                        IsNoVisible = Visibility.Collapsed;
                        IsOkVisible = Visibility.Visible;
                        IsCancelVisible = Visibility.Collapsed;

                        btnOk.Focus();
                        break;

                    case System.Windows.MessageBoxButton.OKCancel:

                        IsYesVisible = Visibility.Collapsed;
                        IsNoVisible = Visibility.Collapsed;
                        IsOkVisible = Visibility.Visible;
                        IsCancelVisible = Visibility.Visible;

                        btnCancel.Focus();
                        break;

                    case System.Windows.MessageBoxButton.YesNo:

                        IsYesVisible = Visibility.Visible;
                        IsNoVisible = Visibility.Visible;
                        IsOkVisible = Visibility.Collapsed;
                        IsCancelVisible = Visibility.Collapsed;

                        btnYes.Focus();
                        break;

                    case System.Windows.MessageBoxButton.YesNoCancel:

                        IsYesVisible = Visibility.Visible;
                        IsNoVisible = Visibility.Visible;
                        IsOkVisible = Visibility.Collapsed;
                        IsCancelVisible = Visibility.Visible;

                        btnCancel.Focus();
                        break;
                }
            }
        }

        MessageBoxImage _MessageBoxImage = MessageBoxImage.Information;
        public MessageBoxImage MessageBoxImage
        {
            get
            {
                return _MessageBoxImage;
            }
            set
            {
                _MessageBoxImage = value;

                switch (_MessageBoxImage)
                {

                    //case MessageBoxImage.Hand:
                    //case MessageBoxImage.Stop:
                    case MessageBoxImage.Error:
                        //MessageImageSource = SystemIcons.Error.ToImageSource();
                        MessageImageSource = (BitmapImage)this.Resources["icon_Error"];
                        break;

                    //case MessageBoxImage.Exclamation:
                    case MessageBoxImage.Warning:
                        //MessageImageSource = SystemIcons.Warning.ToImageSource();
                        MessageImageSource = (BitmapImage)this.Resources["icon_Warning"];
                        break;

                    case MessageBoxImage.Question:
                        //MessageImageSource = SystemIcons.Question.ToImageSource();
                        MessageImageSource = (BitmapImage)this.Resources["icon_Question"];
                        break;

                    //case MessageBoxImage.Asterisk:
                    case MessageBoxImage.Information:
                        //MessageImageSource = SystemIcons.Information.ToImageSource();
                        MessageImageSource = (BitmapImage)this.Resources["icon_Information"];
                        break;

                    default:
                        MessageImageSource = null;
                        break;
                }
            }
        }

        ImageSource _MessageImageSource;
        public ImageSource MessageImageSource
        {
            get { return _MessageImageSource; }
            set
            {
                _MessageImageSource = value;                
                NotifyPropertyChange("MessageImageSource");
            }
        }

        Visibility _IsYesVisible = Visibility.Collapsed;
        public Visibility IsYesVisible
        {
            get
            {
                return _IsYesVisible;
            }
            set
            {
                _IsYesVisible = value;
                NotifyPropertyChange("IsYesVisible");
            }
        }

        Visibility _IsNoVisible = Visibility.Collapsed;
        public Visibility IsNoVisible
        {
            get
            {
                return _IsNoVisible;
            }
            set
            {
                _IsNoVisible = value;
                NotifyPropertyChange("IsNoVisible");
            }
        }

        Visibility _IsOkVisible = Visibility.Collapsed;
        public Visibility IsOkVisible
        {
            get
            {
                return _IsOkVisible;
            }
            set
            {
                _IsOkVisible = value;
                NotifyPropertyChange("IsOkVisible");
            }
        }

        Visibility _IsCancelVisible = Visibility.Collapsed;
        public Visibility IsCancelVisible
        {
            get
            {
                return _IsCancelVisible;
            }
            set
            {
                _IsCancelVisible = value;
                NotifyPropertyChange("IsCancelVisible");
            }
        }

        string _YesButtonText = "Yes";
        public string YesButtonText
        {
            get
            {
                return _YesButtonText;
            }
            set
            {
                _YesButtonText = value;

                NotifyPropertyChange("YesButtonText");
            }
        }
    
        string _NoButtonText = "No";
        public string NoButtonText
        {
            get
            {
                return _NoButtonText;
            }
            set
            {
                _NoButtonText = value;

                NotifyPropertyChange("NoButtonText");
            }
        }

        string _OkButtonText = "Ok";
        public string OkButtonText
        {
            get
            {
                return _OkButtonText;
            }
            set
            {
                _OkButtonText = value;

                NotifyPropertyChange("OkButtonText");
            }
        }

        string _CancelButtonText = "Cancel";
        public string CancelButtonText
        {
            get
            {
                return _CancelButtonText;
            }
            set
            {
                _CancelButtonText = value;

                NotifyPropertyChange("CancelButtonText");
            }
        }

        public MessageWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            this.Close();
        }

        #region Window events
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.IsMouseDown = true;
            MouseDownLocation = System.Windows.Forms.Cursor.Position;
            MouseDownWindowLocation = new System.Drawing.Point((int)this.Left, (int)this.Top);
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
                System.Drawing.Point CurPos = System.Windows.Forms.Cursor.Position;
                if (Math.Abs(CurPos.X - MouseDownLocation.X) >= 3 && Math.Abs(CurPos.Y - MouseDownLocation.Y) >= 3)
                {
                    if (!this.IsMouseCaptured)
                    {
                        this.CaptureMouse();
                    }
                    this.Left = this.MouseDownWindowLocation.X + (CurPos.X - MouseDownLocation.X);
                    this.Top = this.MouseDownWindowLocation.Y + (CurPos.Y - MouseDownLocation.Y);
                }
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.IsMouseDown = false;
            if (this.IsMouseCaptured)
            {
                this.ReleaseMouseCapture();
            }
        }
        #endregion
    }
}
