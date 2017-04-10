using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Collections;

namespace lab4
{
    /// <summary>
    /// Класс для работы с базой данных картинок
    /// </summary>
    class ImageDataBase
    {
        string dbPath;        
        SQLiteConnection connection;
        ConcreteFactory factory = new ConcreteFactory();
        /// <summary>
        /// Создаёт подключение к БД
        /// </summary>
        /// <param name="dbname">имя БД</param>
        public ImageDataBase(string dbname = "ImageDB")
        {
           
            dbPath = dbname;
            if (!File.Exists(dbname))
            {
                SQLiteConnection.CreateFile(dbname);
                connection = new SQLiteConnection(string.Format("Data Source={0};", dbname));
                connection.Open();
                execWrite("CREATE DATABASE IF NOT EXISTS ImageDB(id INT PRIMARY KEY NOT NULL, "
                        + "name TEXT NOT NULL"
                        + "info TEXT NOT NULL"
                        + "image BLOB NOT NULL)");
            }            
        }
        public void getImageData(int index, AbstractSimvol simvol)
        {
            SQLiteDataReader reader = execRead("SELECT * FROM ImageDB WHERE id = " + index);            
        }
        /// <summary>
        /// Выполняет запрос не ожидая ответа от бд
        /// </summary>
        /// <param name="query">запрос, выполняемый на БД</param>
        /// <returns>количество затронутых строк</returns>
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

        public Simvol[] getAllImages()
        {
            List<Simvol> simvols = new List<Simvol>();
            Simvol tmpSimvol;
            Byte[] bitmapBinary;
            
            SQLiteDataReader reader = execRead("SELECT * FROM ImageDB");
            do
            {
                tmpSimvol = (Simvol)factory.CreateSimvol();
               // GetBy
               // reader.GetBytes(3,0,bitmapBinary,0,)
                //tmpSimvol.SetInfo(reader.GetString(1), reader.GetString(2), ByteArrayToBitmap(reader.Get));  
            } while (reader.NextResult());



            return null;
        }
        #region 
        static byte[] bitmapToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        static Bitmap ByteArrayToBitmap(byte[] imgBinary)
        {
            ImageConverter converter = new ImageConverter();
            return (Bitmap)converter.ConvertTo(imgBinary,typeof(Bitmap));
        }
        #endregion
    }
}
