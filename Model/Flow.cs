using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOA.Model
{
    public class Flow
    {
        public int F_ID { get; set; }
        public string F_Title { get; set; }
        public int F_UrgencyLeavel { get; set; } = 1;
        public int F_U_ID { get; set; }
        public bool F_State { get; set; } = false;
        public string F_FlowInstanceID { get; set; }
        public string F_CurrentInfo { get; set; }
        public DateTime F_CreateTime { get; set; } = DateTime.Now;
        public DateTime F_EndTime { get; set; }
    }
}
