namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string  name { get; set; }
        public string email { get; set; }
        public DateTime BirthDate { get; set; }

        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();



        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id=id;
            this.name=name;
            this.email=email;
            BirthDate=birthDate;
            BaseSalary=baseSalary;
            Department= new Department(1, "Computers");
        }

        public void AddSales(SalesRecord record)
        {
            Sales.Add(record);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);  
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
