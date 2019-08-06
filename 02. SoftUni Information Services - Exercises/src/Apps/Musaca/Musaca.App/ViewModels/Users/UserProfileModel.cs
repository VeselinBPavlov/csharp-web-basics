using Musaca.Models;
using System;

namespace Musaca.App.ViewModels.Users
{
    public class UserProfileModel
    {
        public string Id { get; set; }
        public decimal Total { get; set; }
        public string IssuedOn { get; set; }
        public string CashierName { get; set; }
    }
}
