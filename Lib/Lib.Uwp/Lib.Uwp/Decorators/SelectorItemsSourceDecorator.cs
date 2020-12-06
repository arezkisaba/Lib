using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace Lib.Uwp
{
    public static class SelectorItemsSourceDecorator
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.RegisterAttached(
            "ItemsSource", typeof(IEnumerable), typeof(SelectorItemsSourceDecorator), new PropertyMetadata(null, ItemsSourcePropertyChanged)
        );

        public static void SetItemsSource(UIElement element, IEnumerable value)
        {
            element.SetValue(ItemsSourceProperty, value);
        }

        public static IEnumerable GetItemsSource(UIElement element)
        {
            return (IEnumerable)element.GetValue(ItemsSourceProperty);
        }

        static void ItemsSourcePropertyChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var target = element as Selector;
            if (target == null)
            {
                return;
            }

            var originalBinding = target.GetBindingExpression(Selector.SelectedItemProperty);
            target.ClearValue(Selector.SelectedItemProperty);

            try
            {
                target.ItemsSource = e.NewValue as IEnumerable;
            }
            finally
            {
                if (originalBinding != null)
                {
                    target.SetBinding(Selector.SelectedItemProperty, originalBinding.ParentBinding);
                }
            }
        }
    }
}
