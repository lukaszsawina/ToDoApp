using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string SetDate { get; set; }
        public string ExpirationDate { get; set; }
        public string Status { get; set; }

        public string FullDate 
        { 
            get
            {
                if(string.IsNullOrEmpty(ExpirationDate))
                {
                    return $"{ SetDate }";
                }
                return $"{ SetDate } - { ExpirationDate }";

            }
        }

    }
}
