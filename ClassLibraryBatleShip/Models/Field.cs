namespace ClassLibraryBatleShip.Models
{
    public class Field
    {
        public Field()
        {

        }
        public Field(Field field)
        {
            this.FieldStatus = field.FieldStatus;
            this.Horizontal = field.Horizontal;
            this.Vertical = field.Vertical;
        }
        public int Vertical { get; set; }
        public int Horizontal { get; set; }
        public FieldStatusEnum FieldStatus { get; set; } = FieldStatusEnum.Empty;
    }
    public enum FieldStatusEnum
    {
        Empty, Ship, Wrack, ShipNeighbor, Checked
    }
}
