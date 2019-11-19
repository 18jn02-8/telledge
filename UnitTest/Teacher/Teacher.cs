using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;  //プロジェクトのテスト対象

namespace telledge.Tests.Models
{
    [TestClass]
    public class TeacherTest
    {
        [TestMethod]
        public void SetPassWordTest()
        {
            Teacher teacher = new Teacher();
            teacher.setPassword("password");
        }
        public void TestCreate()
        {
            Student student = new Student();
            student.name = "Test";
            student.mailaddress = "OARO@jec.ac.jp";
            student.is2FA = false;
            student.point = 0;
            student.profileImage = "Gafeokfwaoefa.pix";
            student.skypeId = "Test@skypeid";
            bool test = student.create();
            Assert.IsFalse(test);
        }
    }
}
