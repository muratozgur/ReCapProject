using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Added";
        public static string Deleted = "Deleted";
        public static string Updated = "Updated";
        public static string Listed = "Listed";
        public static string CarAdded = "Car added";
        public static string RentalAdded = "Rental added";
        public static string RentalUpdated = "Rental updated";
        public static string RentalDeleted = "Rental deleted";
        public static string RentalsListed = "Rentals listed";
        public static string RentalReturnDateNull = "Return date must be given";
        public static string CarNameInvalid = "Car name is invalid";
        public static string MaintenanceTime = "System in maintenance";
        public static string CarsListed = "Cars listed";
        public static string ColorsListed = "Colors listed";
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car updated";
        public static string CarImageLimitExceeded = "Car image limit has been exceeded, new car image can not be added";
        public static string ImageAddedSuccessfully = "Car image has been added successfully";
    }
}
