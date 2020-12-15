using Assignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Entities
{
   public class User<T>:IUser<T>
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}
