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
            Animal animals = null;
            Adoption adoption = null;
            var adopts = DB.Adoptions.Where(a => a.AdoptionId == adoption.AdoptionId && a.ClientId == client.ClientId && a.AnimalId == animals.AnimalId).FirstOrDefault();
            var status = DB.Adoptions.Where(s => s.ApprovalStatus == adoption.ApprovalStatus && s.AdoptionFee == adoption.AdoptionFee && s.PaymentCollected == adoption.PaymentCollected).FirstOrDefault();
            return;
        }

        internal static object GetApprovalStatus(Adoption adoption)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            Adoption approval = DB.Adoptions.Where(a => a.AnimalId == adoption.AnimalId && a.ApprovalStatus == adoption.ApprovalStatus).FirstOrDefault();
            return approval;
        }
        internal static void UpdatePaymentStatus(Adoption adoption)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            adoption.PaymentCollected = true;
            adoption.AdoptionFee = 75;
            DB.SubmitChanges();
        }


        internal static IQueryable<Animal> SearchForAnimalByMultipleTraits(IQueryable<Animal> animals = null)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            if(animals == null)
            {
                animals = DB.Animals;
            }
            Animal animal = new Animal();
            Console.WriteLine("What would you like to search by? 'AnimalId', 'Name', 'SpeciesId', 'Weight', 'Age', 'DietPlanId', 'Demeanor', 'KidFriendly', 'PetFriendly', 'Gender', 'AdpotionStatus', 'EmployeeId' ");
            var UserSearch = Console.ReadLine();
            string type = null;
            switch (type)
            {
                case ("AnimalId"):
                    animals = DB.Animals.Where(i => i.AnimalId == animal.AnimalId);
                    break;
                case ("Name"):
                    animals = DB.Animals.Where(n => n.Name == animal.Name);
                    break;
                case ("SpeciesId"):
                     animals = DB.Animals.Where(s => s.SpeciesId == animal.SpeciesId);
                    break;
                case ("Weight"):
                     animals = DB.Animals.Where(w => w.Weight == animal.Weight);
                    break;
                case ("Age"):
                    animals = DB.Animals.Where(a => a.Age == animal.Age);
                    break;
                case "DietPlanId":
                    animals  = DB.Animals.Where(d => d.DietPlanId == animal.DietPlanId);
                    break;
                case "Demeanor":
                    animals = DB.Animals.Where(d => d.Demeanor == animal.Demeanor);
                    break;
                case "KidFriendly":
                    animals = DB.Animals.Where(k => k.KidFriendly == animal.KidFriendly);
                    break;
                case "PetFriendly":
                    animals = DB.Animals.Where(p => p.PetFriendly == animal.PetFriendly);
                    break;
                case "Gender":
                   animals = DB.Animals.Where(g => g.Gender == animal.Gender);
                    break;
                case "AdoptionStatus":
                    animals = DB.Animals.Where(a => a.AdoptionStatus == animal.AdoptionStatus);
                    break;
                case "EmployeeId":
                    animals = DB.Animals.Where(e => e.EmployeeId == animal.EmployeeId);
                    break;
                default:
                    Console.WriteLine("Not a vaild trait");
                    
                    return DB.Animals;
            }
            Console.WriteLine("should we continue searching?");
            var userAnswer = Console.ReadLine();
            if (userAnswer == "yes")
            {
                SearchForAnimalByMultipleTraits(animals);
            }
            else
            {
                return SearchForAnimalByMultipleTraits(animals);
            }
            return SearchForAnimalByMultipleTraits(animals);
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

        //return list of shots by animal id
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
            if (ExistingShot != null)
            {
                var id = ExistingShot.ShotId;
                return id;
            }

            else
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

        internal static void UpdateShot(string v, Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            AnimalShot animalShot = new AnimalShot();
            DateTime dat1 = new DateTime();

            var existsResult = CheckShotExists();
            if (existsResult != 0)
            {

            }
        
            else
            {
                CreateNewShot();
            }

        
            var foundShot = DB.Shots.Where(s => s.Name == v).FirstOrDefault();
            //returns name of shot where it matches name passed in.
            var foundAnimalShot = DB.AnimalShots.Where(s => s.AnimalId == animal.AnimalId && s.ShotId == foundShot.ShotId).FirstOrDefault();

            animalShot.AnimalId = foundAnimalShot.AnimalId;
            animalShot.ShotId = foundAnimalShot.ShotId;
            animalShot.DateReceived = dat1;

            DB.AnimalShots.InsertOnSubmit(animalShot);
        }


        internal static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            //    HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            //    animal.AnimalId
            //        animal.AnimalShots
            //        animal.Age
            //        animal.Gender
            //        animal.EmployeeId
            //        animal.KidFriendly
            //        animal.Name
            //        animal.Species
            //        animal.SpeciesId
            //        animal.Weight
            //        animal.DietPlanId
            //        animal.DietPlan
            //        animal.Demeanor
            //        animal.Employee
            //        animal.Age
            //        animal.AdoptionStatus
            //        animal.PetFriendly
            
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

        internal static IQueryable<Room> SeeRooms(Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Room> rooms = DB.Rooms;
            return rooms;
        }
        internal static Room GetRoom(int animalId)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var room = DB.Rooms.Where(r => r.RoomId == animalId).FirstOrDefault();
            room.AnimalId = room.AnimalId;
            DB.SubmitChanges();
            return room;
        }

        internal static void MoveAnimal(Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            var room = DB.Rooms.Where(r => r.AnimalId == animal.AnimalId).FirstOrDefault();
            Console.WriteLine("The animal is currently in room " + room);
            Console.WriteLine("What room would you like to move this animal to?");
            var newRoom = Int32.Parse(Console.ReadLine());

            room.AnimalId = newRoom;
            DB.SubmitChanges();

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
