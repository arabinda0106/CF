using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFights;

namespace CodeFightsUnitTestProject
{
    [TestClass]
    public class CF_Interview_Practice_Test
    {
        [TestMethod]
        public void tripletSumTest()
        {
            //arrange

            int x = 0;
            int[] a = new int[] { };

            //act
            CF_Interview_Practice cfipt = new CF_Interview_Practice();

            bool result = cfipt.tripletSum(x, a);

            //assert
        }
    }
}
