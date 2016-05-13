using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class SampleValidator : BaseEntity
    {
        public SampleValidator(string column1, string column2, string column3)
        {
            Column1 = column1;
            Column2 = column2;
            Column3 = column3;
        }

        public SampleValidator(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Column1 { get; set; }

        public string Column2 { get; set; }

        public string Column3 { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }
    }
}
