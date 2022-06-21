namespace Domain
{
    public class Machine
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int YearOfProduction { get; set; }
        public MachineBrand MachineBrand { get; set; }
        public int MachineBrandId { get; set; }
        public MachineType MachineType { get; set; }
        public int MachineTypeId { get; set; }
    }
}