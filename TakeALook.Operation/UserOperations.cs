using TakeALook.Model;
using TakeALook.Model.Interface;
using TakeALook.Operation.Interface;
using TakeALook.Repository;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation
{
    public class UserOperations : OperationsBase, IUserOperations
    {
        private IRepository<User> m_UserRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        public UserOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_UserRepository = m_UnitOfWork.Repository<User>();
        }

        /// <summary>
        /// Kullanıcı yoksa oluşturulur
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IUser CreateUser(IUser user)
        {
            IUser temp = m_UserRepository.GetMany(x => x.UserID == user.UserID).FirstOrDefault();
            if (temp == null)
            {
                user.AddedDate = DateTime.Now;
                return m_UserRepository.Add(user as User);
            }
            return temp;
        }
    }
}
