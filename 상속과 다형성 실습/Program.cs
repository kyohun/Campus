using EHLib;
using System;

namespace 상속과_다형성_실습
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            CampusLife campusLife = CampusLife.getInstance();
            campusLife.InIt();
            campusLife.Run();
        }
    }
}

