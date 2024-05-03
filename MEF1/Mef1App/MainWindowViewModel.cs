using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PluginContract;

namespace Mef1App;

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
            // プラグインのディレクトリを指定してロード
            using DirectoryCatalog catalog = new("plugins");
            using CompositionContainer container = new(catalog);
            container.ComposeParts(this);

            // プラグイン側にコントラクト名を付けていない場合は引数不要(デフォルト引数のnullでよい)
            Plugin = container.GetExportedValueOrDefault<IPlugin>("Mef1Plugin.IPlugin");
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
