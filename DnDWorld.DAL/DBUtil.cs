using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDWorld.DAL
{
    public static class DBUtil
    {
        public dynamic Execute(string storedProcedure, Dictionary<string, string> parameters)
        {
            string connstr = ConfigurationManager.ConnectionStrings["DnDWorldDBLocal"].ToString();
            SqlConnection conn = new SqlConnection(connstr);

            SqlCommand command = new SqlCommand(storedProcedure, conn);
            if (parameters.Count > 0)
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            else
            {
                return null;
            }


        }
    }
}
