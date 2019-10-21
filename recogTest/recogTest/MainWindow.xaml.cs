using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace recogTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BitmapSource Capture()
        {
            using (var snipitSize = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using(var snipit = Graphics.FromImage(snipitSize))
                {
                    snipit.CopyFromScreen(0, 0, 0, 0, snipitSize.Size);
                    return Imaging.CreateBitmapSourceFromHBitmap(snipitSize.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
            }
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            bool isObjectPresent = false;
            
            image.Source = Capture();
        }

        private void STOP(object sender, RoutedEventArgs e)
        {

        }
    }
}
