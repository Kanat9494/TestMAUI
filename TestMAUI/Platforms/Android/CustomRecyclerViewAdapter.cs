using AndroidViews = Android.Views;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace TestMAUI.Platforms.Android;

public class CustomRecyclerViewAdapter : RecyclerView.Adapter
{
    public CustomRecyclerViewAdapter(List<ProductResponse> products)
    {
        _products = products;
    }

    private List<ProductResponse> _products;
    public override int ItemCount => _products.Count;

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        if (holder is CustomViewHolder viewHolder)
        {
            viewHolder.TextView.Text = _products[position].Name;
        }
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        // Inflate the item view
        AndroidViews.View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Drawable.recycler_view_item, parent, false);
        return new CustomViewHolder(itemView);
    }
}

public class CustomViewHolder : RecyclerView.ViewHolder
{
    public TextView TextView { get; }

    public CustomViewHolder(AndroidViews.View itemView) : base(itemView)
    {
        TextView = itemView.FindViewById<TextView>(Resource.Id.title);
    }
}
