namespace TestMAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();

        BindingContext = _viewModel = new MainViewModel();

        _viewModel.InitializeProducts();

        //Task.Run(async () =>
        //{
        //    await _viewModel.InitializeProducts();
        //});
    }

    MainViewModel _viewModel;
}
