using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailsPage : ContentPage
{
	public NewsDetailsPage(Article article)
	{
		InitializeComponent();
		articleName.Text = article.Title;
		articleImage.Source = article.Image;
		articleContent.Text = article.Content;
	}
}