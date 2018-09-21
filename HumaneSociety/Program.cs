using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            //PointOfEntry.Run();
            HumaneSocietyDataContext DB = new HumaneSocietyDataContext();

            Query.AddNewClient("Bob","Barker", "BBob", "thepriceisright","Bbob@OldDude.com", "123 Road Place", 22222, 2);
         

        }
    }
}
