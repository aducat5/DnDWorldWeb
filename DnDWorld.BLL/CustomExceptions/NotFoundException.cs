using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDWorld.BLL.CustomExceptions
{

    [Serializable]
    public class PageNotFoundException : System.Exception
    {
        public PageNotFoundException() { }
        public PageNotFoundException(string message) : base(message) { }
        public PageNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected PageNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
