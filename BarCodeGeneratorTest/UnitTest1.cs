using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarCodeGenerator;
using System.Drawing;
using System.Collections.Generic;

namespace BarCodeGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Save()
        {
            BarCode.Save("4141511891", "APRICOT PEACH", "test.bmp");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Draw()
        {
            Dictionary<string, string> items = new Dictionary<string, string>()
            {
                { "4141500123", "PUBLIX SPAGHETTI" },
                { "4141500124", "PUBLIX SPAGHETTI" },
                { "4141500125", "PUBLIX SPAGHETTI" },
                { "4141500126", "PUBLIX SPAGHETTI" },
                { "4141500127", "PUBLIX SPAGHETTI" },
                { "4141500128", "PUBLIX SPAGHETTI" },
                { "4141500129", "PUBLIX SPAGHETTI" },
                { "4141500130", "PUBLIX SPAGHETTI" },
                { "4141500131", "PUBLIX SPAGHETTI" },
                { "4141500132", "PUBLIX SPAGHETTI" },
                { "4141500133", "PUBLIX SPAGHETTI" },
                { "4141500134", "PUBLIX SPAGHETTI" },
                { "4141500135", "PUBLIX SPAGHETTI" },
                { "4141500136", "PUBLIX SPAGHETTI" },
                { "4141500137", "PUBLIX SPAGHETTI" },
                { "4141500138", "PUBLIX SPAGHETTI" },
                { "4141500139", "PUBLIX SPAGHETTI" },
                { "4141500140", "PUBLIX SPAGHETTI" },
                { "4141500141", "PUBLIX SPAGHETTI" },
                { "4141500142", "PUBLIX SPAGHETTI" },
                { "4141500143", "PUBLIX SPAGHETTI" },
                { "4141500144", "PUBLIX SPAGHETTI" },
            };

            BarCode.Save(items, "test1.bmp");

            Assert.IsTrue(true);
        }
    }
}
