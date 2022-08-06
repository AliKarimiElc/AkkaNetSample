namespace AkkaSample.DependencyInjection.Model;

public class Song
{
    public string SongName { get; }
    public byte[] RowFormat { get; }

    public Song(string songName, byte[] rowFormat)
    {
        SongName = songName;
        RowFormat = rowFormat;
    }
}