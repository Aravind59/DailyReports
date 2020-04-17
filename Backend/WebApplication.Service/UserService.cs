using System.Collections.Generic;
using DailyReports.Contracts.Interfaces;
using DailyReports.Contracts.Models;
using DailyReports.Repositories;
using DailyReports.Service.Helpers;

namespace DailyReports.Service
{
   public class UserService : IUserService
   {
        private readonly UserRepository _userRepository;
        private readonly SuppliersRepository _suppliersRepository;
        private readonly StationsRepository _stationsRepository;
        public UserService(UserRepository userRepository, SuppliersRepository suppliersRepository, StationsRepository stationsRepository)
        {
            _userRepository = userRepository;
            _suppliersRepository = suppliersRepository;
            _stationsRepository = stationsRepository;
        }

        public UserDetails GetUserDetails(string userName, string password)
        {
            return _userRepository.GetUserDetails(userName, password);
        }

        public int? RegisterUser(UserRegistration registration, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (!CommonValidationHelper.ValidateLoggedInUser(loggedInUser, validationMessages))
            {
                return null;
            }

            var station = new Station { Name = registration.StationName, StationCode = registration .StationCode, Address = registration .Address, MobileNumber = registration .MobileNumber};
            var stationId = _stationsRepository.AddStation(station, validationMessages);
            if (stationId != null)
            {
                var userDetails = new UserDetails { Username = registration.UserName, Password = registration.Password, Email = registration.Email, IsAdmin = registration.IsAdmin};
                var userId = _userRepository.AddUser(userDetails, validationMessages);
                var supplier = new Supplier { FirstName = registration.FirstName, LastName = registration .LastName, Address = registration .Address, MobileNumber = registration .MobileNumber, StationId = stationId ?? 0, UserId = userId};
                var supplierId = _suppliersRepository.AddSupplier(supplier, validationMessages);
                return userId;
            }
           
            return null;
        }
      
    }
}
