using DataLayer.GenericRepository;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    //منصرف شدم از ادامه توسعه با این روش 
    public class UnitOfWork :IDisposable
    {

        MyEShopEntities _context = new MyEShopEntities() ;

        //private GenericRepository<Users> UserRepository;

        //public GenericRepository<Users> UserRepository
        //{
        //    get
        //    {
        //        if (UserRepository == null)
        //        {
        //            UserRepository = new GenericRepository<Users>(_context);
        //        }

        //        return UserRepositor;
        //    }

        //}

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
