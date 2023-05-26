using NextLevel.ViewModel;

namespace NextLevel.Views;

public partial class ChannelsPage : ContentPage
{
	public ChannelsPage(ChannelsViewModel VM)
	{
		InitializeComponent();
		ViewModel = VM;
	}

	public ChannelsViewModel ViewModel
	{
		get { return BindingContext as ChannelsViewModel; }
		set { BindingContext = value; }
	}

	private void CollectionView_ReorderCompleted(object sender, EventArgs e)
	{

    }
}