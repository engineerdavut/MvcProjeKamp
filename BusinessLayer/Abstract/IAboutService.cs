using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        About Get(int id);
        void Add(About about);
        void Update(About about);

        void Delete(About about);
        List<About> GetList();
        
    }
}
