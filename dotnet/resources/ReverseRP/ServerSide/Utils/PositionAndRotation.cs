using GTANetworkAPI;

namespace Utils;

public class PositionAndRotation
{
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }

    public PositionAndRotation(Vector3 position, Vector3 rotation)
    {
        Position = position;
        Rotation = rotation;
    }
}