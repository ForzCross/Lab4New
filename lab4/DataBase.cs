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
    /// Класс для работы с базой данных картинок [требуется тестирование]
    /// </summary>
    class ImageDataBase
    {

        string dbPath;        
        SQLiteConnection connection;
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
                execWrite("CREATE DATABASE IF NOT EXISTS ImageDB(id INT PRIMARY KEY autoincrement, "
                        + "name TEXT NOT NULL"
                        + "info TEXT"
                        + "image BLOB NOT NULL)");
            }            
        }
        /// <summary>
        /// Получает один продукт из БД
        /// </summary>
        /// <param name="index">Номер продукта</param>
        /// <param name="pType">Тип возвращаемого продукта</param>
        /// <returns></returns>
        public Product getProduct(int index)
        {
            SQLiteDataReader reader = execRead("SELECT * FROM ImageDB WHERE id = " + index);

            SQLiteBlob blob = reader.GetBlob(3, false);
            int blobSize = blob.GetCount();
            Byte[] imageData = new Byte[blobSize];
            blob.Read(imageData, blobSize, 0);
            Bitmap image = ByteArrayToBitmap(imageData);
            string name = reader.GetString(1);
            string info = reader.GetString(2);

            return new Product(image,name,info);
        }
        /// <summary>
        /// получает все продукты из БД
        /// </summary>
        /// <returns></returns>
        public Product[] getAllImages()
        {
            List<Product> products = new List<Product>();
            Byte[] bitmapBinary;

            SQLiteDataReader reader = execRead("SELECT * FROM ImageDB");
            do
            {
                SQLiteBlob blob = reader.GetBlob(3, false);
                int blobSize = blob.GetCount();
                Byte[] imageData = new Byte[blobSize];
                blob.Read(imageData, blobSize, 0);
                Bitmap image = ByteArrayToBitmap(imageData);
                string name = reader.GetString(1);
                string info = reader.GetString(2);
                products.Add(new Product(image, name, info));
            } while (reader.NextResult());

            return products.ToArray();
        }
        /// <summary>
        /// сохраняет продукт в БД
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int storeProduct(Product product)
        {
            byte[] data = bitmapToByteArray(product.template);
            string sqlquery = "INSERT INTO ImageDB(name, info, image) values(" + product.name + "," + product.info + ")";
            return execWrite(sqlquery);
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
        /// <summary>
        /// Выполняет запросы на чтение из БД
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        SQLiteDataReader execRead(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            return command.ExecuteReader();
        }

        #region bitmapConverters
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
