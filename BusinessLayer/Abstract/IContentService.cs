using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        Content Get(int id);
        void Add(Content content);
        void Update(Content content);

        void Delete(Content content);
        List<Content> GetList();
        List<Content> GetListByHeadingId(int id);
    }
}
