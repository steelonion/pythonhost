using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SteelOnion.PythonHost
{
    public class WrapperContext
    {
        /// <summary>
        /// 是否将脚本中的方法自动绑定到上下文
        /// </summary>
        public bool AutoBind { get; set; }
        /// <summary>
        /// 属性交互字典
        /// </summary>
        public Dictionary<string,object> Properties = new Dictionary<string,object>();
        /// <summary>
        /// 方法交互字典
        /// </summary>
        public Dictionary<string,List<PyObject>> Functions = new Dictionary<string, List<PyObject>>();

        public void Bind(string? name, PyObject obj)
        {
            if (name == null) return;
            if (!Functions.ContainsKey(name))
            {
                Functions.Add(name, new List<PyObject>());
            }
            Functions[name].Add(obj);
        }

        /// <summary>
        /// 调用指定名称的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        protected void Invoke(string name, params object[] args) 
        {
            if (Functions.ContainsKey(name))
            {
                foreach (PyObject obj in Functions[name])
                {
                    obj.Invoke(args.Select(x => x.ToPython()).ToArray());
                }
            }
        }

        /// <summary>
        /// 调用同名方法
        /// </summary>
        protected void AutoInvoke([CallerMemberName] string name = "", params object[] args)
        {
            if (Functions.ContainsKey(name))
            {
                foreach (PyObject obj in Functions[name])
                {
                    obj.Invoke(args.Select(x => x.ToPython()).ToArray());
                }
            }
        }

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
