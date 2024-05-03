using System.ComponentModel.Composition;
using PluginContract;

namespace Mef1Plugin;

//[Export(typeof(IPlugin))]     // コントラクト名なし（拘りがなければコレでよい）
[Export("Mef1Plugin.IPlugin", typeof(IPlugin))]   // コントラクト名があればPluginが複数ある場合に読み分けできる
public class MyPlugin : IPlugin
{
    public int GetInt1()
    {
        return 1;
    }
}
