using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TLABS.Extensions
{
    public static class BitmapExtensions
    {
        #region helpers
        public static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static double Cos(double degrees)
        {
            return Math.Cos(DegreesToRadians(degrees));
        }

        public static double Sin(double degrees)
        {
            return Math.Sin(DegreesToRadians(degrees));
        }
        #endregion

        public static byte TruncateColorValue(byte color)
        {
            if (color < 0) color = 0;
            else if (color > 255) color = 255;
            return (byte)color;
        }

        public static byte TruncateColorValue(int color)
        {
            if (color < 0) color = 0;
            else if (color > 255) color = 255;
            return (byte)color;
        }

        public static byte TruncateColorValue(double color)
        {
            if (color < 0) color = 0;
            else if (color > 255) color = 255;
            return (byte)color;
        }

        public static bool InBound(int x, int y, int width, int height)
        {
            return x > 0 && x < width && y > 0 && y < height;
        }

        public static bool InBound(int x, int y, Bitmap bmp)
        {
            return x > 0 && x < bmp.Width && y > 0 && y < bmp.Height;
        }

        public static bool IsBlackish(this Color c)
        {
            return c.R < 100 && c.G < 100 && c.B < 100;
        }

        public static bool IsWhitish(this Color c)
        {
            return c.R > 160 && c.G > 160 && c.B > 160;
        }

        public static bool IsGrey(this Color c)
        {
            return c.R == c.G && c.R == c.B;
        }

        public static PointF RotatePoint(this PointF point, PointF axis, double angle)
        {
            if (angle == 0) return point;

            double cos = Cos(angle);
            double sin = Sin(angle);
            double rdx = 0, rdy = 0;
            double dx, dy;

            PointF rotated = new PointF();

            dx = point.X - axis.X;
            dy = point.Y - axis.Y;

            rdx = dx * cos - dy * sin;
            rdy = dx * sin + dy * cos;

            rdx += axis.X;
            rdy += axis.Y;

            rotated.X = (float)rdx;
            rotated.Y = (float)rdy;

            return rotated;
        }

        public static Bitmap AdjustBrightness(this Bitmap bmp, int percentage)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.ApplyBrightness(percentage);

            return bmp;
        }

        public static Bitmap AdjustContrast(this Bitmap bmp, int percentage)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.AdjustContrast(percentage);

            return bmp;
        }

        public static Bitmap AdjustGamma(this Bitmap bmp, double gamma)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.AdjustGamma(gamma);

            return bmp;
        }

        public static Bitmap AdjustTint(this Bitmap bmp, Color tint, double alpha)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.AdjustTint(tint, alpha);

            return bmp;
        }

        public static Bitmap ConvertToGrayScale(this Bitmap bmp)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.ToGrayScale();

            return bmp;
        }

        public static Bitmap InvertImage(this Bitmap bmp, int percentage)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.Invert();

            return bmp;
        }

        public static Bitmap Resize(this Bitmap bmp, double scale)
        {
            int new_width = (int)(bmp.Width * scale);
            int new_height = (int)(bmp.Height * scale);

            BitmapProcessor p = new BitmapProcessor(bmp);
            return p.ResizeClone(new_width, new_height);
        }

        public static Bitmap Resize(this Bitmap bmp, int new_width, int new_height)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            return p.ResizeClone(new_width, new_height);
        }

        public static Bitmap Rotate(this Bitmap bmp, Point center, double angle, bool fit = false)
        {
            BitmapProcessor p = new BitmapProcessor(bmp);
            p.Rotate(center, angle, fit);

            return bmp;
        }

        public static Bitmap Rotate(this Bitmap bmp, double angle, bool fit = false)
        {
            Point center = new Point(bmp.Width / 2, bmp.Height / 2);

            BitmapProcessor p = new BitmapProcessor(bmp);
            p.Rotate(center, angle, fit);

            return bmp;
        }

        public static Bitmap Rotate2(this Bitmap bmp, float angle)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.RotateTransform(angle);
            }

            return bmp;
        }

        public static Bitmap Crop(this Bitmap bmp, int x, int y, int width, int height)
        {
            if (x >= width) x = 0;
            if (y >= height) y = 0;

            if (x + width > bmp.Width)
                width = bmp.Width - x;
            if (y + height > bmp.Height)
                height = bmp.Height - y;

            Rectangle rect = new Rectangle(x, y, width, height);

            return (Bitmap)bmp.Clone(rect, bmp.PixelFormat);
        }

        public static Bitmap DrawOutCropArea(this Bitmap bmp, int x, int y, int width, int height, Brush fill_brush)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (fill_brush == null)
                    fill_brush = new SolidBrush(Color.White);

                Rectangle rect1 = new Rectangle(0, 0, bmp.Width, y);
                Rectangle rect2 = new Rectangle(0, y, x, height);
                Rectangle rect3 = new Rectangle(0, (y + height), bmp.Width, bmp.Height);
                Rectangle rect4 = new Rectangle((x + width), y, (bmp.Width - x - width), height);

                g.FillRectangle(fill_brush, rect1);
                g.FillRectangle(fill_brush, rect2);
                g.FillRectangle(fill_brush, rect3);
                g.FillRectangle(fill_brush, rect4);
            }

            return bmp;
        }

        public static Bitmap ApplyGaussianBlur(this Bitmap bmp, int radius)
        {
            BitmapProcessor gbp = new BitmapProcessor(bmp);
            return gbp.GaussianBlur(radius);
        }

        public static Bitmap Blur(this Bitmap bmp, Rectangle rectangle, Int32 blur_size)
        {
            Bitmap blurred = new Bitmap(bmp.Width, bmp.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (Int32 xx = rectangle.X; xx < rectangle.X + rectangle.Width; xx++)
            {
                for (Int32 yy = rectangle.Y; yy < rectangle.Y + rectangle.Height; yy++)
                {
                    Int32 avgR = 0, avgG = 0, avgB = 0;
                    Int32 blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (Int32 x = xx; (x < xx + blur_size && x < bmp.Width); x++)
                    {
                        for (Int32 y = yy; (y < yy + blur_size && y < bmp.Height); y++)
                        {
                            Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (Int32 x = xx; x < xx + blur_size && x < bmp.Width && x < rectangle.Width; x++)
                        for (Int32 y = yy; y < yy + blur_size && y < bmp.Height && y < rectangle.Height; y++)
                            blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurred;
        }
    }

    public class BitmapProcessor : IDisposable
    {
        private bool IsDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    try
                    {
                        //if (_original != null)
                        //{
                        //    _original.Dispose();
                        //}

                        GC.Collect();
                    }
                    catch { }
                }
                // Dispose unmanaged managed resources.

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private Bitmap _original;
        public Bitmap Processed
        {
            get
            {
                return _original;
            }
        }

        private int[] _red;
        private int[] _green;
        private int[] _blue;

        private int _width;
        private int _height;

        private readonly ParallelOptions _pOptions = new ParallelOptions { MaxDegreeOfParallelism = 16 };

        public Color Background = Color.White;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public BitmapProcessor(Bitmap bmp)
        {
            SetBitmap(bmp);
        }

        public void SetBitmap(Bitmap bmp)
        {
            _original = bmp;
            _width = bmp.Width;
            _height = bmp.Height;

            PopulateColorArrays();
        }

        public void Show()
        {
            if (this._original != null)
            {
                _original.Show();
            }
        }

        public void Cleanup()
        {
            if (_original != null) _original.Dispose();
        }

        public BitmapProcessor ApplyBrightness(int percentage)
        {
            if (percentage == 0) return this;

            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            if (percentage < -100) percentage = -100;
            if (percentage > 100) percentage = 100;

            int adj = (int)(percentage * 2.55);

            Parallel.Invoke(
                () => AdjustBrightness(_red, new_red, adj),
                () => AdjustBrightness(_green, new_green, adj),
                () => AdjustBrightness(_blue, new_blue, adj));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor AdjustContrast(int percentage)
        {
            if (percentage == 0) return this;

            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            if (percentage < -100) percentage = -100;
            if (percentage > 100) percentage = 100;

            int adj = (int)(percentage * 2.55);
            double factor = (259 * (adj + 255)) / (255 * (259 - adj));

            Parallel.Invoke(
                () => AdjustContrast(_red, new_red, factor),
                () => AdjustContrast(_green, new_green, factor),
                () => AdjustContrast(_blue, new_blue, factor));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);            

            return this;
        }

        public BitmapProcessor AdjustGamma(double gamma)
        {
            if (gamma == 1) return this;

            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            double adj = (1 / gamma);

            Parallel.Invoke(
                () => AdjustGamma(_red, new_red, adj),
                () => AdjustGamma(_green, new_green, adj),
                () => AdjustGamma(_blue, new_blue, adj));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor AdjustTint(Color tint, double alpha)
        {
            if (alpha < 0) alpha = 0;
            if (alpha > 1) alpha = 1;

            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            Parallel.Invoke(
                () => AdjustTint(_red, new_red, tint.R, alpha),
                () => AdjustTint(_green, new_green, tint.G, alpha),
                () => AdjustTint(_blue, new_blue, tint.B, alpha));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor ToGrayScale()
        {
            int grey = 0;
            var dest = new int[_width * _height];

            for (int i = 0; i < dest.Length; i++)
            {
                grey = (int)(0.299 * _red[i] + 0.587 * _green[i] + 0.114 * _blue[i]);
                if (grey > 255) grey = 255;
                if (grey < 0) grey = 0;

                dest[i] = (int)(0xff000000u | (uint)(grey << 16) | (uint)(grey << 8) | (uint)grey);

                _red[i] = grey;
                _green[i] = grey;
                _blue[i] = grey;
            };

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor Binarise()
        {
            int threshold = 128;
            var grey = new int[_width * _height];
            var dest = new int[_width * _height];

            var buckets = new int[16];
            for (int i = 0; i < 16; i++)
            {
                buckets[i] = 0;
            }

            for (int i = 0; i < dest.Length; i++)
            {
                grey[i] = (int)(0.299 * _red[i] + 0.587 * _green[i] + 0.114 * _blue[i]);
                if (grey[i] > 255) grey[i] = 255;
                if (grey[i] < 0) grey[i] = 0;

                buckets[grey[i] / 16]++;
            }

            int avg = (int)buckets.Average();
            double total = 0, cum_sum = 0;
            for (int i = 0; i < 16; i++)
            {
                if (buckets[i] > avg) buckets[i] = avg;

                total += buckets[i];
                cum_sum += (buckets[i] * ((i * 16) + 8));
            }

            threshold = (int)(cum_sum / total);

            for (int i = 0; i < dest.Length; i++)
            {
                grey[i] = grey[i] > threshold ? 255 : 0;

                dest[i] = (int)(0xff000000u | (uint)(grey[i] << 16) | (uint)(grey[i] << 8) | (uint)grey[i]);

                _red[i] = grey[i];
                _green[i] = grey[i];
                _blue[i] = grey[i];
            }

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor Binarise(int threshold)
        {
            int grey = 0;
            var dest = new int[_width * _height];

            for (int i = 0; i < dest.Length; i++)
            {
                grey = (int)(0.299 * _red[i] + 0.587 * _green[i] + 0.114 * _blue[i]);
                if (grey > 255) grey = 255;
                if (grey < 0) grey = 0;

                grey = grey > threshold ? 255 : 0;

                dest[i] = (int)(0xff000000u | (uint)(grey << 16) | (uint)(grey << 8) | (uint)grey);

                _red[i] = grey;
                _green[i] = grey;
                _blue[i] = grey;
            }

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor Invert()
        {
            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            Parallel.Invoke(
                () => Invert(_red, new_red),
                () => Invert(_green, new_green),
                () => Invert(_blue, new_blue));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor GrayscaleInverseConvolve3x3(double[,] k)
        {
            int kh = k.GetLength(0),
                kw = k.GetLength(1);

            if (kh != 3 && kw != 3) return this;

            double[] _k = new double[9];

            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    _k[h * 3 + w] = k[h, w];
                }
            }

            int _size = _width * _height;
            var grey = new int[_size];
            var dest = new int[_size];

            for (int i = 0; i < _size; i++)
            {
                grey[i] = 255 - (int)(0.299 * _red[i] + 0.587 * _green[i] + 0.114 * _blue[i]);
                if (grey[i] > 255) grey[i] = 255;
                if (grey[i] < 0) grey[i] = 0;
            }

            double d_new_grey = 0.0;
            int new_grey = 0;
            for (int r = 0; r < _size; r += _width)
            {
                for (int c = 0; c < _width; c++)
                {
                    int i = r + c;
                    bool not_in_fringe = c > 0 && c < _width - 1;

                    int[] indices = new int[9] { 
                        not_in_fringe ? i - _width - 1 : -1,
                        i - _width,
                        not_in_fringe ? i - _width + 1 : -1,
                        not_in_fringe ? i - 1 : -1,
                        i, 
                        not_in_fringe ? i + 1 : -1,
                        not_in_fringe ? i + _width - 1 : -1,
                        i + _width,
                        not_in_fringe ? i + _width + 1 : -1                
                    };

                    d_new_grey = 0;
                    new_grey = 0;
                    for (int p = 0; p < 9; p++)
                    {
                        int ip = indices[p];

                        if (ip >= 0 && ip < _size)
                        {
                            d_new_grey += grey[ip] * _k[p];
                        }
                    }

                    new_grey = 255 - (int)d_new_grey;
                    if (new_grey < 0) new_grey = 0;
                    if (new_grey > 255) new_grey = 255;

                    dest[i] = (int)(0xff000000u | (uint)(new_grey << 16) | (uint)(new_grey << 8) | (uint)new_grey);

                    _red[i] = new_grey;
                    _green[i] = new_grey;
                    _blue[i] = new_grey;
                }
            }

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        #region Rotate and flip
        public BitmapProcessor Rotate(double angle, bool fit = false)
        {
            PointF center = new PointF((float)_width / 2.0F, (float)_height / 2.0F);
            return Rotate(center, angle, fit);
        }

        public BitmapProcessor Rotate(PointF center, double angle, bool fit = false)
        {
            if (fit)
            {
                return RotateFit_NoCrop(center, angle);
            }
            else
            {
                return RotateInPlace(center, angle);
            }
        }

        public BitmapProcessor FlipHorizontal()
        {
            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            Parallel.Invoke(
                () => ArrayFlipHorizontal(_red, new_red),
                () => ArrayFlipHorizontal(_green, new_green),
                () => ArrayFlipHorizontal(_blue, new_blue));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor FlipVertical()
        {
            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            Parallel.Invoke(
                () => ArrayFlipVertical(_red, new_red),
                () => ArrayFlipVertical(_green, new_green),
                () => ArrayFlipVertical(_blue, new_blue));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        public BitmapProcessor FlipDiagonal()
        {
            FlipHorizontal();
            FlipVertical();
            return this;
        }

        private BitmapProcessor RotateInPlace(PointF center, double angle)
        {
            if (angle == 0) return this;

            int _size = _width * _height;
            var new_red = new int[_size];
            var new_green = new int[_size];
            var new_blue = new int[_size];
            var dest = new int[_size];

            double cos = Cos(angle);
            double sin = Sin(angle);

            double dx, dy;

            double fx, fy, nx, ny;
            int cx, cy, fr_x, fr_y;
            double bp1, bp2;

            int p1, p2, p3, p4;
            int br = this.Background.R, bg = this.Background.G, bb = this.Background.B;

            int i = 0;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    dx = x - center.X;
                    dy = y - center.Y;

                    double rdx = 0;
                    double rdy = 0;

                    rdx = dx * cos + dy * sin;
                    rdy = dy * cos - dx * sin;

                    rdx += center.X;
                    rdy += center.Y;

                    fr_x = (int)Math.Floor(rdx);
                    fr_y = (int)Math.Floor(rdy);

                    if (fr_x >= -1 && fr_x < _width && fr_y >= -1 && fr_y < _height)
                    {
                        cx = fr_x + 1;
                        cy = fr_y + 1;

                        fx = rdx - fr_x;
                        fy = rdy - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        p1 = (fr_x >= 0 && fr_y >= 0) ? (fr_y * _width + fr_x) : -1;
                        p2 = (fr_y >= 0 && cx < _width) ? (fr_y * _width + cx) : -1;
                        p3 = (cy < _height && fr_x >= 0) ? (cy * _width + fr_x) : -1;
                        p4 = (cy < _height && cx < _width) ? (cy * _width + cx) : -1;

                        // Red

                        bp1 = nx * (p1 >= 0 ? _red[p1] : br) + fx * (p2 >= 0 ? _red[p2] : br);
                        bp2 = nx * (p3 >= 0 ? _red[p3] : br) + fx * (p4 >= 0 ? _red[p4] : br);
                        new_red[i] = (int)(ny * bp1 + fy * bp2);

                        // Green
                        bp1 = nx * (p1 >= 0 ? _green[p1] : bg) + fx * (p2 >= 0 ? _green[p2] : bg);
                        bp2 = nx * (p3 >= 0 ? _green[p3] : bg) + fx * (p4 >= 0 ? _green[p4] : bg);
                        new_green[i] = (int)(ny * bp1 + fy * bp2);

                        // Blue
                        bp1 = nx * (p1 >= 0 ? _blue[p1] : bb) + fx * (p2 >= 0 ? _blue[p2] : bb);
                        bp2 = nx * (p3 >= 0 ? _blue[p3] : bb) + fx * (p4 >= 0 ? _blue[p4] : bb);
                        new_blue[i] = (int)(ny * bp1 + fy * bp2);

                        if (new_red[i] > 255) new_red[i] = 255;
                        if (new_green[i] > 255) new_green[i] = 255;
                        if (new_blue[i] > 255) new_blue[i] = 255;

                        if (new_red[i] < 0) new_red[i] = 0;
                        if (new_green[i] < 0) new_green[i] = 0;
                        if (new_blue[i] < 0) new_blue[i] = 0;
                    }
                    else
                    {
                        new_red[i] = br;
                        new_green[i] = bg;
                        new_blue[i] = bb;
                    }

                    dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                    i++;
                }
            }

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            _red = new_red;
            _green = new_green;
            _blue = new_blue;

            return this;
        }

        private BitmapProcessor RotateFit_NoCrop(PointF center, double angle)
        {
            if (angle == 0) return this;

            double cos = Cos(angle);
            double sin = Sin(angle);
            double rdx = 0, rdy = 0;

            double dx, dy;
            int min_x = int.MaxValue, max_x = int.MinValue, min_y = int.MaxValue, max_y = int.MinValue;

            var corner_points = new Point[4] { new Point(0, 0), new Point(_width, 0), new Point(0, _height), new Point(_width, _height) };
            foreach (var p in corner_points)
            {
                dx = p.X - center.X;
                dy = p.Y - center.Y;

                rdx = dx * cos - dy * sin;
                rdy = dx * sin + dy * cos;

                rdx += center.X;
                rdy += center.Y;

                if (rdx < min_x) min_x = (int)Math.Floor(rdx);
                if (rdx > max_x) max_x = (int)Math.Ceiling(rdx);

                if (rdy < min_y) min_y = (int)Math.Floor(rdy);
                if (rdy > max_y) max_y = (int)Math.Ceiling(rdy);
            }

            int new_width = max_x - min_x;
            int new_height = max_y - min_y;
            int new_size = new_width * new_height;

            var new_red = new int[new_size];
            var new_green = new int[new_size];
            var new_blue = new int[new_size];
            var dest = new int[new_size];

            double fx, fy, nx, ny;
            int cx, cy, fr_x, fr_y;
            double bp1, bp2;

            int p1, p2, p3, p4;
            int br = this.Background.R, bg = this.Background.G, bb = this.Background.B;

            center.X -= min_x;
            center.Y -= min_y;

            int i = 0;
            for (int y = 0; y < new_height; y++)
            {
                for (int x = 0; x < new_width; x++)
                {
                    dx = x - center.X;
                    dy = y - center.Y;

                    rdx = dx * cos + dy * sin;
                    rdy = dy * cos - dx * sin;

                    rdx += (center.X + min_x);
                    rdy += (center.Y + min_y);

                    fr_x = (int)Math.Floor(rdx);
                    fr_y = (int)Math.Floor(rdy);

                    if (fr_x >= -1 && fr_x < _width && fr_y >= -1 && fr_y < _height)
                    {
                        cx = fr_x + 1;
                        cy = fr_y + 1;

                        fx = rdx - fr_x;
                        fy = rdy - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        p1 = (fr_x >= 0 && fr_y >= 0) ? (fr_y * _width + fr_x) : -1;
                        p2 = (fr_y >= 0 && cx < _width) ? (fr_y * _width + cx) : -1;
                        p3 = (cy < _height && fr_x >= 0) ? (cy * _width + fr_x) : -1;
                        p4 = (cy < _height && cx < _width) ? (cy * _width + cx) : -1;

                        // Red
                        bp1 = nx * (p1 >= 0 ? _red[p1] : br) + fx * (p2 >= 0 ? _red[p2] : br);
                        bp2 = nx * (p3 >= 0 ? _red[p3] : br) + fx * (p4 >= 0 ? _red[p4] : br);
                        new_red[i] = (int)(ny * bp1 + fy * bp2);

                        // Green
                        bp1 = nx * (p1 >= 0 ? _green[p1] : bg) + fx * (p2 >= 0 ? _green[p2] : bg);
                        bp2 = nx * (p3 >= 0 ? _green[p3] : bg) + fx * (p4 >= 0 ? _green[p4] : bg);
                        new_green[i] = (int)(ny * bp1 + fy * bp2);

                        // Blue
                        bp1 = nx * (p1 >= 0 ? _blue[p1] : bb) + fx * (p2 >= 0 ? _blue[p2] : bb);
                        bp2 = nx * (p3 >= 0 ? _blue[p3] : bb) + fx * (p4 >= 0 ? _blue[p4] : bb);
                        new_blue[i] = (int)(ny * bp1 + fy * bp2);

                        if (new_red[i] > 255) new_red[i] = 255;
                        if (new_green[i] > 255) new_green[i] = 255;
                        if (new_blue[i] > 255) new_blue[i] = 255;

                        if (new_red[i] < 0) new_red[i] = 0;
                        if (new_green[i] < 0) new_green[i] = 0;
                        if (new_blue[i] < 0) new_blue[i] = 0;
                    }
                    else
                    {
                        new_red[i] = br;
                        new_green[i] = bg;
                        new_blue[i] = bb;
                    }

                    dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                    i++;
                }
            }

            var new_bmp = new Bitmap(new_width, new_height);
            var rect = new Rectangle(0, 0, new_width, new_height);
            var bits2 = new_bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            new_bmp.UnlockBits(bits2);

            _width = new_width;
            _height = new_height;

            _red = new_red;
            _green = new_green;
            _blue = new_blue;

            _original = new_bmp;

            return this;
        }

        public BitmapProcessor RotateFit_Crop(double angle)
        {
            //Un-implemented
            return this;
        }

        public BitmapProcessor RotateFit_Zoom(double angle)
        {
            //Un-implemented
            return this;
        }
        #endregion

        #region Resize
        public BitmapProcessor Resize(int new_width, int new_height)
        {
            if (new_width == _width && new_height == _height) return this;

            int new_size = new_width * new_height;
            var dest = new int[new_size];
            var new_red = new int[new_size];
            var new_green = new int[new_size];
            var new_blue = new int[new_size];

            double width_factor = (double)_width / (double)new_width;
            double height_factor = (double)_height / (double)new_height;

            double x_origin, y_origin;
            double fx, fy, nx, ny;
            int cx, cy, fr_x, fr_y;
            double bp1, bp2;

            int p1, p2, p3, p4;

            var x_origins = new double[new_width];
            var fr_xs = new int[new_width];

            for (int x = 0; x < new_width; x++)
            {
                x_origin = x * width_factor;
                x_origins[x] = x_origin;
                fr_xs[x] = (int)Math.Floor(x_origin);
            }

            for (int y = 0; y < new_height; y++)
            {
                y_origin = y * height_factor;
                fr_y = (int)Math.Floor(y_origin);
                cy = fr_y + 1;
                if (cy >= _height) cy = fr_y;
                fy = y_origin - fr_y;
                ny = 1.0 - fy;

                for (int x = 0; x < new_width; x++)
                {
                    int i = y * new_width + x;

                    x_origin = x_origins[x];
                    fr_x = fr_xs[x];

                    cx = fr_x + 1;
                    if (cx >= _width) cx = fr_x;

                    fx = x_origin - fr_x;
                    nx = 1.0 - fx;

                    p1 = fr_y * _width + fr_x;
                    p2 = fr_y * _width + cx;
                    p3 = cy * _width + fr_x;
                    p4 = cy * _width + cx;

                    // Red
                    bp1 = nx * _red[p1] + fx * _red[p2];
                    bp2 = nx * _red[p3] + fx * _red[p4];
                    new_red[i] = (int)(ny * bp1 + fy * bp2);

                    // Green
                    bp1 = nx * _green[p1] + fx * _green[p2];
                    bp2 = nx * _green[p3] + fx * _green[p4];
                    new_green[i] = (int)(ny * bp1 + fy * bp2);

                    // Blue
                    bp1 = nx * _blue[p1] + fx * _blue[p2];
                    bp2 = nx * _blue[p3] + fx * _blue[p4];
                    new_blue[i] = (int)(ny * bp1 + fy * bp2);

                    if (new_red[i] > 255) new_red[i] = 255;
                    if (new_green[i] > 255) new_green[i] = 255;
                    if (new_blue[i] > 255) new_blue[i] = 255;

                    if (new_red[i] < 0) new_red[i] = 0;
                    if (new_green[i] < 0) new_green[i] = 0;
                    if (new_blue[i] < 0) new_blue[i] = 0;

                    dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);
                }
            }

            var new_bmp = new Bitmap(new_width, new_height);
            var rect = new Rectangle(0, 0, new_width, new_height);
            var bits2 = new_bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            new_bmp.UnlockBits(bits2);

            _width = new_width;
            _height = new_height;

            _red = new_red;
            _green = new_green;
            _blue = new_blue;

            _original = new_bmp;

            return this;
        }

        public BitmapProcessor Resize(double scale)
        {
            int new_width = (int)(_width * scale);
            int new_height = (int)(_height * scale);

            return this.Resize(new_width, new_height);
        }

        public BitmapProcessor Resize(double x_scale, double y_scale)
        {
            int new_width = (int)(_width * x_scale);
            int new_height = (int)(_height * y_scale);

            return this.Resize(new_width, new_height);
        }

        public Bitmap ResizeClone(int new_width, int new_height)
        {
            int new_size = new_width * new_height;
            var dest = new int[new_size];
            var new_red = new int[new_size];
            var new_green = new int[new_size];
            var new_blue = new int[new_size];

            double width_factor = (double)_width / (double)new_width;
            double height_factor = (double)_height / (double)new_height;

            double x_origin, y_origin;
            double fx, fy, nx, ny;
            int cx, cy, fr_x, fr_y;
            double bp1, bp2;

            int p1, p2, p3, p4;

            var x_origins = new double[new_width];
            var fr_xs = new int[new_width];

            for (int x = 0; x < new_width; x++)
            {
                x_origin = x * width_factor;
                x_origins[x] = x_origin;
                fr_xs[x] = (int)Math.Floor(x_origin);
            }

            for (int y = 0; y < new_height; y++)
            {
                y_origin = y * height_factor;
                fr_y = (int)Math.Floor(y_origin);
                cy = fr_y + 1;
                if (cy >= _height) cy = fr_y;
                fy = y_origin - fr_y;
                ny = 1.0 - fy;

                for (int x = 0; x < new_width; x++)
                {
                    int i = y * new_width + x;

                    x_origin = x_origins[x];
                    fr_x = fr_xs[x];

                    cx = fr_x + 1;
                    if (cx >= _width) cx = fr_x;

                    fx = x_origin - fr_x;
                    nx = 1.0 - fx;

                    p1 = fr_y * _width + fr_x;
                    p2 = fr_y * _width + cx;
                    p3 = cy * _width + fr_x;
                    p4 = cy * _width + cx;

                    // Red
                    bp1 = nx * _red[p1] + fx * _red[p2];
                    bp2 = nx * _red[p3] + fx * _red[p4];
                    new_red[i] = (int)(ny * bp1 + fy * bp2);

                    // Green
                    bp1 = nx * _green[p1] + fx * _green[p2];
                    bp2 = nx * _green[p3] + fx * _green[p4];
                    new_green[i] = (int)(ny * bp1 + fy * bp2);

                    // Blue
                    bp1 = nx * _blue[p1] + fx * _blue[p2];
                    bp2 = nx * _blue[p3] + fx * _blue[p4];
                    new_blue[i] = (int)(ny * bp1 + fy * bp2);

                    if (new_red[i] > 255) new_red[i] = 255;
                    if (new_green[i] > 255) new_green[i] = 255;
                    if (new_blue[i] > 255) new_blue[i] = 255;

                    if (new_red[i] < 0) new_red[i] = 0;
                    if (new_green[i] < 0) new_green[i] = 0;
                    if (new_blue[i] < 0) new_blue[i] = 0;

                    dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);
                }
            }

            var new_bmp = new Bitmap(new_width, new_height);
            var rect = new Rectangle(0, 0, new_width, new_height);
            var bits2 = new_bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            new_bmp.UnlockBits(bits2);

            return new_bmp;
        }
        #endregion

        #region Crop
        public BitmapProcessor Crop(Rectangle rect)
        {
            SetBitmap((Bitmap)_original.Clone(rect, _original.PixelFormat));

            return this;
        }

        public BitmapProcessor Crop(int x, int y, int width, int height)
        {
            if (x < 0) x = 0;
            if (x > width) x = width;
            if (y < 0) y = 0;
            if (y > height) y = height;
            if (x + width > _width)
                width = _width - x;
            if (y + height > _height)
                height = _height - y;

            Rectangle rect = new Rectangle(x, y, width, height);

            SetBitmap((Bitmap)_original.Clone(rect, _original.PixelFormat));

            return this;
        }
        public Bitmap CropClone(int x, int y, int width, int height)
        {
            if (x < 0) x = 0;
            if (x > width) x = width;
            if (y < 0) y = 0;
            if (y > height) y = height;
            if (x + width > _width)
                width = _width - x;
            if (y + height > _height)
                height = _height - y;

            Rectangle rect = new Rectangle(x, y, width, height);

            return (Bitmap)_original.Clone(rect, _original.PixelFormat);
        }

        public BitmapProcessor DrawOutCropArea(int x, int y, int width, int height, Brush fill_brush)
        {
            using (Graphics g = Graphics.FromImage(_original))
            {
                if (fill_brush == null)
                    fill_brush = new SolidBrush(Color.White);

                Rectangle rect1 = new Rectangle(0, 0, _width, y);
                Rectangle rect2 = new Rectangle(0, y, x, height);
                Rectangle rect3 = new Rectangle(0, (y + height), _width, (_height - y - height));
                Rectangle rect4 = new Rectangle((x + width), y, (_width - x - width), height);

                g.FillRectangle(fill_brush, rect1);
                g.FillRectangle(fill_brush, rect2);
                g.FillRectangle(fill_brush, rect3);
                g.FillRectangle(fill_brush, rect4);
            }

            var rect = new Rectangle(0, 0, _width, _height);
            var source = new int[rect.Width * rect.Height];

            var bits = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(bits.Scan0, source, 0, source.Length);
            _original.UnlockBits(bits);

            _red = new int[_width * _height];
            _green = new int[_width * _height];
            _blue = new int[_width * _height];

            Parallel.For(0, source.Length, _pOptions, i =>
            {
                _red[i] = (source[i] & 0xff0000) >> 16;
                _green[i] = (source[i] & 0x00ff00) >> 8;
                _blue[i] = (source[i] & 0x0000ff);
            });

            return this;
        }

        public BitmapProcessor CropToFit(Color background, int margin = 1)
        {
            return this.Crop(this.GetFittingRectangle(background, margin));
        }

        public Rectangle GetFittingRectangle(Color background, int margin = 1)
        {
            int size = _width * _height;
            int[] row_sum = new int[_height];
            int[] col_sum = new int[_width];

            for (int i = 0; i < _height; i++) row_sum[i] = 0;
            for (int i = 0; i < _width; i++) col_sum[i] = 0;

            if (margin < 0) margin = 0;

            if (background == null)
            {
                background = this.Background;
            }

            int bg_r = background.R;
            int bg_g = background.G;
            int bg_b = background.B;

            int left = 0, top = 0, right = _width - 1, bottom = _height - 1;
            int p, inc;

            for (int i = 0, h = 0; i < size; i += _width, h++)
            {
                for (int w = 0; w < _width; w++)
                {
                    p = i + w;
                    inc = (bg_r == _red[p] && bg_g == _green[p] && bg_b == _blue[p]) ? 0 : 1;

                    col_sum[w] += inc;
                    row_sum[h] += inc;
                }
            }

            //Left
            for (int l = 0; l < _width; l++)
            {
                if (col_sum[l] != 0 && (l >= _width - 1 || col_sum[l + 1] != 0) && (l >= _width - 2 || col_sum[l + 2] != 0))
                {
                    left = l - margin;
                    if (left < 0) left = 0;
                    break;
                }
            }

            //Right
            for (int r = _width - 1; r >= 0; r--)
            {
                if (col_sum[r] != 0 && (r < 1 || col_sum[r - 1] != 0) && (r < 2 || col_sum[r - 2] != 0))
                {

                    right = r + margin;
                    if (right >= _width) right = _width - 1;
                    break;
                }
            }

            //Top
            for (int t = 0; t < _height; t++)
            {
                if (row_sum[t] != 0 && (t >= _height - 1 || row_sum[t + 1] != 0) && (t >= _height - 2 || row_sum[t + 2] != 0))
                {
                    top = t - margin;
                    if (top < 0) top = 0;
                    break;
                }
            }

            //Bottom
            for (int b = _height - 1; b >= 0; b--)
            {
                if (row_sum[b] != 0 && (b < 1 || row_sum[b - 1] != 0) && (b < 2 || row_sum[b - 2] != 0))
                {
                    bottom = b + margin;
                    if (bottom >= _height) bottom = _height - 1;
                    break;
                }
            }

            if (left > right)
            {
                left = right - margin;
                if (left < 0)
                {
                    left = 0;
                    right = left + margin;
                }
            }

            if (top > bottom)
            {
                top = bottom - margin;
                if (top < 0)
                {
                    top = 0;
                    bottom = top + margin;
                }
            }

            int new_width = right - left + 1;
            int new_height = bottom - top + 1;

            if (left + new_width > _width)
            {
                new_width = _width - left;
            }
            if (top + new_height > _height)
            {
                new_height = _height - top;
            }

            return new Rectangle(left, top, new_width, new_height);
        }

        public void GetNonBackgroundPixelCount(Color background, out int non_bg_pixels, out int total_pixels)
        {
            non_bg_pixels = 0;
            total_pixels = 0;

            if (background == null)
            {
                background = this.Background;
            }

            int size = _width * _height;

            int bg_r = background.R;
            int bg_g = background.G;
            int bg_b = background.B;

            int p = 0;

            for (int rs = 0; rs < size; rs += _width)
            {
                for (int w = 0; w < _width; w++)
                {
                    p = rs + w;
                    non_bg_pixels += (bg_r == _red[p] && bg_g == _green[p] && bg_b == _blue[p]) ? 0 : 1;
                }
            }

            total_pixels = size;
        }

        public double GetNonBackgroundPixelPercentage(Color background)
        {
            int total = 0, non_bg = 0;
            this.GetNonBackgroundPixelCount(background, out non_bg, out total);
            return total > 0 ? (double)non_bg / (double)total : 0.0;
        }

        #endregion

        public BitmapProcessor ApplyGaussianBlur(int radius)
        {
            var new_red = new int[_width * _height];
            var new_green = new int[_width * _height];
            var new_blue = new int[_width * _height];
            var dest = new int[_width * _height];

            Parallel.Invoke(
                () => gaussBlur_4(_red, new_red, radius),
                () => gaussBlur_4(_green, new_green, radius),
                () => gaussBlur_4(_blue, new_blue, radius));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (new_red[i] > 255) new_red[i] = 255;
                if (new_green[i] > 255) new_green[i] = 255;
                if (new_blue[i] > 255) new_blue[i] = 255;

                if (new_red[i] < 0) new_red[i] = 0;
                if (new_green[i] < 0) new_green[i] = 0;
                if (new_blue[i] < 0) new_blue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(new_red[i] << 16) | (uint)(new_green[i] << 8) | (uint)new_blue[i]);

                _red[i] = new_red[i];
                _green[i] = new_green[i];
                _blue[i] = new_blue[i];
            });

            var rect = new Rectangle(0, 0, _width, _height);
            var bits2 = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            _original.UnlockBits(bits2);

            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Bitmap GaussianBlur(int radius)
        {
            var newRed = new int[_width * _height];
            var newGreen = new int[_width * _height];
            var newBlue = new int[_width * _height];
            var dest = new int[_width * _height];

            Parallel.Invoke(
                () => gaussBlur_4(_red, newRed, radius),
                () => gaussBlur_4(_green, newGreen, radius),
                () => gaussBlur_4(_blue, newBlue, radius));

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (newRed[i] > 255) newRed[i] = 255;
                if (newGreen[i] > 255) newGreen[i] = 255;
                if (newBlue[i] > 255) newBlue[i] = 255;

                if (newRed[i] < 0) newRed[i] = 0;
                if (newGreen[i] < 0) newGreen[i] = 0;
                if (newBlue[i] < 0) newBlue[i] = 0;

                dest[i] = (int)(0xff000000u | (uint)(newRed[i] << 16) | (uint)(newGreen[i] << 8) | (uint)newBlue[i]);
            });

            var image = new Bitmap(_width, _height);
            var rct = new Rectangle(0, 0, image.Width, image.Height);
            var bits2 = image.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            image.UnlockBits(bits2);

            return image;
        }

        #region Helpers
        private void PopulateColorArrays()
        {
            var rect = new Rectangle(0, 0, _width, _height);
            var size = _width * _height;
            var source = new int[size];

            _red = new int[size];
            _green = new int[size];
            _blue = new int[size];

            var bits = _original.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(bits.Scan0, source, 0, source.Length);
            _original.UnlockBits(bits);

            Parallel.For(0, source.Length, _pOptions, i =>
            {
                _red[i] = (source[i] & 0xff0000) >> 16;
                _green[i] = (source[i] & 0x00ff00) >> 8;
                _blue[i] = (source[i] & 0x0000ff);
            });
        }

        private void AdjustBrightness(int[] source, int[] dest, int adj)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = source[i] + adj;
        }

        private void AdjustContrast(int[] source, int[] dest, double factor)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = (int)(factor * (source[i] - 128) + 128);
        }

        private void AdjustGamma(int[] source, int[] dest, double adj)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = (int)(Math.Pow((source[i] / 255.0), adj) * 255.0);
        }

        private void AdjustTint(int[] source, int[] dest, int target, double alpha)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = (int)((target - source[i]) * alpha + source[i]);
        }

        private void Invert(int[] source, int[] dest)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = 255 - source[i];
        }

        private void ArrayFlipHorizontal(int[] source, int[] dest)
        {
            for (int i = 0; i < source.Length; i += _width)
            {
                for (int j = 0, k = _width - 1; j < _width; ++j, --k)
                {
                    dest[i + j] = source[i + k];
                }
            }
        }

        private void ArrayFlipVertical(int[] source, int[] dest)
        {
            for (int i = 0, j = source.Length - _width; i < source.Length; i += _width, j -= _width)
            {
                for (int k = 0; k < _width; ++k)
                {
                    dest[i + k] = source[j + k];
                }
            }
        }
        #endregion

        #region Math helpers
        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public double Cos(double degrees)
        {
            return Math.Cos(DegreesToRadians(degrees));
        }

        public double Sin(double degrees)
        {
            return Math.Sin(DegreesToRadians(degrees));
        }
        #endregion


        #region Gaussian blur helpers
        private void gaussBlur_4(int[] source, int[] dest, int r)
        {
            var bxs = boxesForGauss(r, 3);
            boxBlur_4(source, dest, _width, _height, (bxs[0] - 1) / 2);
            boxBlur_4(dest, source, _width, _height, (bxs[1] - 1) / 2);
            boxBlur_4(source, dest, _width, _height, (bxs[2] - 1) / 2);
        }

        private int[] boxesForGauss(int sigma, int n)
        {
            var wIdeal = Math.Sqrt((12 * sigma * sigma / n) + 1);
            var wl = (int)Math.Floor(wIdeal);
            if (wl % 2 == 0) wl--;
            var wu = wl + 2;

            var mIdeal = (double)(12 * sigma * sigma - n * wl * wl - 4 * n * wl - 3 * n) / (-4 * wl - 4);
            var m = Math.Round(mIdeal);

            var sizes = new List<int>();
            for (var i = 0; i < n; i++) sizes.Add(i < m ? wl : wu);
            return sizes.ToArray();
        }

        private void boxBlur_4(int[] source, int[] dest, int w, int h, int r)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = source[i];
            boxBlurH_4(dest, source, w, h, r);
            boxBlurT_4(source, dest, w, h, r);
        }

        private void boxBlurH_4(int[] source, int[] dest, int w, int h, int r)
        {
            var iar = (double)1 / (r + r + 1);

            Parallel.For(0, h, _pOptions, i =>
            {
                var ti = i * w;
                var li = ti;
                var ri = ti + r;
                var fv = source[ti];
                var lv = source[ti + w - 1];
                var val = (r + 1) * fv;

                for (var j = 0; j < r; j++) val += source[ti + j];

                for (var j = 0; j <= r; j++)
                {
                    val += source[ri++] - fv;
                    dest[ti++] = (int)Math.Round(val * iar);
                }

                for (var j = r + 1; j < w - r; j++)
                {
                    val += source[ri++] - dest[li++];
                    dest[ti++] = (int)Math.Round(val * iar);
                }

                for (var j = w - r; j < w; j++)
                {
                    val += lv - source[li++];
                    dest[ti++] = (int)Math.Round(val * iar);
                }
            });
        }

        private void boxBlurT_4(int[] source, int[] dest, int w, int h, int r)
        {
            var iar = (double)1 / (r + r + 1);
            Parallel.For(0, w, _pOptions, i =>
            {
                var ti = i;
                var li = ti;
                var ri = ti + r * w;
                var fv = source[ti];
                var lv = source[ti + w * (h - 1)];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++) val += source[ti + j * w];
                for (var j = 0; j <= r; j++)
                {
                    val += source[ri] - fv;
                    dest[ti] = (int)Math.Round(val * iar);
                    ri += w;
                    ti += w;
                }
                for (var j = r + 1; j < h - r; j++)
                {
                    val += source[ri] - source[li];
                    dest[ti] = (int)Math.Round(val * iar);
                    li += w;
                    ri += w;
                    ti += w;
                }
                for (var j = h - r; j < h; j++)
                {
                    val += lv - source[li];
                    dest[ti] = (int)Math.Round(val * iar);
                    li += w;
                    ti += w;
                }
            });
        }
        #endregion
    }
}
