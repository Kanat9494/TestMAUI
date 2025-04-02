using AndroidViews = Android.Views;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using Android.Graphics;

namespace TestMAUI.Platforms.Android;

public class CustomRecyclerViewAdapter : RecyclerView.Adapter
{
    public CustomRecyclerViewAdapter(List<ProductResponse> products)
    {
        _products = products;
    }

    private List<ProductResponse> _products;
    public override int ItemCount => _products.Count;

    public void UpdateData(ObservableCollection<ProductResponse> newProducts)
    {
        // Преобразуем ObservableCollection в List
        //_products = new List<ProductResponse>(newProducts);
        _products.AddRange(newProducts);

        // Уведомляем адаптер, что данные изменились
        NotifyDataSetChanged();
    }

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        //if (holder is CustomViewHolder viewHolder)
        //{
        //    viewHolder.TextView.Text = _products[position].Name;
        //    //viewHolder.ImageView = _products[position].ImageUrl;

        //    LoadImageAsync(viewHolder.ImageView, _products[position].ImageUrl);
        //    viewHolder.DescriptionTextView.Text = _products[position].Description;
        //    viewHolder.PublishedTextView.Text = _products[position].PublishedDate.ToString("yyyy-MM-dd-HH-ss-mm");
        //}


        if (holder is CustomViewHolder viewHolder)
        {
            var product = _products[position];

            // Устанавливаем имя (например, название чата)
            viewHolder.TextView.Text = product.Name;

            // Устанавливаем последнее сообщение
            viewHolder.DescriptionTextView.Text = product.Description;

            // Устанавливаем дату последнего сообщения
            viewHolder.PublishedTextView.Text = product.PublishedDate.ToString("yyyy-MM-dd");

            // Загружаем изображение (аватар)
            Glide.With(viewHolder.ImageView.Context)
                 .Load(product.ImageUrl)
                 .Into(viewHolder.ImageView);
            viewHolder.Title2.Text = product.Name;

            // Устанавливаем количество непрочитанных сообщений
            if (product.UnreadMessagesCount > 0)
            {
                viewHolder.UnreadMessagesCount.Text = product.UnreadMessagesCount.ToString();
                viewHolder.UnreadMessagesCount.Visibility = ViewStates.Visible;
            }
            else
            {
                viewHolder.UnreadMessagesCount.Visibility = ViewStates.Gone;
            }
        }
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        // Inflate the item view
        AndroidViews.View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Drawable.recycler_view_item, parent, false);
        return new CustomViewHolder(itemView);
    }

    private async Task<Bitmap> GetImageBitmapFromUrlAsync(string url)
    {
        Bitmap imageBitmap = null;
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var imageBytes = await response.Content.ReadAsByteArrayAsync();
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
        }
        return imageBitmap;
    }

    private async void LoadImageAsync(ImageView imageView, string url)
    {
        Bitmap bitmap = await GetImageBitmapFromUrlAsync(url);
        imageView.SetImageBitmap(bitmap);
    }
}

public class CustomViewHolder : RecyclerView.ViewHolder
{
    public TextView TextView { get; }
    public ImageView ImageView { get; set; }
    public TextView DescriptionTextView { get; set; }
    public TextView PublishedTextView { get; set; }
    public TextView UnreadMessagesCount { get; set; }
    public TextView Title2 { get; set; }

    public CustomViewHolder(AndroidViews.View itemView) : base(itemView)
    {
        TextView = itemView.FindViewById<TextView>(Resource.Id.title);
        ImageView = itemView.FindViewById<ImageView>(Resource.Id.productImage);
        DescriptionTextView = itemView.FindViewById<TextView>(Resource.Id.productDescription);
        PublishedTextView = itemView.FindViewById<TextView>(Resource.Id.productPublishedDate);
        UnreadMessagesCount = itemView.FindViewById<TextView>(Resource.Id.unreadMessagesCount);
        Title2 = itemView.FindViewById<TextView>(Resource.Id.title2);
    }
}
