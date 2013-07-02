using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace simpleSQLiteDemoInCSharp
{
    public class clsModel
    {
        protected SQLiteConnection conn;

        public clsModel(SQLiteConnection @conn)
        {
            this.conn = @conn;

            if (this.conn != null && 
                this.conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
        }
    }
}
