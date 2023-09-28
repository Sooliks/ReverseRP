using RAGE;

namespace ClientSide.EventsHandlers.PlayerEvents
{
    public class Waypoints : Events.Script
    {
        public static Vector3 LastWaypointPosition { get; private set; }
        public Waypoints()
        {
            Events.OnPlayerCreateWaypoint += OnWaypointCreated;
        }

        private void OnWaypointCreated(Vector3 position)
        {
            LastWaypointPosition = position;
        }
    }
}