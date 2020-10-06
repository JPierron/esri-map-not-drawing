using System;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Core.Controls
{
    /// <summary>
    /// Items control affichant un tabeau d'un certain nombre de colonnes
    /// toutes les colonnes seront de taille égale
    /// </summary>
    public class TableItemsControl : ItemsSelectableControl
    {
        #region Dependency Properties

        #region Number of colums

        public static BindableProperty NumberOfColumnsProperty = BindableProperty.Create(
          nameof(NumberOfColumns),
          typeof(int),
          typeof(TableItemsControl),
          2,
          propertyChanged: NumberOfColumns_PropertyChanged);

        public int NumberOfColumns
        {
            get { return (int)GetValue(NumberOfColumnsProperty); }
            set { SetValue(NumberOfColumnsProperty, value); }
        }

        private static void NumberOfColumns_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != newValue && bindable is TableItemsControl uc)
            {
                uc.SetItemsViews(uc.ItemsSource);
            }
        }

        #endregion

        #region Max items

        public static BindableProperty MaxItemsProperty = BindableProperty.Create(
            nameof(MaxItems),
            typeof(int),
            typeof(TableItemsControl),
            6,
            propertyChanged: MaxItems_PropertyChanged);

        public int MaxItems
        {
            get { return (int)GetValue(MaxItemsProperty); }
            set { SetValue(MaxItemsProperty, value); }
        }

        private static void MaxItems_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != newValue && bindable is TableItemsControl uc)
            {
                uc.SetItemsViews(uc.ItemsSource);
            }
        }

        #endregion

        #region Items spacing

        public static BindableProperty ItemsSpacingProperty = BindableProperty.Create(
          nameof(ItemsSpacing),
          typeof(double),
          typeof(TableItemsControl),
          12.0,
          propertyChanged: ItemsSpacing_PropertyChanged);

        public double ItemsSpacing
        {
            get { return (double)GetValue(ItemsSpacingProperty); }
            set { SetValue(ItemsSpacingProperty, value); }
        }

        private static void ItemsSpacing_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue != newValue && bindable is TableItemsControl uc)
            {
                uc.SetItemsViews(uc.ItemsSource);
            }
        }

        #endregion

        #endregion

        #region protected methods

        protected override void SetItemsViews(System.Collections.IEnumerable items)
        {
            Children.Clear();
            ClearViews();

            double spacing = ItemsSpacing;

            Grid grid = new Grid
            {
                Padding = new Thickness(spacing),
                ColumnSpacing = spacing,
                RowSpacing = spacing
            };

            int row = -1;

            for (int i = 0; i < NumberOfColumns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            Children.Add(grid);

            if (items != null)
            {
                int i = 0;

                foreach (object item in items)
                {
                    if (MaxItems <= 0 || i < MaxItems)
                    {
                        if (TryCreateItemView(item, out View view))
                        {
                            if (i % NumberOfColumns == 0)
                            {
                                row++;
                                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                            }

                            grid.Children.Add(view, i % NumberOfColumns, row);
                            i++;
                        }
                    }
                }

                Children.Add(grid);
            }
        }

        #endregion
    }
}
