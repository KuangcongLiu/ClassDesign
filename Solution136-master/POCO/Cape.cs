using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Cape
    {
        public int CapeId { get; set; }

        public int ScheduleId { get; set; }

        public string StudentId { get; set; }

        public int Rate { get; set; }

        public string CapeDescription { get; set; }


        public override string ToString()
        {
            return this.CapeId + "-" + this.ScheduleId + "-" + this.Rate + "-" + this.CapeDescription +"-"+this.StudentId ;
        }
    }
}
