using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python;
using Python.Runtime;

namespace SteelOnion.PythonHost
{
    public class WrapperFactory
    {
        public static WrapperFactory Inst { get; } = new WrapperFactory();

        private bool _ready;

        private WrapperFactory() { _ready = false; }

        public bool LoadPythonRuntime(FileInfo runtime)
        {
            Runtime.PythonDLL = runtime.FullName;
            PythonEngine.Initialize();
            _ready = true;
            return _ready;
        }

        public Wrapper<T> CreateWrapper<T>() where T : WrapperContext, new()
        {
            if (_ready)
            {
                return new Wrapper<T>();
            }
            else
            {
                throw new MissingMemberException("PythonDLL");
            }
        }
    }
}
