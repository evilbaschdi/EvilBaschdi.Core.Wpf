using System.Windows.Media;
using MahApps.Metro.IconPacks;

namespace EvilBaschdi.CoreExtended.Converter
{
    /// <summary>
    /// </summary>
    public class PackIconEntypoImageSourceConverter : PackIconImageSourceConverterBase<PackIconEntypoKind>
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="foregroundBrush"></param>
        /// <param name="penThickness"></param>
        /// <returns></returns>
        protected override ImageSource CreateImageSource(object value, Brush foregroundBrush, double penThickness)
        {
            var packIcon = new PackIconEntypo
                           {
                               Kind = (PackIconEntypoKind) value
                           };

            var geometryDrawing = new GeometryDrawing
                                  {
                                      Geometry = Geometry.Parse(packIcon.Data),
                                      Brush = foregroundBrush,
                                      Pen = new Pen(foregroundBrush, penThickness)
                                  };

            var drawingGroup = new DrawingGroup
                               {
                                   Children =
                                   {
                                       geometryDrawing
                                   },
                                   Transform = new ScaleTransform(1, -1)
                               };

            return new DrawingImage
                   {
                       Drawing = drawingGroup
                   };
        }
    }
}