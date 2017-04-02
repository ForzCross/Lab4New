using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;

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
                connection.Open();

            }            
        }

        int execWrite(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            return command.ExecuteNonQuery();           
        }
        SQLiteDataReader execRead(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            return command.ExecuteReader();
        }
        public bool storeImage(Bitmap img)
        {
            byte[] data = bitmapToByteArray(img);
            //string sqlquery = "SELECT * FROM "
            //execWrite()
            return true;            
        }

        public static byte[] bitmapToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}
