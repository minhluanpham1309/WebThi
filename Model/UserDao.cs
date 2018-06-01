using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDao
    {
        DeThiDBContext db;

        public UserDao()
        {
            db = new DeThiDBContext();
        }
        public IEnumerable<User> ListUser()
        {
            return db.Users;
        }
        public bool Delete(int id)
        {
            try
            {
                var model = db.Users.Find(id);
                db.Users.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public bool ChangeStatus(int id)
        {
            var model = db.Users.Find(id);
            model.Status = !model.Status;
            db.SaveChanges();
            return model.Status;
        }
        public int Create(User user)
        {
            var model = db.Users.Add(user);
            db.SaveChanges();
            return model.ID;
        }

        public bool Edit(User user)
        {
            try
            {
                var model = db.Users.Find(user.ID);
                model.Fullname = user.Fullname;
                model.Phone = user.Phone;
                model.Address = user.Address;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public User GetUserByID(int id)
        {
            return db.Users.Find(id);
            
        }
    }
}
