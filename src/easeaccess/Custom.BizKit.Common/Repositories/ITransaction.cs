using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Repositories
{
    /// <summary>
    /// Unit Of Work Pattern ITransaction
    /// http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
    /// </summary>
    public interface ITransaction
    {
        /// <summary>
        /// Make changes to be ignored.
        /// </summary>
        void IgnoreChanges();

        /// <summary>
        /// Unit of Work pattern save changes.
        /// </summary>
        /// <exception cref="RepositiryException">One or more conflicts found while saving.</exception>
        /// <exception cref="SystemException">An internal error has occured.</exception>
        void SaveChanges();
    }
}
