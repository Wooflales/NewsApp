using Microsoft.Maui.Controls;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomePage()
	{
		InitializeComponent();
        GetBreakingNews();
        ArticleList = new List<Article>();
        CvCategories.ItemsSource = CategoryList;
	}
	private async Task GetBreakingNews()
	{
		var apiService = new ApiService();
		var newsResult = await apiService.GetNews("Health");
		foreach (var item in newsResult.Articles)
		{
			ArticleList.Add(item);
		}
		CvNews.ItemsSource = ArticleList;
	}
    private async void categorySelected(object sender, EventArgs e)
    {
        var current = CvCategories.SelectedItem as Category;
        if (current == null) return;
        Navigation.PushAsync(new NewsListPage(current));
        ((CollectionView)sender).SelectedItem = null;
    }
}