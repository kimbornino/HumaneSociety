using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {

        internal static IQueryable<Adoption> GetUserAdoptionStatus(Client client)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Adoption> adoptions = DB.Adoptions;
            return adoptions;
        }

        internal static Client GetClient(string userName, string password)
        {
            
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var client = DB.Clients.Where(c => c.UserName == userName && c.Password == password).FirstOrDefault();
            return client;
            
        }

        internal static Animal GetAnimalByID(int iD)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            
            var animal = DB.Animals.Where(a => a.AnimalId == iD).FirstOrDefault();
            return animal;
        }

        internal static void Adopt(object animal, Client client)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Adoption newAdoption = new Adoption();
            //
            //HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            //var updatedClient = DB.Clients.Where(c => c.ClientId == client.ClientId).FirstOrDefault();
            //updatedClient.Email = client.Email;
           
            //adoptionId
                //Clientid
                //animalID
                //approval status
                //adoptionfee
                //paymentcollected

        }

        internal static IQueryable <Animal> SearchForAnimalByMultipleTraits()
        {
            //
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Animal> animals = DB.Animals;
            return DB.Animals;

        }

        internal static IQueryable<Client> RetrieveClients()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Client> client = DB.Clients;
            return DB.Clients;
        
        }

        internal static IQueryable<USState> GetStates()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<USState> name = DB.USStates;
            return name;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Client newClient = new Client();
            
            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;
            DB.Clients.InsertOnSubmit(newClient);
            DB.SubmitChanges();

            //need to be able to connect addressid to address table
            //Address newAddress = new Address();
            //var foundAddressLocation = DB.Addresses.Where(a => a.AddressId == newClient.AddressId);
            //newAddress.AddressLine1 = streetAddress;
            //newAddress.Zipcode = zipCode;
                    
           newClient.Address = new Address();
                
           newClient.Address.AddressLine1 = streetAddress;
           newClient.Address.Zipcode = zipCode;
           newClient.Address.USStateId = state;
                
            DB.Clients.InsertOnSubmit(newClient);
            DB.Addresses.InsertOnSubmit(newClient.Address);
            DB.SubmitChanges();

        }

        internal static void UpdateAddress(Client client)
        {
     
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var foundClient = DB.Clients.Where(c => c.ClientId == client.ClientId).FirstOrDefault();
            foundClient.Address.AddressLine1 = client.Address.AddressLine1;

            DB.SubmitChanges();
            
        }

        internal static void updateClient(Client client)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var updatedClient = DB.Clients.Where(c => c.ClientId == client.ClientId).FirstOrDefault();
            updatedClient.Email = client.Email;
            updatedClient.UserName = client.UserName;
            updatedClient.Password = client.Password;
            updatedClient.HomeSquareFootage = client.HomeSquareFootage;
            updatedClient.LastName = client.LastName;
            updatedClient.FirstName = client.FirstName;
            updatedClient.Income = client.Income;
            updatedClient.NumberOfKids = client.NumberOfKids;
            DB.SubmitChanges();

        }

        internal static void UpdateUsername(Client client)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var foundClient = DB.Clients.Where(e => e.UserName == client.UserName).FirstOrDefault();
            foundClient.UserName = client.UserName;
            DB.SubmitChanges();
        }

        internal static void UpdateFirstName(Client client)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var foundClient = DB.Clients.Where(e => e.FirstName == client.FirstName).FirstOrDefault();
            foundClient.FirstName = client.FirstName;
            DB.SubmitChanges();
        }

        internal static void UpdateLastName(Client client)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var foundClient = DB.Clients.Where(e => e.LastName == client.LastName).FirstOrDefault();
            foundClient.LastName = client.LastName;
            DB.SubmitChanges();
        }

        internal static void RunEmployeeQueries(Employee employee, string v)
            //need a delegate function?
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            switch (v)
            {
                case "create":
                    DB.Employees.InsertOnSubmit(employee);
                    DB.SubmitChanges();
                    break;
                case "read":
                    {
                        var employeeToRead = DB.Employees.SingleOrDefault(Employee => employee.EmployeeId == Employee.EmployeeId);

                        Console.WriteLine("Firstname: " + employeeToRead.FirstName);
                        Console.WriteLine("Lastname: " + employeeToRead.LastName);
                        Console.WriteLine("Username: " + employeeToRead.UserName);
                        Console.WriteLine("Password: " + employeeToRead.Password);
                        Console.WriteLine("Email: " + employeeToRead.Email);
                    }

                    break;
                case "update":
                    var updatedEmployee = DB.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();
                    updatedEmployee = employee;
                    DB.SubmitChanges();

                    break;
                case "Delete":
                    DB.Employees.DeleteOnSubmit(employee);
                    DB.SubmitChanges();
                    break;
                default:
                    Console.WriteLine("Input not accepted please try again");
                    break;
            } 
             
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Adoption> adoptions = DB.Adoptions;
            return adoptions;
        }


        internal static void UpdateAdoption(bool v, Adoption adoption)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();

            if (v == true)
            {
              
                //adoption.AdoptionFee
                //adoption.AdoptionId
                //adoption.AnimalId
                //adoption.ApprovalStatus
                //adoption.ClientId
                //adoption.Client


            }
            else
            {

            }
        }

        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<AnimalShot> shots = DB.AnimalShots;
            return shots;
        }

        internal static int CheckShotExists()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Console.WriteLine("Write the common name of the shot.");
            string shotName = Console.ReadLine();
            var ExistingShot = DB.Shots.Where(s => s.Name == shotName).FirstOrDefault();

            var id = ExistingShot.ShotId;

            try
            {
                return id;
            }
            catch
            {
                return 0;
            }
        }
        internal static Shot CreateNewShot()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Shot shot = new Shot();
            Console.WriteLine("That shot is not in the databse. What is the name of the new shot?");
            var newShotName = Console.ReadLine();
            shot.Name = newShotName;
            DB.SubmitChanges();

            return shot;
        }
                                            //type of shot, animal
        internal static void UpdateShot(string v, Animal animal)
        {
            
        }

        internal static void updateDateRecieved(string v, Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var foundId = DB.AnimalShots.Where(s => s.AnimalId == animal.AnimalId).FirstOrDefault();
            // foundAnimal returns AnimalShots.animalId of passed animal
            var foundAnimal = DB.Shots.Where(s => s.ShotId == foundId.ShotId).FirstOrDefault();
            // found ShoutId returns the shotId of shots.
            var foundShot = DB.Shots.Where(s => s.Name == v).FirstOrDefault();

            var shotDate = DateTime();
            var animalShotDate = DB.AnimalShots.Where(s => s.DateReceived == foundId.DateReceived).FirstOrDefault();
            animalShotDate.DateReceived = shotDate;
        }

        internal static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            throw new NotImplementedException();
        }

        internal static int CheckSpecies()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Console.WriteLine("Write the common name of the species.");
            string speciesName = Console.ReadLine();
            var ExistingSpecies = DB.Species.Where(s => s.Name == speciesName).FirstOrDefault();

            var id = ExistingSpecies.SpeciesId;

            try
            {
                return id;
            }
            catch
            {
                return 0;
            }            
        }
                
        internal static Species GetSpecies()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Species newSpecies = new Species();
           Console.WriteLine("This species does not exist yet. Please re-enter the name of the species");
                var newSpeciesName = Console.ReadLine();
                newSpecies.Name = newSpeciesName;
                DB.SubmitChanges();            

            return newSpecies;
        }

        internal static int CheckDietPlans()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Console.WriteLine("What diet plan does this animal take?");
            string dietPlan = Console.ReadLine();
            var ExistingDietPlan = DB.DietPlans.Where(d => d.Name == dietPlan).FirstOrDefault();

            if (ExistingDietPlan != null)
            {
                var id = ExistingDietPlan.DietPlanId;
                return id;
            }
            else
            {
                return 0;
            }

        }
        internal static DietPlan GetDietPlan()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            DietPlan newDietPlan = new DietPlan();
            int exists = CheckDietPlans();
            if (exists != 0)
            {
                CheckDietPlans();
            }
            else
            {
                Console.WriteLine("This diet plan does not exist yet.  You will need to enter some information.");
                Console.WriteLine("What is the name of the diet plan?");
                var newDietPlanName = Console.ReadLine();
                Console.WriteLine("What type of food does this animal eat?");
                var newDietPlanFood = Console.ReadLine();
                Console.WriteLine("How much food (in cups) does this animal consume?");
                var newDietPlanFoodAmount = Int32.Parse(Console.ReadLine());
                
                newDietPlan.Name = newDietPlanName;
                newDietPlan.FoodType = newDietPlanFood;
                newDietPlan.FoodAmountInCups = newDietPlanFoodAmount;
              
                DB.SubmitChanges();
            }

            return newDietPlan;
        }

        internal static void AddAnimal(Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            DB.Animals.InsertOnSubmit(animal);
            DB.SubmitChanges();
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var employee = DB.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }

        internal static void RemoveAnimal(Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            DB.Animals.DeleteOnSubmit(animal);
            DB.SubmitChanges();
            
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var user = DB.Employees.Where(e => e.Email == email && e.EmployeeId == employeeNumber).FirstOrDefault();
            return user;
        }

        internal static void AddUsernameAndPassword(Employee employee)
         {
           
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
           var foundEmployee = DB.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();
            foundEmployee.UserName = employee.UserName;
            DB.SubmitChanges();
            DB.Employees.Where(e => e.Password == employee.Password);
            foundEmployee.Password = employee.Password;
            DB.SubmitChanges();
        }

        internal static Room GetRoom(int animalId)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var room = DB.Rooms.Where(r => r.RoomId == animalId).FirstOrDefault();
            room.AnimalId = room.AnimalId;
            DB.SubmitChanges();
            return room;
        }

        internal static bool CheckEmployeeUserNameExist(string username)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var employeeUserName = DB.Employees.Where(d => d.UserName == username);
            if (employeeUserName != null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        
        internal static void UpdateEmail(Client client)
        {       
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var foundClient = DB.Clients.Where(c => c.ClientId == client.ClientId).FirstOrDefault();
            foundClient.Email = client.Email;
            DB.SubmitChanges();
        }
    }
}
