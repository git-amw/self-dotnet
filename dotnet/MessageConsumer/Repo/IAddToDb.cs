using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageConsumer.Repo
{
    public interface IAddToDb
    {
        Task<bool> SaveToDb(int number);
    }
}
