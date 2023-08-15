using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Entities;

public class ReversePlayer : Player
{
     public Character Character { get; set; }
     public Account Account { get; set; }
     public ReversePlayer(NetHandle handle) : base(handle)
     {
          
     }
}