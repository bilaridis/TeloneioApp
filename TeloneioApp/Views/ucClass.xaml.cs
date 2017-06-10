using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using DomainModel.XmlModels.ID15A;

namespace TeloneioApp.Views
{
    /// <summary>
    ///     Interaction logic for ItemForId15A.xaml
    /// </summary>
    public partial class ucClass : UserControl
    {

        public ucClass()
        {
            InitializeComponent();
        }

        public ObservableCollection<GOOITEGDS> WorkItems
        {
            get { return (ObservableCollection<GOOITEGDS>)GetValue(WorkItemsProperty); }
            set { SetValue(WorkItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WorkItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WorkItemsProperty =
            DependencyProperty.Register("WorkItems", typeof(ObservableCollection<GOOITEGDS>), typeof(ucClass), new FrameworkPropertyMetadata(null, OnWorkItemsChanged));

        private static void OnWorkItemsChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ucClass me = sender as ucClass;
            if (me != null)
            {
                var old = e.OldValue as ObservableCollection<GOOITEGDS>;

                if (old != null)
                {

                    old.CollectionChanged -= me.OnWorkCollectionChanged;
                }

                var n = e.NewValue as ObservableCollection<GOOITEGDS>;
                me.WorkItems = n;

                if (n != null)
                {
                    n.CollectionChanged += me.OnWorkCollectionChanged;
                }
            }
        }

        private void OnWorkCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                // Clear and update entire collection
            }

            if (e.NewItems != null)
            {
                foreach (GOOITEGDS item in e.NewItems)
                {
                    // Subscribe for changes on item
                    item.PropertyChanged += OnWorkItemChanged;

                    // Add item to internal collection
                }
            }

            if (e.OldItems != null)
            {
                foreach (GOOITEGDS item in e.OldItems)
                {
                    // Unsubscribe for changes on item
                    item.PropertyChanged -= OnWorkItemChanged;

                    // Remove item from internal collection
                }
            }
        }

        private void OnWorkItemChanged(object sender, PropertyChangedEventArgs e)
        {
            // Modify existing item in internal collection
        }
    }
}