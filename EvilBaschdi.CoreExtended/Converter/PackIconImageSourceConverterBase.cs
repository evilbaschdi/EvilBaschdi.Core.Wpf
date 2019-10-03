using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace EvilBaschdi.CoreExtended.Converter
{
    /// <inheritdoc cref="IValueConverter" />
    /// <inheritdoc cref="MarkupExtension" />
    /// <summary>
    ///     Converts a PackIcon to an ImageSource.
    ///     Use the ConverterParameter to pass a Brush.
    /// </summary>
    public abstract class PackIconImageSourceConverterBase<TKind> : MarkupExtension, IValueConverter
    {
        /// <summary>
        ///     Gets or sets the thickness to draw the icon with.
        /// </summary>
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        private double Thickness { get; set; } = 0.25;

        /// <inheritdoc />
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TKind))
            {
                return null;
            }

            var foregroundBrush = parameter as Brush ?? Brushes.Black;
            return CreateImageSource(value, foregroundBrush, Thickness);
        }

        /// <inheritdoc />
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        /// <param name="value"></param>
        /// <param name="foregroundBrush"></param>
        /// <param name="penThickness"></param>
        /// <returns></returns>
        protected abstract ImageSource CreateImageSource(object value, Brush foregroundBrush, double penThickness);

        /// <summary>
        /// </summary>
        /// <param name="foregroundBrush"></param>
        /// <param name="penThickness"></param>
        /// <param name="packIconData"></param>
        /// <returns></returns>
        protected ImageSource InnerCreateImageSource(Brush foregroundBrush, double penThickness, string packIconData)
        {
            var geometryDrawing = new GeometryDrawing
                                  {
                                      Geometry = Geometry.Parse(packIconData),
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