using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CarouselViewBug;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<CellData> _items = [];

    private int counter = 0;

    public MainViewModel()
    {
        _items = [
            new() {
                CellLine1 = "abc",
                CellLine2 = "24"
            },
            new()
            {
                CellLine1 = "def",
                CellLine2 = "36"
            }
        ];
    }

    internal void ModifyItemsSource()
    {
        ObservableCollection<CellData> items = [.. Items];
        Items.RemoveAt(items.Count - 1);
//        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }

    [RelayCommand]
    private void RemoveLastItem()
    {
        Items.RemoveAt(Items.Count - 1);
    }

    [RelayCommand]
    private void AddNewItem()
    {
        Items.Add(new()
        { CellLine1 = "say",
          CellLine2 = (++counter).ToString()
        });
    }
}

public partial class CellData : ObservableObject
{
    [ObservableProperty]
    private string _cellLine1 = string.Empty;

    [ObservableProperty]
    private string _severityIconSource = "checkcircle.png";

    [ObservableProperty]
    private string _cellLine2 = string.Empty;
}