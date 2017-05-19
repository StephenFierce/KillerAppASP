using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerAppASP.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Items { get; }

        void Add(T item);
        void Refresh();
        void Update(T item);
        void Delete(T item);
        void GetItem(int ID);

    }
}
