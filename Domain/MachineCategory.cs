namespace Domain
{
    public class MachineCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MachineType> MachineTypes { get; set; }
        public ICollection<MachineBrand> MachineBrands { get; set; }    
    }
}