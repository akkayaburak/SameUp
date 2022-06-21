namespace Domain
{
    public class MachineType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MachineCategory MachineCategory { get; set; }
        public int MachineCategoryId { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Machine> Machines { get; set; }
    }
}