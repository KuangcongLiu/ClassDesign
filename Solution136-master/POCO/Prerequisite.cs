using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Prerequisite
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int PrerequisiteId { get; set; }



        public override string ToString()
        {
            return this.Id + "-" + this.CourseId + "-" + this.PrerequisiteId;
        }
    }
}
