using System.Collections.Generic;
using DailyReports.Contracts.Models;

namespace DailyReports.Contracts.Interfaces
{
   public interface IStationsService
   {
       List<Station> GetStationsList(LoggedInUser LoggedInUser, List<ValidationMessage> validationMessages);
       int? AddStation(Station station, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages);
   } 
}
