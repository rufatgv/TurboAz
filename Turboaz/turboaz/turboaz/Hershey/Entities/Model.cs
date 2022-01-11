using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turboaz.Hershey.Entities
{[Serializable]
    internal class Model
    {
      
        private static int countermodel = 0;

        public Model()
        {
            
                this.Id = ++countermodel;
        }
        static public void SetCounter(int counter)
        {
            Model.countermodel = counter;
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public int BrandId { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} ";
           
        }

    }
}
