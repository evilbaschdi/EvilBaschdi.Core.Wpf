﻿using System.Windows;
using System.Windows.Controls;

namespace EvilBaschdi.Core.Wpf.Extensions;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
public static class RemoveChildExtension
{
    /// <summary>
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    // ReSharper disable once UnusedMember.Global
    public static void RemoveChild(this DependencyObject parent, UIElement child)
    {
        switch (parent)
        {
            case Panel panel:
                panel.Children.Remove(child);
                return;
            case Decorator decorator:
                if (Equals(decorator.Child, child))
                {
                    decorator.Child = null;
                }

                return;
            case ContentPresenter contentPresenter:
                if (Equals(contentPresenter.Content, child))
                {
                    contentPresenter.Content = null;
                }

                return;
            case ContentControl contentControl:
                if (Equals(contentControl.Content, child))
                {
                    contentControl.Content = null;
                }

                break;
        }

        // maybe more
    }
}