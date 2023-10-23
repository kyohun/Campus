using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 상속과_다형성_실습
{
    internal class Place
    {
        string place;
        string campus;
        string lectureroom;
        string library;
        string dormitory;

        public string PLACE()
        {
            return place;
        }
        public string CAMPUS()
        {
            return campus;
        }
        public string LECTUREROOMM()
        {
           return lectureroom;
        }
        public string Library()
        {
            return library;
        }
        public string DORMITORY()
        {
             return dormitory;
        }
    }
}
