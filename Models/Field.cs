namespace ConsoleAppStatki.Models
{
    class Field
    {
        public int Vertical { get; set; }
        public int Horizontal { get; set; }
        public FieldStatusEnum FieldStatus { get; set; } = FieldStatusEnum.Empty;
    }
    enum FieldStatusEnum
    {
        Empty, Ship, Wrack, ShipNeighbor, Checked
    }
}
