using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickFixers.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFixers.Tests.Utilities
{
    [TestClass]
    public class UtilitiesTest
    {
        [DataTestMethod]
        [DataRow("password123")]
        [DataRow("Password123")]
        [DataRow("PassWord!123")]
        [DataRow("HashMyPass!456")]
        [DataRow("IClient123!")]
        [DataRow("IServicePro123!")]
        [DataRow("123")]
        [DataRow("1234")]
        [TestMethod] public void TestHash(string passwordString)
        {
            Console.WriteLine(passwordString);
            string expectedHash = Validations.ToEncryptedString(passwordString);
            Console.WriteLine(expectedHash);
            string resultHash = Validations.ToEncryptedString(passwordString);
            Console.WriteLine(resultHash);

            Assert.AreEqual(expectedHash, expectedHash);
        }

 

         
    }
}
