using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Permissions : IRowLightMSSQL
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public void Init(SqlDataReader readerSQL, string[] columnList = null)
        {

            Id = CommandMSSQL.GetValue<int>(readerSQL, "PermissionId", columnList);
            GroupId = CommandMSSQL.GetValue<int>(readerSQL, "GroupId", columnList);
            GroupName = CommandMSSQL.GetValue<string>(readerSQL, "GroupName", columnList);
            GroupDescription = CommandMSSQL.GetValue<string>(readerSQL, "GroupDescription", columnList);
            RoleId = CommandMSSQL.GetValue<int>(readerSQL, "RoleId", columnList);
            RoleName = CommandMSSQL.GetValue<string>(readerSQL, "RoleName", columnList);
            RoleDescription = CommandMSSQL.GetValue<string>(readerSQL, "RoleDescription", columnList);
        }
    }
}
