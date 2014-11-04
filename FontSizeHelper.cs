using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VoIP
{
    public static class FontSizeHelper
    {
        public static void Initialize(FrameworkElement[] controlsToResize)
        {
            foreach (var element in controlsToResize)
            {
                var scopeElement = element;
                scopeElement.SizeChanged += (sender, args) => RecalcFontSize(scopeElement);
                RecalcFontSize(scopeElement);
            }
        }

        private static void SetFontSizeRelative(FrameworkElement element, double value)
        {
            var controlElement = element as Control;
            if (controlElement != null)
            {
                if (controlElement.FontSize + value > 0)
                {
                    controlElement.FontSize += value;
                }
            }
            else
            {
                var textBlockElement = element as TextBlock;
                if (textBlockElement != null)
                {
                    if (textBlockElement.FontSize + value > 0)
                    {
                        textBlockElement.FontSize += value;
                    }
                }
            }
        }

        private static void RecalcFontSize(FrameworkElement element)
        {
            if (element == null) return;
            var constraint = new Size(element.ActualWidth, element.ActualHeight);
            element.Measure(constraint);

            while (element.DesiredSize.Height > element.ActualHeight || element.DesiredSize.Width > element.ActualWidth)
            {
                SetFontSizeRelative(element, -1);
                element.Measure(constraint);
            }

            while (element.DesiredSize.Height < element.ActualHeight && element.DesiredSize.Width < element.ActualWidth)
            {
                SetFontSizeRelative(element, 1);
                element.Measure(constraint);
            }
            SetFontSizeRelative(element, -1);
        }
    }
}
