namespace CompanyPlayGround.Core.Entities
{
    public partial class Department
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual List<Employee> Employees { get; set; }
    }
}

