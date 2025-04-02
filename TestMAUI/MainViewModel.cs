namespace TestMAUI;

public class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        //Task.Run(InitializeProducts);
        //Task.Run(async () =>
        //{
        //    await InitializeProducts();
        //});
    }

    public event Action<ObservableCollection<ProductResponse>>? ProductsUpdated;

    public ObservableCollection<ProductResponse> Products { get; set; } = new();

    public void InitializeProducts()
    {
        //await Task.Delay(500);

        //var products = new List<ProductResponse>();
        for (int i = 1; i < 1000; i++)
        {
            if (i % 2 == 0)
            {
                Products.Add(new ProductResponse
                {
                    ProductId = i,
                    Name = "Name" + i,
                    Price = i + 200,
                    ImageUrl = $"https://picsum.photos/id/{i}/200/300",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting i standard dummy text alley of type and scrambled it to make a type specimen ",
                    PublishedDate = DateTime.Now,
                    HasUnreadMessages = false,
                    UnreadMessagesCount = 0
                });
            }
            else if (i % 3 == 0)
            {
                Products.Add(new ProductResponse
                {
                    ProductId = i,
                    Name = "Name" + i,
                    Price = i + 200,
                    ImageUrl = $"https://picsum.photos/id/{i}/200/300",
                    PublishedDate = DateTime.Now,
                    Description = "What is Lorem Ipsum?\r\nLorem Ipsum is simply dummy text of the prem Ipsum has been th",
                    HasUnreadMessages = false,
                    UnreadMessagesCount = 0
                });
            }
            else
            {
                Products.Add(new ProductResponse
                {
                    ProductId = i,
                    Name = "Name" + i,
                    Price = i + 200,
                    PublishedDate = DateTime.Now,
                    ImageUrl = $"https://picsum.photos/id/{i}/200/300",
                    Description = "What is Lorem Ipsum?\r\nLorem Ipsum is simplythe printing and typesetting industry. Lorem Ipsum has been th",
                    HasUnreadMessages = true,
                    UnreadMessagesCount = i
                });
            }
        }


        //for (int i = 0; i < products.Count; i++)
        //{
        //    Products.Add(products[i]);
        //}

        //Products = new ObservableCollection<ProductResponse>(products);

    }
}
