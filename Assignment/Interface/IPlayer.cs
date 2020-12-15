using Assignment.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Interface
{
    public interface IPlayer<T> : IUser<T>
    {
        PIECE_TYPE SetName {get;set;}
    }
    public interface IUser<T>
    {
        T Id { get; set; }
        string Name { get; set; }
    }

}
