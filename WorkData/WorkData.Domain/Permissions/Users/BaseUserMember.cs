using System;
using System.Collections.Generic;
using System.Text;
using WorkData.Code.Entities;

namespace WorkData.Domain.Permissions.Users
{
    /// <summary>
    /// BaseUserMember
    /// </summary>
    public class BaseUserMember: BaseEntity, IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// BaseUserId
        /// </summary>
        public string BaseUserId { get; set; }


        #region Relation
        public BaseUser BaseUser { get; set; } 
        #endregion
    }
}
