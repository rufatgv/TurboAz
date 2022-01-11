using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turboaz.Hershey.Entities;

namespace turboaz
{[Serializable]
    internal class CarContext
    {
        public GenericStore<Brand> Brands { get; set; }
        public GenericStore<Model> Models { get; set; }
        public GenericStore<Car> Cars { get; set; }

    }
}
