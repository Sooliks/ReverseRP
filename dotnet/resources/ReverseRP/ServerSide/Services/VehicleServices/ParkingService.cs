using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Utils;

namespace ServerSide.Services.VehicleServices;

public class ParkingService
{
    private static readonly Dictionary<int, List<PositionAndRotation>> ParkingsAndPositions = new Dictionary<int, List<PositionAndRotation>>()
    {
        {1, new List<PositionAndRotation>()
        {
            new PositionAndRotation(new Vector3(-17.589428,-1079.642,26.228325), new Vector3(-0.010828756,0.060628563,127.8759)),
            new PositionAndRotation(new Vector3(-14.252554,-1079.9269,26.228518), new Vector3(-0.026579084,0.045217566,125.260735)),
            new PositionAndRotation(new Vector3(-11.51218,-1080.7778,26.230537), new Vector3(0,0,125.82076)),
            new PositionAndRotation(new Vector3(-8.323564,-1081.6957,26.231573), new Vector3(0.22838873,0.25097412,127.38086)),
            new PositionAndRotation(new Vector3(-57.43277,-1056.2773,27.279324), new Vector3(-0.010828756,0.060628563,-20.327332)),
            new PositionAndRotation(new Vector3(-60.725914,-1065.387,26.977596), new Vector3(-0.010828756,0.060628563,-20.629198)),
            new PositionAndRotation(new Vector3(-53.74787,-1079.3306,26.493666), new Vector3(-0.010828756,0.060628563,70.59173)),
            new PositionAndRotation(new Vector3(-50.398037,-1069.078,26.994404), new Vector3(-0.010828756,0.060628563,-107.418594)),
        }}
    };

    public static PositionAndRotation GetRandomPositionParking(int parkingId)
    {
        Random random = new Random();
        var positions = ParkingsAndPositions[parkingId];
        return positions[random.Next(1, positions.Count)];
    }
}