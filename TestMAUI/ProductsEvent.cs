namespace TestMAUI;

public static class ProductsEvent
{
    public static event Action<ObservableCollection<ProductResponse>> ProductsUpdated;

    public static void RaiseProductsUpdated(ObservableCollection<ProductResponse> products)
    {
        ProductsUpdated?.Invoke(products);
    }
}
