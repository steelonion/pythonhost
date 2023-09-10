﻿using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelOnion.PythonHost
{
    public class Wrapper<T>:IDisposable  where T : WrapperContext, new()
    {
        /// <summary>
        /// 上下文实例
        /// </summary>
        public T Context { get; }
        internal Wrapper()
        {
            Context = new T();
        }
        /// <summary>
        /// 当前脚本文件
        /// </summary>
        public FileInfo? Script { get; private set; }

        private PyModule? _scope;


        public void Load(FileInfo script)
        {
            //清空当前状态
            Dispose();

            //载入脚本
            Script = script;
            using (Py.GIL())
            {
                _scope = Py.CreateScope();
                _scope.SetAttr("context", Context.ToPython());
                _scope.Exec(File.ReadAllText(Script.FullName));
            }
        }

        public void Dispose()
        {
            Script = null;
            _scope?.Dispose();
        }
    }
}
