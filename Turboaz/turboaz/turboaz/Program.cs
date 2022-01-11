using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using turboaz.Hershey.Entities;

namespace turboaz
{
       [Serializable]
    internal class Program
    {
        static string fileName = "turboazsystem.dat";
        static   GenericStore<Brand> brandStore = new GenericStore<Brand>();
        static   GenericStore<Model> modelStore = new GenericStore<Model>();
        static   GenericStore<Car>   carStore   = new GenericStore<Car>();
        static void Main(string[] args)
        {
         int carId;
         int brandId;
         int modelId;

            Console.Title = "Turboazzmenu";
            try

            {
                using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))

                {
                    BinaryFormatter bf = new BinaryFormatter();

                    var db = (CarContext)bf.Deserialize(file);

                    modelStore = db.Models;

                    brandStore = db.Brands;

                    carStore = db.Cars;

                    Brand.SetCounter(brandStore[brandStore.Count - 1].Id);

                    Model.SetCounter(modelStore[modelStore.Count - 1].Id);

                    Car.SetCounter(carStore[carStore.Count - 1].Id);
                }
            }

            catch (Exception)

            {

            }

        l1:
            PrintMenu();
           

            switch (Methods.ReadInteger("Choose Menu :"))
            {
                case 1:
                    
                        Brand b = new Brand();
                        b.Name = Methods.ReadString("Insert Brand Name : ");
                        brandStore.Add(b);
                        Console.Clear();
                        goto case 4;
                    
                case 2:
                        Console.Clear();
                        GetAllBrand();
                l3:
                        brandId = Methods.ReadInteger("Brand Id :");

                        var brandList = brandStore.Find(b => b.Id == brandId);
                        if (brandList == null)
                        {
                        Console.WriteLine("Choose from List :");
                        goto l3;
                        }
                        brandList.Name = Methods.ReadString(" Brand Name :");
                        goto case 4;

                   

                case 3:
                    
                        GetAllBrand();
                        
                    l2:
                        brandId = Methods.ReadInteger("Choose Brand to Remove ");
                        Console.Clear();
                        GetAllBrand();
                        if (!brandStore.Exists(b=>b.Id == brandId))
                        {
                            Console.WriteLine("Choose from List");
                            goto l2; 
                        }

                        Brand founded = brandStore.Find(b=>b.Id == brandId);
                        brandStore.Remove(founded);
                        goto case 4;
                    
                case 4:
                    
                        Console.Clear();
                        GetAllBrand();
                        Console.WriteLine("Press any key to return Menu :");
                        Console.ReadKey();
                        Console.Clear();
                        goto l1;
                case 5:

                l4:
                    Console.Clear();
                    Console.WriteLine("Choose From Brand List :");
                    GetAllBrand();
                    brandId = Methods.ReadInteger("Insert Brand ID :");
                    var chooseBrand = brandStore.Find(b => b.Id == brandId);
                    if (chooseBrand == null)
                    {
                        Console.WriteLine("Choose from List :");
                        goto l4;
                    }
                        Model m = new Model();
                   
                        m.BrandId= chooseBrand.Id;
                        m.Name = Methods.ReadString("Insert Model Name :");
                        modelStore.Add(m);
                    goto case 8;
                case 6:
                    Console.Clear();
                    GetAllModel();

                l5:
                    modelId = Methods.ReadInteger("Model ID: ");

                    var foundModel = modelStore.Find(m => m.Id == modelId);

                    if (foundModel == null)
                    {
                        Console.WriteLine("You must select from the list: ");
                        goto l5;
                    }
                    foundModel.Name = Methods.ReadString("Model name: ");

                    goto case 8;

                case 7:

                
                    GetAllModel();
                l6:
                    modelId = Methods.ReadInteger("Model ID: ");

                    if (!modelStore.Exists(m => m.Id == modelId))
                    {
                        Console.WriteLine("You must select from the list ");
                        goto l6;
                    }

                    Model found2 = modelStore.Find(m => m.Id == modelId);

                    modelStore.Remove(found2);

                    goto case 4;



                case 8:

                    Console.Clear();
                    GetAllModel() ;
                    Console.WriteLine("Press any key to return Menu :");
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;
                case 9:
                    Console.Clear();
                    Console.WriteLine("Please select from this list: ");
                    GetAllBrand();
                    brandId = Methods.ReadInteger("Brand ID: ");

                    var chooseBrands = brandStore.Find(b => b.Id == brandId);

                    if (chooseBrands == null)
                    {
                        Console.WriteLine("This brand doesnt exist. Please create a new brand.");
                        goto case 1;
                    }

                    Console.Clear();
                    Console.WriteLine("Select from the list: ");
                    GetAllModel();
                    modelId = Methods.ReadInteger("Model ID: ");

                    var chooseModels = modelStore.Find(m => m.Id == modelId);

                    if (chooseModels == null)
                    {
                        Console.WriteLine("No Match , Add New Model");
                        goto case 5;
                    }
                   
                    Car c = new Car();
                   

                    c.Name = Methods.ReadString("Car name :");
                   
                    c.Year = Methods.ReadInteger("Year :");
                   
                    c.BanNo = Methods.ReadInteger("Ban Number :");
                    
                    c.Engine = Methods.ReadDouble("Car Engine :");
                   
                    c.Transmission = Methods.ReadString("Car Transmission :");
                   
                    c.Color = Methods.ReadString("Car color :");
                    
                    c.Price = Methods.ReadDouble("Price :");
                    
                    carStore.Add(c);
                    Console.Clear();
                    Console.WriteLine("Press ENTER to return menu...");
                    Console.ReadKey();
                    goto l1;

                case 10:
                    GetAllCar();


                k2:
                    carId = Methods.ReadInteger("Car ID: ");

                    var foundcar = carStore.Find(c => c.Id == carId);

                    if (foundcar == null)
                    {
                        Console.WriteLine("You must select from the list: ");
                        goto k2;
                    }
                    foundcar.Name = Methods.ReadString("Car Name : ");
                    foundcar.Year = Methods.ReadInteger("Car Year :");
                    foundcar.Transmission = Methods.ReadString("Car Transmission :");
                    foundcar.BanNo = Methods.ReadInteger("Car Banno : ");
                    foundcar.Engine = Methods.ReadDouble("Car Engine : ");
                    foundcar.Color = Methods.ReadString("Car Color : ");
                    foundcar.Price = Methods.ReadInteger("Car Price : ");
                    

                    goto case 12;


                case 11:

                k3:
                    GetAllCar();

                    carId = Methods.ReadInteger("Choose Car Id :");
                    if (!carStore.Exists(c => c.Id == carId))
                    {
                        Console.WriteLine("Choose from List");
                        goto k3;
                    }

                    Car founded1 = carStore.Find(c => c.Id == carId);

                    carStore.Remove(founded1);
                    goto case 12;



                    break;
                case 12:

                    Console.Clear();
                    GetAllCar();
                    Console.WriteLine("Press any key to return Menu :");
                    Console.ReadKey();
                    Console.Clear();
                    goto l1;
                case 13:

                    Console.Clear();

                    Console.WriteLine("Saving....");

                    Task.Delay(1800).Wait();

                    Console.Clear();

                    Console.WriteLine("Saved!");

                    CarContext db = new CarContext();

                    db.Brands = brandStore;

                    db.Models = modelStore;

                    db.Cars = carStore;

                    using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))

                    {

                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(file, db);

                    }
                    goto l1;



                    break;
                default:
                    Console.WriteLine("Bele olmaz axi");
                    goto l1;
                    
            }

        }

        private static void PrintMenu()
        {   Console.WriteLine("1.Add New Brand ");
            Console.WriteLine("2.Edit Brand ");
            Console.WriteLine("3.Remove Brand ");
            Console.WriteLine("4.List of Brands");


            Console.WriteLine("5.Add New Model ");
            Console.WriteLine("6.Edit Model ");
            Console.WriteLine("7.Remove Model ");
            Console.WriteLine("8.List of Models");


            Console.WriteLine("9.Add new Car");
            Console.WriteLine("10.Edit Current Car");
            Console.WriteLine("11.Remove Car ");
            Console.WriteLine("12.List of Cars ");
            Console.WriteLine("13.Save ");
        }

        static void GetAllBrand()
        {
            Console.WriteLine("List of Brands : ");
            foreach (var item in brandStore)
            {
                Console.WriteLine(item);
            }
            
        }
        static void GetAllModel()
        {
            Console.WriteLine("List of Models :");
            foreach (var item in modelStore)
            {
                Console.WriteLine(item);
            }
        }
         private static void GetAllCar()
        {
            Console.WriteLine("List of Cars :");
            foreach (var item in carStore)
            {
                Console.WriteLine(item);
            }
        }
    }
}
