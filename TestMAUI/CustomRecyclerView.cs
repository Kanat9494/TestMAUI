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
    }
}
