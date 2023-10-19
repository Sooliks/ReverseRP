using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;

namespace ServerSide.Services.ServerServices;

public class DimensionService
{
    public static void SetUniqueDimension(Entity entity)
    {
        var random = new Random();
        uint newDimension = (uint)random.Next(0,int.MaxValue);
        if (NAPI.Pools.GetAllVehicles().FirstOrDefault(v=>v.Dimension == newDimension)!=null)
        {
            SetUniqueDimension(entity);
            return;
        }
        entity.Dimension = newDimension;
    }
}