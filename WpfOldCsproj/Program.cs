using System.Reflection;
using WpfOldCsproj;
using WpfOldCsproj.Views;

public class Program
{
    [STAThread]
    public static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;

        App app = new();
        app.InitializeComponent();
        app.Run(new MainWindow());
    }

    private static Assembly? OnResolveAssembly(object sender, ResolveEventArgs args)
    {
        var assemblyName = new AssemblyName(args.Name);
        string path = assemblyName.Name + ".dll";
        if (!assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture))
        {
            path = $"{assemblyName.CultureInfo}\\" + path;
        }

        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
        {
            if (stream is null)
                return null;

            stream.Position = 0;
            var assemblyRawBytes = new byte[stream.Length];
            stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
            return Assembly.Load(assemblyRawBytes);
        }
    }
}
