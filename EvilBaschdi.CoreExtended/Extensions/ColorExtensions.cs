using System;
using System.Windows.Media;
using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.Extensions
{
    /// <summary>
    ///     HelperClass to extend Color functionality.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        ///     Subtracts integers from byte.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="integer"></param>
        /// <returns></returns>
        public static byte Subtract(this byte value, int integer)
        {
            var result = Convert.ToInt32(value) - integer;
            return result < 0 ? (byte) 0 : Convert.ToByte(result);
        }

        /// <summary>
        ///     Adds integer to byte.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="integer"></param>
        /// <returns></returns>
        public static byte Add(this byte value, int integer)
        {
            return Convert.ToByte(Convert.ToInt32(value) + integer);
        }

        /// <summary>
        ///     Converts hex to Color.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static Color ToColor(this string hex)
        {
            var value = hex.PadLeft(8, 'F').PadLeft(9, '#');
            var convertFromString = ColorConverter.ConvertFromString(value);
            if (convertFromString != null)
            {
                return (Color) convertFromString;
            }

            return Colors.Black;
        }
    }

    /// <summary>
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        ///     obj:null => true
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [ContractAnnotation("obj:null => true")]
        public static bool IsNull(this object obj)
        {
            return obj is null;
        }

        /// <summary>
        ///     obj:null => false
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [ContractAnnotation("obj:null => false")]
        public static bool IsNotNull(this object obj)
        {
            return obj is null == false;
        }
    }
}