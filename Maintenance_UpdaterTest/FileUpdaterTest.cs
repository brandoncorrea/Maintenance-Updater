using System;
using System.Collections.Generic;
using System.Linq;
using Maintenance_Updater.Editor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maintenance_UpdaterTest
{
    [TestClass]
    public class FileUpdaterTest
    {

        private static string Line_SK = "SK4  00000000708000004141500163M000400000301PUBLIX MILK WHOLE RED GA      011000101123100000000~00000000~~~~~~~~30~A001411011101~~~~~~~~~~~~~~00140~00000052011AD01EACH~~~~~~~~~~~~~~~~~~~00001~~~~~~~~02101~~~~~~~~~009120090904~~~~~~~~~~~";
        private string Line_IT = "IT4  00000000708000004141500163N0PUBLIX MILK WHOLE ~~OZ00128000128 OZ  000100100020003700100037001000370020000000000~~0~~~~~~~~~~1110003691             0000000~~~000~~0~~~~~~~~0~00000000~~~~0~~~~~~01~10000000012~~~~~~~~~~~~0~~~~~~~~~~~~~~~~~~~~~~~000000~~~~~~~~~~~~~~~~~";
        private string Line_PK = "PK4  00000000708000004141500163I000400011000001300000130000038000";
        private string Line_IL = "IL4  000000007080000041415001630RL L  003~~~~~~~~~~~~~LW WHSE   04~~~~~~~~~~~~~~~~~~~~~";
        private string Line_SP = "SP4  00000000708000004141500163I00040000030100000000000001001000100101600~~~~~~~~000509990005";

        [TestMethod]
        public void GetHDLine()
        {
            string line = FileUpdater.GetHDLine();
            Assert.AreEqual(line.Length, 101);
            Assert.AreEqual(line.Substring(0, 11), "HD1        ");
        }

        [TestMethod]
        public void GetItemCode()
        {
            string expected = "0004141500163";

            Assert.AreEqual(expected, FileUpdater.GetItemCode(Line_SK), "SK Failed");
            Assert.AreEqual(expected, FileUpdater.GetItemCode(Line_IT), "IT Failed");
            Assert.AreEqual(expected, FileUpdater.GetItemCode(Line_PK), "PK Failed");
            Assert.AreEqual(expected, FileUpdater.GetItemCode(Line_IL), "IL Failed");
            Assert.AreEqual(expected, FileUpdater.GetItemCode(Line_SP), "SP Failed");
        }

        [TestMethod]
        public void GetSkuCode_SK()
        {
            string expected = "0000000070800";
            string actual = FileUpdater.GetSkuCode(Line_SK);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSkuCode_IT()
        {
            string expected = "0000000070800";
            string actual = FileUpdater.GetSkuCode(Line_IT);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSkuCode_PK()
        {
            string expected = "0000000070800";
            string actual = FileUpdater.GetSkuCode(Line_PK);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSkuCode_IL()
        {
            string expected = "0000000070800";
            string actual = FileUpdater.GetSkuCode(Line_IL);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSkuCode_SP()
        {
            string expected = "0000000070800";
            string actual = FileUpdater.GetSkuCode(Line_SP);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsComment()
        {
            Assert.IsTrue(FileUpdater.IsComment("###"), "'###' Failed");
            Assert.IsTrue(FileUpdater.IsComment("##"), "'##' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#"), "'#' Failed");
            Assert.IsTrue(FileUpdater.IsComment("# "), "'# ' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#  "), "'#  ' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#SK"), "'#SK' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#IT"), "'#IT' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#PK"), "'#PK' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#IL"), "'#IL' Failed");
            Assert.IsTrue(FileUpdater.IsComment("#SP"), "'#SP' Failed");

            Assert.IsFalse(FileUpdater.IsComment(""), "'' Failed");
            Assert.IsFalse(FileUpdater.IsComment(null), "'null' Failed");
            Assert.IsFalse(FileUpdater.IsComment("SK"), "'SK' Failed");
            Assert.IsFalse(FileUpdater.IsComment("IT"), "'IT' Failed");
            Assert.IsFalse(FileUpdater.IsComment("PK"), "'PK' Failed");
            Assert.IsFalse(FileUpdater.IsComment("IL"), "'IL' Failed");
            Assert.IsFalse(FileUpdater.IsComment("SP"), "'SP' Failed");
            Assert.IsFalse(FileUpdater.IsComment(" #"), "' #' Failed");
        }

        [TestMethod]
        public void GetLineId()
        {
            Assert.AreEqual(FileUpdater.GetLineId(Line_SK), "SK", "SK Failed");
            Assert.AreEqual(FileUpdater.GetLineId(Line_IT), "IT", "IT Failed");
            Assert.AreEqual(FileUpdater.GetLineId(Line_PK), "PK", "PK Failed");
            Assert.AreEqual(FileUpdater.GetLineId(Line_IL), "IL", "IL Failed");
            Assert.AreEqual(FileUpdater.GetLineId(Line_SP), "SP", "SP Failed");
        }

        [TestMethod]
        public void GetItemLines()
        {
            string[] lines =
            {
                "HD1",
                "#",
                "#",
                "FA",
                "#",
                "SK",
                "IT"
            };

            IEnumerable<string> actual = FileUpdater.GetItemLines(lines);
            IEnumerable<string> expected = lines.Skip(4);
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}
