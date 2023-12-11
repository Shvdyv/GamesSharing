using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Repository.Interfaces
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            T? Get(Guid guid);

            ICollection<T> GetAllObjects(Guid id)
            {
                throw new NotImplementedException();
            }
            IEnumerable<T> GetAll();
            IEnumerable<T> SearchBy(string paramName, string searchString);
            /// <summary>
            /// If composition is used children objects must contain GUID, otherwise will throw Exception
            /// </summary>
            /// <param name="entity"></param>
            /// <param name="user"></param>
            /// <returns></returns>
            T Add(T entity);
            /// <summary>
            /// Remember to use State.Modify instead of context update
            /// </summary>
            /// <param name="entity">Entity to modify</param>
            /// <param name="user"></param>
            void Update(T entity);
            /// <summary>
            /// Method is using default Key Attribute - or in custom cases depends on implementation
            /// </summary>
            /// <param name="entity"></param>
            void Delete(Guid id);
            T Login(string login, string password);
            T GetUser(Guid id);
            User Login(string Token);
            ClaimsIdentity GetClaims(User user);
        }

    }
}
