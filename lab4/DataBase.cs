using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace lab4
{
    class ImageDataBase
    {
        string dbPath;
        SQLiteConnection connection;
        public ImageDataBase(string dbname)
        {
            dbPath = dbname;
            if (!File.Exists(dbname))
            {
                SQLiteConnection.CreateFile(dbname);
                connection = new SQLiteConnection(string.Format("Data Source={0};", dbname));
            }            
        }
    }
}
