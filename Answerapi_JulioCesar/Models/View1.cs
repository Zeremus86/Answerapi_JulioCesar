using System;
using System.Collections.Generic;

namespace Answerapi_JulioCesar.Models
{
    public partial class View1
    {
        public int SenderId { get; set; }
        public string UserName { get; set; }
        public int ReceiverId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string UserRole { get; set; }
    }
}
