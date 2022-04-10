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
        public DateTime SetDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }

        public string FullDate 
        { 
            get
            {
                if(string.IsNullOrEmpty(ExpirationDate.ToString("dd.MM-HH:mm")))
                {
                    return $"{ SetDate.ToString("dd.MM-HH:mm") }";
                }
                return $"{ SetDate.ToString("dd.MM-HH:mm") } - { ExpirationDate.ToString("dd.MM-HH:mm") }";

            }
        }

    }
}
