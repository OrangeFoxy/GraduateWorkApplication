using GraduateWorkApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateWorkApplication.Views.Controls
{
    
    public class MessageInfo
    {
        public enum TypeOfMessage { RemoveEnrollee, RemoveGroup }
        public string Message { get; private set; }
        public TypeOfMessage Action { get; private set; }

        public MessageInfo(TypeOfMessage Action, string Message)
        {
            this.Action = Action;
            this.Message = Message;
        }
    }
}
