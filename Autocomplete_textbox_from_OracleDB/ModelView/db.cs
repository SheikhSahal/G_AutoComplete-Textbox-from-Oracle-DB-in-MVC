using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace AutoComplete_Textbox_From_OracleDB.ModelView
{
    
    public class db
    {
        string oradb = "Data source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.3.243)(PORT = 1521))(CONNECT_DATA =(SID = PSLUAT)));User ID= psl; Password= psl";

        public DataSet GetName(string prefix)
        {
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            
            cmd.CommandText = "Select e.empno,e.ename From emp e Where e.ename Like '%' ||:prefix || '%'";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("prefix", prefix));
            
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds;  
        }
    }
}