using System.Collections.Generic;
using DailyReports.Contracts.Interfaces;
using DailyReports.Contracts.Models;
using DailyReports.Repositories;
using DailyReports.Service.Helpers;

namespace DailyReports.Service
{
   public class StationsService : IStationsService
   {
       private readonly StationsRepository _stationsRepo;

       public StationsService(StationsRepository stationsRepo)
       {
           _stationsRepo = stationsRepo;
       }
        public List<Station> GetStationsList(LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (!CommonValidationHelper.ValidateLoggedInUser(loggedInUser, validationMessages))
            {
                return null;
            }
            var result = _stationsRepo.GetStationsList(validationMessages);
         return result;
        }

        public int? AddStation(Station station, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (!CommonValidationHelper.ValidateLoggedInUser(loggedInUser, validationMessages))
            {
                return null;
            }
            var result = _stationsRepo.AddStation(station, validationMessages);
            return result;
        }
    }
}
