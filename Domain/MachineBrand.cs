namespace Domain
{
    public class MachineBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MachineCategory MachineCategory { get; set; }
        public int MachineCategoryId { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}