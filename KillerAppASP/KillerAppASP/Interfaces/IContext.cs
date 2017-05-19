using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerAppASP.Interfaces
{
    public interface IContext<T>
    {
        void Create(T item);

        List<T> Read();

        void Update(T item);

        void Delete(T item);
    }
}
