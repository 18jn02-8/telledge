﻿using System;
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
            Teacher.setPassword("PassWord");
        }
    }
}
