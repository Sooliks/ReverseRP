

using GTANetworkAPI;

namespace ServerSide.Services.MapService;

public class MarkerModel
{
    public string TextLabel { get; set; }
    public Vector3 Position { get; set; }
    public int IconBlip { get; set; }
    public byte ColorBlip { get; set; }
    public string? NameCefPath { get; set; }
    public bool? IsForWalking { get; set; }

    public MarkerModel()
    {
        
    }
    public MarkerModel(string textLabel, Vector3 position, int iconBlip, byte colorBlip, string nameCefPath, bool isForWalking)
    {
        TextLabel = textLabel;
        Position = position;
        IconBlip = iconBlip;
        ColorBlip = colorBlip;
        NameCefPath = nameCefPath;
        IsForWalking = isForWalking;
    }
}