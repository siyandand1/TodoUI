namespace LoginFlowMAUI.Pages;
using TodoServices;
using System.Collections.Generic;

public partial class ListingPage : ContentPage
{
    private readonly ITodoService _todoService;

    public ListingPage(ITodoService todoService)
	{
        _todoService = todoService;
    }
    public ListingPage()
    {
        InitializeComponent();
        _todoService = new TodoService();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Handle logic when the page disappears
    }
   
    protected override async void OnAppearing()
    {
        base.OnAppearing();
    

        var tasks = await _todoService.getTodos();
        TasksCollectionView.ItemsSource = tasks;
    }
   
}