using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APSIM.Registration.Portal
{
    /// <summary>
    /// Encapsulates a software package maintained by the APSIM Initiative.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Function which will fetch available versions of this product.
        /// </summary>
        private Func<List<ProductVersion>> GetAvailableVersions;

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Function which will fetch available versions of this product.
        /// </summary>
        public List<ProductVersion> GetVersions()
        {
            return GetAvailableVersions();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="getVersions">Function which will fetch available versions of this product.</param>
        public Product(string name, Func<List<ProductVersion>> getVersions)
        {
            Name = name;
            GetAvailableVersions = getVersions;
        }
    }
}