using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    interface IGenericServices<T>
    {
        List<T> GetList();
        void TAdd(T t);
        T GetById(int id);
        void TDelete(T t);
        void TUpdate(T t);
    }
}
