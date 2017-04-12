using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class SimvolPool
    {
        Simvol[] availSimvols;
        int index;
        int size
        {
            get
            {
                return availSimvols.Count();
            }
        }
        /// <summary>
        /// Создаёт пул символов
        /// </summary>
        /// <param name="size">Размер пула</param>
        public SimvolPool(int size=100)
        {
            availSimvols = new Simvol[size];
            for (int i = 0; i < size; i++)
            {
                
            }
        }
        /// <summary>
        /// Получает символ из пула
        /// </summary>
        /// <returns>Символ или null (если пул кончился)</returns>
        public Simvol createSimvol()
        {
            if(index<size)
            {
                return availSimvols[index++];
            }
            return null;
        }
    }
}
