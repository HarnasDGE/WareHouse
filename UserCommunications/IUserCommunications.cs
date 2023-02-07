using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager.UserCommunications
{
    public interface IUserCommunications
    {
        void Menu();
        void MenuBuilder(string tittle);
        void MenuBuilder(string tittle, string options);

    }
}
