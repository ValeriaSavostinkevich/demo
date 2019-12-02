using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Models;

namespace Framework.Service
{
    public class UserCreator
    {
        public User WithAllProperties()
        {
            return new User(TestDataReader.GetData("LastName"), 
                            TestDataReader.GetData("BookingReference"));
        }
    }
}
