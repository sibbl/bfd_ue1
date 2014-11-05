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
                scopeElement.SizeChanged += (sender, args) => RecalcFontSize(scopeElement, args);
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

        private static void RecalcFontSize(FrameworkElement element, SizeChangedEventArgs args = null)
        {
            if (element == null) return;
            var constraint = new Size(element.ActualWidth, element.ActualHeight);
            element.Measure(constraint);

             
            if (args == null || !(element is Button))
            {
                while (element.DesiredSize.Height < element.ActualHeight &&
                       element.DesiredSize.Width < element.ActualWidth)
                {
                    SetFontSizeRelative(element, 1);
                    element.Measure(constraint);
                }
            }
            else
            {
                if (args.NewSize.Width < args.PreviousSize.Width || args.NewSize.Height < args.PreviousSize.Height)
                {
                    while (element.DesiredSize.Height >= element.ActualHeight ||
                           element.DesiredSize.Width >= element.ActualWidth)
                    {
                        SetFontSizeRelative(element, -1);
                        element.Measure(constraint);
                    }
                }
                while (element.DesiredSize.Height < element.ActualHeight &&
                       element.DesiredSize.Width < element.ActualWidth)
                {
                    SetFontSizeRelative(element, 1);
                    element.Measure(constraint);
                }
            }

            SetFontSizeRelative(element, -1);
        }
    }
}
