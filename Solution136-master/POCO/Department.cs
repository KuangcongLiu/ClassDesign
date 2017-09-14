namespace POCO
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.DepartmentId + "-" + this.Name + "-" + this.Description;
        }
    }
}
