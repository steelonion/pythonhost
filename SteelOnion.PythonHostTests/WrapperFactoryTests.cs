using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteelOnion.PythonHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelOnion.PythonHost.Tests
{
    [TestClass()]
    public class WrapperFactoryTests
    {
        [TestMethod()]
        public void LoadPythonRuntimeTest()
        {
            WrapperFactory.Inst.LoadPythonRuntime(new FileInfo(@"C:\Program Files\Python311\python311.dll"));
        }

        [TestMethod()]
        public void CreateWrapperTest()
        {
            LoadPythonRuntimeTest();
            var wrapper= WrapperFactory.Inst.CreateWrapper<WrapperContext>();
            wrapper.Load(new FileInfo("test.py"));

            Console.WriteLine(wrapper.Context);
            wrapper.Dispose();
        }
    }
}