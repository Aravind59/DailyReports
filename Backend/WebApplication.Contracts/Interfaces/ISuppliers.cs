using System.Collections.Generic;
using DailyReports.Contracts.Models;

namespace DailyReports.Contracts.Interfaces
{
   public interface ISuppliers
   {
       List<Supplier> GetSuppliers(int stationId, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages);
       int? UpsertSupplier(Supplier supplier, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages);
       bool? DeleteSupplier(int suplierId, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages);
   } 
}
