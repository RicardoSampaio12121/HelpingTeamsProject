using System.Collections.Generic;
using System.Threading.Tasks;
using RESTAuth.Models;

namespace RESTAuth.Repository
{
    public interface IDashBoardLogin
    {
        /// <summary>
        /// Returns a list of the available products
        /// </summary>
        /// <returns></returns>
        public Task <int> VerifyLogin(string username, string password);
    }
}
