using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager.DataValidater
{
    public interface IDataValidater
    {
        bool CheckLength(int length, string? phrase);
        bool CheckLengthAndNumber(int length, string? phrase);
        bool CheckEmail(string? phrase);
        bool CheckNumber(int length, string? phrase);
        int CheckNumberOutInt(string? phrase);
        double CheckNumberOutDouble( string? phrase);
        float CheckNumberOutFloat(string? phrase);
        bool CheckDate(string? phrase);
        DateTime CheckDateOut(string phrase);
        void ErrorMessage(string message);
        void ErrorMessage();
    }
}
