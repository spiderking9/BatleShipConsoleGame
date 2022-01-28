namespace ClassLibraryBatleShip.Models
{
    public class Field
    {
        public int Vertical { get; set; }
        public int Horizontal { get; set; }
        public FieldStatusEnum FieldStatus { get; set; } = FieldStatusEnum.Empty;
    }
    public enum FieldStatusEnum
    {
        Empty, Ship, Wrack, ShipNeighbor, Checked
    }
}
