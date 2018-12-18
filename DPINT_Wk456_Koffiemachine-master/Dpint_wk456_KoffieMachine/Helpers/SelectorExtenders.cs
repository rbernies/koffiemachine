using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dpint_wk456_KoffieMachine.Helpers
{
    /// <summary>
    /// Needed for auto scroll in the log window.
    /// Doesn't need to change.
    /// </summary>
    public class SelectorExtenders : DependencyObject
    {
        public static bool GetIsAutoscroll(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAutoscrollProperty);
        }

        public static void SetIsAutoscroll(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAutoscrollProperty, value);
        }

        public static readonly DependencyProperty IsAutoscrollProperty =
            DependencyProperty.RegisterAttached("IsAutoscroll", typeof(bool), typeof(SelectorExtenders), new UIPropertyMetadata(default(bool), OnIsAutoscrollChanged));

        public static void OnIsAutoscrollChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var val = (bool)e.NewValue;
            var lb = s as ListBox;
            var data = lb.Items.SourceCollection as INotifyCollectionChanged;

            var autoscroller = new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
                (s1, e1) =>
                {
                    if (lb.Items.Count > 0)
                    {
                        lb.UpdateLayout();
                        lb.ScrollIntoView(lb.Items[lb.Items.Count - 1]);
                        lb.UpdateLayout();
                    }
                });

            if (val) data.CollectionChanged += autoscroller;
            else data.CollectionChanged -= autoscroller;

        }
    }
}
