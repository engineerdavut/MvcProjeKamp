using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);

        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryId==id);
        }

        //GenericRepository<Category> repository = new GenericRepository<Category>();
        //public List<Category> GetAll()
        //{
        //    return repository.List();
        //}


        //public void CategoryAddBL(Category p)
        //{
        //    //sart....
        //    repository.Insert(p);

        //}

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}
