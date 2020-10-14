using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Lib.Uwp
{
    public class AdaptableGridView : GridView
    {
        public AdaptableGridView()
        {
            SizeChanged += AdaptableGridView_SizeChanged;
        }

        private void AdaptableGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var itemsPanelRoot = ItemsPanelRoot as ItemsWrapGrid;
            if (itemsPanelRoot == null)
            {
                return;
            }

            itemsPanelRoot.ItemWidth = e.NewSize.Width / itemsPanelRoot.MaximumRowsOrColumns;
            itemsPanelRoot.ItemHeight = itemsPanelRoot.ItemWidth;
        }
    }
}
