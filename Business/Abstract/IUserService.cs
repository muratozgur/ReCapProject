using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<VM_Response_Users_GetUsers>> GetUsers(VM_Request_Users_GetUsers requestModel);//Allows WebAPI to find users with any property parameter
        IDataResult<User> GetById(int id);
    }
}
