using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turboaz.Hershey.Entities
{[Serializable]
    internal class Car
    {
        private static int countercar = 0;

        public Car()
        {
            countercar++;
            this.Id = countercar;
        }
        static public void SetCounter(int counter)
        {
            Car.countercar = countercar;
        }

        public int Id { get; set; } 
            public string Name { get; set; }
            public int ModelId { get; set; }
            public int Year   { get; set; }
            public int BanNo   { get; set; }
             public double Engine { get; set; }
             public string Transmission { get; set; }
             public string Color { get; set; }
             public double Price { get; set; }

             public override string ToString()
        {
            return $"ID: {Id} Name: {Name}  ";
        }

      

    }
}
