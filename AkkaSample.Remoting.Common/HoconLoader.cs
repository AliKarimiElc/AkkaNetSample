using Akka.Configuration;

namespace AkkaSample.Remoting.Common;

public static class HoconLoader
{
    public static Config FromFile(string path)
    {
        var hoconContent = File.ReadAllText(path);
        return ConfigurationFactory.ParseString(hoconContent);
    }
}