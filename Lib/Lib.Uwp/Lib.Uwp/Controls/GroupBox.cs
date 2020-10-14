using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lib.Uwp
{
    public sealed class GroupBox : ContentControl
    {
        public GroupBox()
        {
            DefaultStyleKey = typeof(GroupBox);
        }

        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(GroupBox), new PropertyMetadata(null));
    }
}
