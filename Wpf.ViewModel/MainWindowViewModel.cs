using System.Reactive.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;

namespace Wpf.ViewModel;

public sealed partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    int _counter;

    [RelayCommand]
    void CountUp() => Counter++;

    public IReadOnlyReactiveProperty<long> TimeCounter { get; }

    public MainWindowViewModel()
    {
        TimeCounter = Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(500))
            .ToReadOnlyReactivePropertySlim();
    }
}
