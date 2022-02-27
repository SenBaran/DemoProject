//@CodeCopy
//MdStart
using System;
using System.Collections.Generic;
using System.Linq;

namespace QTMusic.ConApp
{
    public partial class Program
    {
        #region Class-Constructors
        static Program()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        #endregion Class-Constructors
        public static void Main(string[] args)
        {
            Console.WriteLine(nameof(QTMusic));
            Console.WriteLine(DateTime.Now);
            BeforeRun();

            AfterRun();
            Console.WriteLine(DateTime.Now);
        }
        static partial void BeforeRun();
        static partial void AfterRun();
    }
}
//MdEnd
