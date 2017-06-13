using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace TeloneioApp.ViewModels.Behaviors
{
    public static class RefreshDescriptionBehavior
    {
        public static string GetRefreshDescription(DependencyObject obj)
        {
            return (string)obj.GetValue(RefreshDescriptionProperty);
        }

        public static void SetRefreshDescription(DependencyObject obj, string value)
        {
            obj.SetValue(RefreshDescriptionProperty, value);
        }

        public static readonly DependencyProperty RefreshDescriptionProperty =
            DependencyProperty.RegisterAttached("RefreshDescription",
                typeof(string), typeof(RefreshDescriptionBehavior),
                new PropertyMetadata("", OnIsRefreshDescriptionChanged));

        private static void OnIsRefreshDescriptionChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // ignoring error checking
            var dataGrid = (DataGridTextColumn)sender;
            var datacontext = dataGrid.Binding;
            //var isDigitOnly = (bool)(e.NewValue);

            //if (isDigitOnly)
            //{
            //    dataGrid.SelectedCellsChanged += DataGrid_SelectedCellsChanged;
            //}
            //else
            //{
            //    dataGrid.SelectedCellsChanged -= DataGrid_SelectedCellsChanged;
            //}
        }
    }
}
