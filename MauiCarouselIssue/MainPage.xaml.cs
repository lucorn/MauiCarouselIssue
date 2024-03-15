namespace MauiCarouselIssue;

public class AllUpVM
{
  public required string Content { get; set; }

  public Board Board { get; set; }

  public AllUpVM()
  {
    Board = new Board();
  }
}

public class PartPage
{
  public required string Name { get; set; }

  public required AllUpVM ViewModel { get; set; }
}

public partial class MainPage : ContentPage
{
  public List<PartPage> Parts { get; set; }

  public MainPage()
  {
    InitializeComponent();
    AllUpVM vm = new() { Content = "Common content" };

    Parts = [new PartPage { Name = "First", ViewModel = vm }, new PartPage { Name = "Second", ViewModel = vm }];

    BindingContext = this;
  }
}

public class Board : GraphicsView
{
}


public class SelectionDataTemplateSelector : DataTemplateSelector
{
  public required DataTemplate FirstPartPage { get; set; }
  public required DataTemplate SecondPartPage { get; set; }

  protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
  {
    return ((PartPage)item).Name == "First" ? FirstPartPage : SecondPartPage;
  }
}