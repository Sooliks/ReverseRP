
using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Entities;

public class ReversePlayer : Player
{
     public Character Character { get; set; }
     public Account Account { get; set; }
     public ReversePlayer(NetHandle handle) : base(handle)
     {
          
     }
}