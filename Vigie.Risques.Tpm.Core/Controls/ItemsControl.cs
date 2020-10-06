using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.Controls
{
    public class ItemsControl : StackLayout
    {
        private readonly IDictionary<object, View> _views = new Dictionary<object, View>();

        public event EventHandler<object> ItemClicked;

        /// <summary>
        /// Constructeur
        /// </summary>
        public ItemsControl() : base()
        {
            if (ItemsSource != null)
            {
                SetItemsViews(ItemsSource);
            }
        }

        #region dependencyproperties

        #region ItemsSource
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource),
                                    typeof(IEnumerable),
                                    typeof(ItemsControl),
                                    default(IEnumerable),
                                    propertyChanged: ItemsSourceChanged);

        /// <summary>
        /// source d'items
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ItemsControl uc = bindable as ItemsControl;

            if (oldValue is INotifyCollectionChanged notifycollectionChanged)
            {
                notifycollectionChanged.CollectionChanged -= uc.ItemsSource_CollectionChanged;
            }

            if (oldValue != newValue)
            {
                if (uc != null)
                {
                    uc.SetItemsViews(newValue as IEnumerable);

                    if (newValue is INotifyCollectionChanged newItems)
                    {
                        newItems.CollectionChanged += uc.ItemsSource_CollectionChanged;
                    }
                }
            }
        }

        private void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SetItemsViews(ItemsSource);
        }

        #endregion

        #region ItemTemplate

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate),
                                    typeof(DataTemplate),
                                    typeof(ItemsControl),
                                    default(DataTemplate)
                                    );

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        #endregion

        #region ItemCommand

        public static readonly BindableProperty ItemCommandProperty =
                    BindableProperty.Create(nameof(ItemCommand),
                                            typeof(ICommand),
                                            typeof(ItemsControl),
                                            default(ICommand));
        /// <summary>
        /// source d'items
        /// </summary>
        public ICommand ItemCommand
        {
            get { return (ICommand)GetValue(ItemCommandProperty); }
            set { SetValue(ItemCommandProperty, value); }
        }

        #endregion

        #endregion

        #region protected

        protected bool TryCreateItemView(object item, out View view)
        {
            view = null;

            if (item != null && !_views.TryGetValue(item, out view))
            {
                view = ItemTemplate != null
                    ? ItemTemplate.CreateContent() as View
                    : null;

                if (view == null)
                {
                    return false;
                }

                //Datacontext
                view.BindingContext = item;

                view.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                    {
                        ItemCommand?.Execute(item);
                        ItemClicked?.Invoke(this, item);
                    })
                });

                ////Ajout des enfants
                //Children.Add(view);

                _views.Add(item, view);

                return true;
            }

            return false;
        }

        protected void ClearViews()
        {
            _views.Clear();
        }

        protected virtual void SetItemsViews(IEnumerable items)
        {
            Children.Clear();
            ClearViews();

            if (items != null)
            {
                foreach (object item in items)
                {
                    if (TryCreateItemView(item, out View view))
                    {
                        //Ajout des enfants
                        Children.Add(view);
                    }
                }
            }
        }

        #endregion

    }

}
