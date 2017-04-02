using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab4
{
    /// <summary>
    /// Этот класс используется для хранения основных данных и состояния
    /// приложения, паттерн [singleton]
    /// </summary>
    class AppData
    {
        private static AppData instance;
        public static Image image;

        protected AppData()
        {
        }
        public static AppData getInstance()
        {
            if (instance == null)
                instance = new AppData();

            return instance;
        }


    }
}
