using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelOnion.PythonHost
{
    public class WrapperContext
    {
        /// <summary>
        /// 属性交互字典
        /// </summary>
        public Dictionary<string,object> Properties = new Dictionary<string,object>();
        /// <summary>
        /// 方法交互字典
        /// </summary>
        public Dictionary<string,PyObject> Functions = new Dictionary<string,PyObject>();

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="obj"></param>
        public void Print(object obj)
        {
            Console.Write(obj);
        }

        /// <summary>
        /// 打印行
        /// </summary>
        /// <param name="obj"></param>
        public void PrintLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Properties");
            foreach (var item in Properties)
            {
                stringBuilder.AppendLine($"[{item.Key}]:{item.Value}");
            }
            return stringBuilder.ToString();
        }
    }
}
