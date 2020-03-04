using System.Windows;

namespace TLABS.Extensions
{
    public static class WPFExtensions
    {
        public static System.Windows.Point ToWPFPoint(this System.Drawing.Point p)
        {
            return new System.Windows.Point(p.X, p.Y);
        }

        public static System.Windows.Point TransformToWPFPoint(this System.Drawing.Point p, System.Windows.Media.Visual visual)
        {
            System.Windows.Point wp = new System.Windows.Point(p.X, p.Y);

            if (visual != null)
            {
                try
                {
                    wp = PresentationSource.FromVisual(visual).CompositionTarget.TransformFromDevice.Transform(wp);
                }
                catch { }
            }

            return wp;
        }
    }
}
