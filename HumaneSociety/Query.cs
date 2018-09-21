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
            IQueryable<Adoption> clients = null;
            return clients;
        }

        internal static Client GetClient(string userName, string password)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
           Client client = null;
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
            throw new NotImplementedException();
        }

        internal static IQueryable <Animal> SearchForAnimalByMultipleTraits()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Animal> animals = null;
            return animals;
        }

        internal static IQueryable<Client> RetrieveClients()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Client> clients = null;
            return clients;
        
        }

        internal static IQueryable<USState> GetStates()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<USState> name = null;
            return name;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateAddress(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void updateClient(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateUsername(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateFirstName(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateLastName(Client client)
        {
            throw new NotImplementedException();
        }

        internal static void RunEmployeeQueries(Employee employee, string v)
        {
            throw new NotImplementedException();
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<Adoption> adoptions = null;
            return adoptions;
        }

        internal static void UpdateAdoption(bool v, Adoption adoption)
        {
            throw new NotImplementedException();
        }

        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();
            IQueryable<AnimalShot> shots = null;
            return shots;
        }

        internal static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            throw new NotImplementedException();
        }

        //internal static Species GetSpecies()
        {
            return null;
        }

        internal static DietPlan GetDietPlan()
        {
            return null;
        }

        internal static void AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            return null;
        }

        internal static void RemoveAnimal(object animal)
        {
            throw new NotImplementedException();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            return null;
        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal static Room GetRoom(int animalId)
        {
            throw new NotImplementedException();
        }

        internal static bool CheckEmployeeUserNameExist(string username)
        {
            return false;
        }

        internal static void UpdateEmail(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
