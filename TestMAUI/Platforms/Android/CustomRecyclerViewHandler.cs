using Android.Content;
using AndroidX.RecyclerView.Widget;
using Microsoft.Maui.Handlers;

namespace TestMAUI.Platforms.Android;

public class CustomRecyclerViewHandler : ViewHandler<CustomRecyclerView, RecyclerView>
{

    public static PropertyMapper<CustomRecyclerView, CustomRecyclerViewHandler> CustomEntryMapper = new PropertyMapper<CustomRecyclerView, CustomRecyclerViewHandler>(ViewHandler.ViewMapper)
    {
        [nameof(CustomRecyclerView.Items)] = MapItems,
    };

    public CustomRecyclerViewHandler() : base(CustomEntryMapper)
    {

    }

    protected override RecyclerView CreatePlatformView()
    {
        Context context = MauiApplication.Current.ApplicationContext;
        var recyclerView = new RecyclerView(context);
        recyclerView.SetLayoutManager(new LinearLayoutManager(context));

        if (VirtualView.Items != null)
        {
            recyclerView.SetAdapter(new CustomRecyclerViewAdapter(new List<ProductResponse>(VirtualView.Items)));
        }

        return recyclerView;
    }

    protected override void ConnectHandler(RecyclerView platformView)
    {
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(RecyclerView platformView)
    {
        base.DisconnectHandler(platformView);

    }


    public static void MapItems(CustomRecyclerViewHandler handler, CustomRecyclerView customRecyclerView)
    {
        if (customRecyclerView.Items != null && handler.PlatformView != null)
        {
            handler.PlatformView.SetAdapter(new CustomRecyclerViewAdapter(new List<ProductResponse>(customRecyclerView.Items)));
        }
    }
}
