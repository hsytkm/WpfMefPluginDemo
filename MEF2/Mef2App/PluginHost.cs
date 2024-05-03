using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.IO;
using System.Reflection;
using PluginContract;

namespace Mef2App;

public sealed class PluginHost
{
    //[System.Composition.ImportMany]
    [System.ComponentModel.Composition.ImportMany]
    public List<IPlugin>? Addins { get; set; }

    public static PluginHost? Create()
    {
        RegistrationBuilder builder = new();

        // addins
        builder
            .ForTypesDerivedFrom<IPlugin>()
            //.Export<IAddinContract>()
            .ExportInterfaces();

        // host
        builder
            .ForType<PluginHost>()
            //.ImportProperty(x => x.Addins, b => b.AsMany())
            .Export<PluginHost>();

        using AssemblyCatalog hostCatalog = new(typeof(PluginHost).Assembly, builder);
        using AggregateCatalog aCataog = new(hostCatalog);

        foreach (var f in new DirectoryInfo("plugins").GetFiles().Where(x => x.Name.ToLower().EndsWith(".dll")))
        {
            AssemblyCatalog catalog = new(Assembly.LoadFile(f.FullName), builder);
            aCataog.Catalogs.Add(catalog);
        }

        using CompositionContainer container = new(aCataog);
        return container.GetExportedValue<PluginHost>();
    }
}
