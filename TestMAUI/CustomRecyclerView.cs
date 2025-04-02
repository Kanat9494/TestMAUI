using System.Collections.Specialized;

namespace TestMAUI;

public class CustomRecyclerView : View
{
    public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<ProductResponse>), typeof(CustomRecyclerView), new ObservableCollection<ProductResponse>(), propertyChanged: OnItemsChanged);

    public ObservableCollection<ProductResponse> Items
    {
        get => (ObservableCollection<ProductResponse>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    private static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        //if (bindable is CustomRecyclerView customRecyclerView)
        //{
        //    if (oldValue is ObservableCollection<ProductResponse> oldCollection)
        //    {
        //        oldCollection.CollectionChanged -= customRecyclerView.OnCollectionChanged;
        //    }

        //    if (newValue is ObservableCollection<ProductResponse> newCollection)
        //    {
        //        newCollection.CollectionChanged += customRecyclerView.OnCollectionChanged;
        //    }

        //    // Обновляем UI при смене всей коллекции
        //    customRecyclerView.Handler?.UpdateValue(nameof(Items));
        //}
    }

    private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        // Обновляем платформенный элемент при изменении списка
        Handler?.UpdateValue(nameof(Items));
    }
}
