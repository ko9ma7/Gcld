// -----------------------------------------------------------------------
//  <copyright file="BooleanToNoConverter.cs" company="柳柳软件">
//      Copyright (c) 2014 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014-11-14 20:09</last-date>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;


namespace Liuliu.MouseClicker.Converters
{
    /// <summary>
    /// 将列表行转换为Role
    /// </summary>
    public sealed class ListViewItemToRoleConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        /// <summary>
        /// 转换值。
        /// </summary>
        /// <returns>
        /// 转换后的值。如果该方法返回 null，则使用有效的 null 值。
        /// </returns>
        /// <param name="value">绑定源生成的值。</param>
        /// <param name="targetType">绑定目标属性的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Role role = null;
            if (value is ContentPresenter)
            {
                role = (Role)(value as ContentPresenter).Content;
                return role;
            }
            return null;
        }

        /// <summary>
        /// 转换值。
        /// </summary>
        /// <returns>
        /// 转换后的值。如果该方法返回 null，则使用有效的 null 值。
        /// </returns>
        /// <param name="value">绑定目标生成的值。</param>
        /// <param name="targetType">要转换到的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Role)
            {
                return value;
            }
            return null;
        }

        #endregion
    }
}