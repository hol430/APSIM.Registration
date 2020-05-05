using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace APSIM.Registration.Service
{
    [ServiceContract]
    public interface IRegistration
    {
        /// <summary>
        /// Add a upgrade registration into the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="postcode"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        [OperationContract]
        [WebGet(UriTemplate = "/Add?firstName={firstName}&lastName={lastName}&organisation={organisation}" +
                                  "&address1={address1}&address2={address2}&city={city}&state={state}&postcode={postcode}" +
                                  "&country={country}&email={email}&product={product}",
                                  BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void Add(string firstName, string lastName, string organisation, string address1, string address2,
                 string city, string state, string postcode, string country, string email, string product);

        /// <summary>
        /// Add a upgrade registration into the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        [OperationContract]
        [WebGet(UriTemplate = "/AddNew?firstName={firstName}&lastName={lastName}&organisation={organisation}" +
                                  "&country={country}&email={email}&product={product}",
                                  BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void AddNew(string firstName, string lastName, string organisation, string country, string email, string product);

        /// <summary>
        /// Add a upgrade or registration into the database.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="organisation"></param>
        /// <param name="country"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        [OperationContract]
        [WebGet(UriTemplate = "/AddRegistration?firstName={firstName}&lastName={lastName}&organisation={organisation}" +
                                  "&country={country}&email={email}&product={product}&version={version}&platform={platform}&type={type}",
                                  BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void AddRegistration(string firstName, string lastName, string organisation, string country, string email, string product, string version, string platform, string type);

        /// <summary>
        /// Check if a user with a given email address has previously
        /// accepted the licence terms and conditions.
        /// </summary>
        /// <param name="email">Email address.</param>
        [OperationContract]
        [WebGet(UriTemplate = "/IsRegistered?email={email}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool IsRegistered(string email);

        /// <summary>
        /// Subscribe to the mailing list.
        /// </summary>
        /// <param name="email">Email address.</param>
        [OperationContract]
        [WebGet(UriTemplate = "/Subscribe?email={email}",
                                  BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void Subscribe(string email);

        /// <summary>
        /// Unsubscribe to the mailing list.
        /// </summary>
        /// <param name="email">Email address.</param>
        [OperationContract]
        [WebGet(UriTemplate = "/Unsubscribe?email={email}",
                                  BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void Unsubscribe(string email);
    }
}
