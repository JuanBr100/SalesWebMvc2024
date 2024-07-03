using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context=context;
        } 
        
        public void Seed()
        {

            _context.Database.EnsureCreated();
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any() ) 
            {
                return; // O banco de dados já foi populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Mechanical");
            Department d4 = new Department(4, "Civil");
            Department d5 = new Department(5, "Electrical");
            Department d6 = new Department(6, "Chemical");
            Department d7 = new Department(7, "Biomedical");
            Department d8 = new Department(8, "Aerospace");
            Department d9 = new Department(9, "Environmental");
            Department d10 = new Department(10, "Materials Science");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998,4,21),1000.0,d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1985, 2, 15), 1500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1992, 11, 30), 1200.0, d3);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1990, 5, 10), 1100.0, d4);
            Seller s5 = new Seller(5, "Donald White", "donald@gmail.com", new DateTime(1988, 9, 25), 2000.0, d5);
            Seller s6 = new Seller(6, "Anna Blue", "anna@gmail.com", new DateTime(1995, 7, 14), 1300.0, d6);
            Seller s7 = new Seller(7, "James Black", "james@gmail.com", new DateTime(1983, 3, 5), 1700.0, d7);
            Seller s8 = new Seller(8, "Laura Pink", "laura@gmail.com", new DateTime(1997, 12, 9), 1400.0, d8);
            Seller s9 = new Seller(9, "Peter Orange", "peter@gmail.com", new DateTime(1991, 6, 20), 1600.0, d9);
            Seller s10 = new Seller(10, "Sophia Purple", "sophia@gmail.com", new DateTime(1989, 1, 30), 1800.0, d10);


            SalesRecord r2 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 27), 4000.0, SaleStatus.Canceled, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 28), 1000.0, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 29), 2000.0, SaleStatus.Peding, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 30), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 10, 01), 3000.0, SaleStatus.Canceled, s7);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 10, 02), 9000.0, SaleStatus.Billed, s8);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 10, 03), 5000.0, SaleStatus.Peding, s9);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 10, 04), 6000.0, SaleStatus.Canceled, s10);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 10, 05), 7000.0, SaleStatus.Billed, s1);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 10, 06), 12000.0, SaleStatus.Peding, s2);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 10, 07), 4000.0, SaleStatus.Canceled, s3);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 10, 08), 1000.0, SaleStatus.Billed, s4);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2018, 10, 09), 2000.0, SaleStatus.Peding, s5);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2018, 10, 10), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2018, 10, 11), 3000.0, SaleStatus.Canceled, s7);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2018, 10, 12), 9000.0, SaleStatus.Billed, s8);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2018, 10, 13), 5000.0, SaleStatus.Peding, s9);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2018, 10, 14), 6000.0, SaleStatus.Canceled, s10);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2018, 10, 15), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2018, 10, 16), 7000.0, SaleStatus.Peding, s2);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2018, 10, 17), 4000.0, SaleStatus.Canceled, s3);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2018, 10, 18), 1000.0, SaleStatus.Billed, s4);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2018, 10, 19), 2000.0, SaleStatus.Peding, s5);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2018, 10, 20), 8000.0, SaleStatus.Billed, s6);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2018, 10, 21), 3000.0, SaleStatus.Canceled, s7);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2018, 10, 22), 9000.0, SaleStatus.Billed, s8);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2018, 10, 23), 5000.0, SaleStatus.Peding, s9);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2018, 10, 24), 6000.0, SaleStatus.Canceled, s10);

            _context.Department.AddRange(d1, d2, d3, d4, d5, d6, d7, d8, d9, d10);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);

            _context.SalesRecords.AddRange(
                 r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();





        }
    }
}
