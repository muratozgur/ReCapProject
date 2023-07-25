using Azure;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }
        
        public IDataResult<List<VM_Response_Users_GetUsers>> GetUsers(VM_Request_Users_GetUsers requestModel)
        {//Allows WebAPI to find users with any property parameter
            if (!requestModel.Id.HasValue && requestModel.FirstName.IsNullOrEmpty() &&
                requestModel.LastName.IsNullOrEmpty() && requestModel.Email.IsNullOrEmpty())
            {//if there is no any input
                return new ErrorDataResult<List<VM_Response_Users_GetUsers>>("No search parameter provided.");
            }
            List<User> users = _userDal.GetAll();
            if(requestModel.Id.HasValue)//if id input exists
                users = users.Where(u => u.Id.Equals(requestModel.Id.Value)).ToList();
            if(!requestModel.FirstName.IsNullOrEmpty())//if name input exists
                users = users.Where(u => u.FirstName.Equals(requestModel.FirstName)).ToList();
            if (!requestModel.LastName.IsNullOrEmpty())//if last name input exists
                users = users.Where(u => u.LastName.ToLower().Equals(requestModel.LastName.ToLower())).ToList();
            if (!requestModel.Email.IsNullOrEmpty())//if email input exists
                users = users.Where(u => u.Email.ToLower().Equals(requestModel.Email.ToLower())).ToList();

            List<VM_Response_Users_GetUsers> response = users.Select(u => new VM_Response_Users_GetUsers
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
            }).ToList();
            return new SuccessDataResult<List<VM_Response_Users_GetUsers>>(response, "Users retrieved successfully.");
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id.Equals(id)));
        }
    }
}
