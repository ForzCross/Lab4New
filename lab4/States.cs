using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public interface State
    {
        String Working();

    }

    public class ExpertState : State
    {
        public String Working()
        {
            return "мы в режиме эксперта"; 
        }

    }

    public class UserState : State
    {
        public String Working()
        {
            return "мы в режиме пользователя";
        }

    }



}
