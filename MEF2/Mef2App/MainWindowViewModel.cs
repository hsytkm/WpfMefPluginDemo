using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PluginContract;

namespace Mef2App;

partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsLoadedPlugin))]
    [NotifyCanExecuteChangedFor(nameof(InvokePluginCommand))]
    private IPlugin? _plugin;

    [ObservableProperty]
    private int _value;

    public bool IsLoadedPlugin => Plugin is not null;

    [RelayCommand]
    void LoadPlugin()
    {
        if (Plugin is not null)
            return;

        Stopwatch sw = Stopwatch.StartNew();

        try
        {
            var host = PluginHost.Create();
            Plugin = host?.Addins?[0];
            ;
            //Plugin = host;
        }
        catch (System.IO.DirectoryNotFoundException ex)
        {
            Debug.WriteLine(ex);
        }

        Debug.WriteLine($"Stopwatch: {sw.ElapsedMilliseconds} msec");
    }

    [RelayCommand(CanExecute = nameof(CanInvokePlugin))]
    void InvokePlugin()
    {
        if (Plugin is { } plugin)
            Value += plugin.GetInt1();
    }
    bool CanInvokePlugin() => IsLoadedPlugin;
}
