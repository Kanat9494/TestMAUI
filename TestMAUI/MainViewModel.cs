using System.Collections.ObjectModel;

namespace TestMAUI;

public class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Task.Run(InitializeProducts);
    }

    public ObservableCollection<ProductResponse> Products { get; set; } = new();

    private void InitializeProducts()
    {
        for (int i = 1; i < 1000; i++)
        {
            if (i % 2 == 0)
            {
                Products.Add(new ProductResponse
                {
                    ProductId = i,
                    Name = "Name" + i,
                    Price = i + 200,
                    ImageUrl = $"https://picsum.photos/id/{i}/200/300"
                });
            }
            else if (i % 3 == 0)
            {
                Products.Add(new ProductResponse
                {
                    ProductId = i,
                    Name = "Name" + i,
                    Price = i + 200,
                    ImageUrl = $"https://picsum.photos/id/{i}/200/300"
                });
            }
            else
            {
                Products.Add(new ProductResponse
                {
                    ProductId = i,
                    Name = "Name" + i,
                    Price = i + 200,
                    ImageUrl = $"https://picsum.photos/id/{i}/200/300"
                });
            }
        }
    }
}
