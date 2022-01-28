namespace ClassLibraryBatleShip.Models
{
    public class Ship
    {
        public int StartHorizontal { get; set; }
        public int StartVertical { get; set; }
        public int StopHorizontal { get; set; }
        public int StopVertical { get; set; }

    }
    public enum ShipMastAmount
    {
        Four = 4, Three = 3, Two = 2, One = 1
    }
}
