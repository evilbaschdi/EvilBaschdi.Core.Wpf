using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using MahApps.Metro.IconPacks;

namespace EvilBaschdi.CoreExtended.Converter
{
    /// <inheritdoc cref="IValueConverter" />
    /// <inheritdoc cref="MarkupExtension" />
    /// <summary>
    ///     Converts a PackIcon to an ImageSource.
    ///     Use the ConverterParameter to pass a Brush.
    /// </summary>
    public abstract class PackIconImageSourceConverterBase<TKind> : MarkupExtension, IValueConverter
        where TKind : Enum

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

            return new DrawingImage
                   {
                       Drawing = new DrawingGroup
                                 {
                                     Children =
                                     {
                                         new GeometryDrawing
                                         {
                                             Geometry = Geometry.Parse(new PackIconControl
                                                                       {
                                                                           Kind = (TKind) value
                                                                       }.Data),
                                             Brush = foregroundBrush,
                                             Pen = new Pen(foregroundBrush, Thickness)
                                         }
                                     },
                                     Transform = new ScaleTransform(1, -1)
                                 }
                   };
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
    }
}