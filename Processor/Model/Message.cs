using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requester.Model
{
    public class Message
    {
        private int _id;
        private string _details;

        public Message(int id, string details)
        {
            _id = id;
            _details = details;
        }
    }
}
