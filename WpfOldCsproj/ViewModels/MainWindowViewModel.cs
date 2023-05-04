using System.Reactive.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;

namespace WpfOldCsproj.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    [RelayCommand]
    void CountUp() => Debug.WriteLine("旧型式のcsprojだとSourceGenが動作しない様子…");

    public IReadOnlyReactiveProperty<long> TimeCounter { get; }

    public MainWindowViewModel()
    {
        TimeCounter = Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(500))
            .ToReadOnlyReactivePropertySlim();
    }
}
