using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Data.Models
{
    /// <summary>
    /// Interface to implement with Users(base), Service Provider and Client classes.
    /// Times we have parameters in functions that can be either User, SP or Client object class, 
    /// we can create the parameter as an interface type IUser and pass either class in the same function.
    /// Ex: public int GetID(IUser) {return IUser.UserTypeID; }=> 
    /// Service Provider sp = new Service Provider; id = GetID(ServiceProvider) 
    /// or Client id = new Client; id = GetID(Client) 
    /// or User id = new User; id = GetID(User)
    /// </summary>
    public interface IUser
    {
        int UserID { get; set; }
        int UserTypeID { get; set; }
        string Email { get; set; }
        string UserPassword { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        int ZipCode { get; set; }
        decimal PreferredDistance { get; set; }
        int ClientID { get; set; }
        int ServiceProviderID { get; set; }
    }
}
