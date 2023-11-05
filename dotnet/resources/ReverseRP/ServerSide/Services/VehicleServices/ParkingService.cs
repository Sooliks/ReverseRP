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
            
        }}
    };

    public static PositionAndRotation GetRandomPositionParking(int parkingId)
    {
        Random random = new Random();
        var positions = ParkingsAndPositions[parkingId];
        return positions[random.Next(1, positions.Count)];
    }
}