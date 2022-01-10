using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCoSample.Application.Responses
{
    public class GetNumberPlateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? FromCache { get; set; }
        public string RemoteAddress { get; set; }
    }
}
