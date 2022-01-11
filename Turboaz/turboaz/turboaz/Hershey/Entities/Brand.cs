using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turboaz.Hershey.Entities
{[Serializable]
    internal class Brand
    {
        private static int counter = 0;
        private static int counterbrand;

        public Brand()
        {
            counter++;
            this.Id = counter;
        }
        static public void SetCounter(int counter)
        {
            Brand.counterbrand = counter;
        }


        public int Id { get; set; } 
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}.{Name} ";
        }
    }
}
