namespace Domain
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MachineType MachineType { get; set; }
        public int MachineTypeId { get; set; }
    }
}