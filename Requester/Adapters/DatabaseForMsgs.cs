using System;
using Requester.Model;
using Requester.Port;

namespace Requester.Adapter
{
    public class DatabaseForMsgs : IAmMsgStorageForRequesterToReadAndWriteFrom
    {
        public DatabaseForMsgs()
        {
            Console.WriteLine("DatabaseForMsg object has just been instantiated");
        }
        public Message ReadMsgFromStore()
        {
            Console.WriteLine("**** Inside DATABASEForMsg:ReadMsgFromStore ****");
            return new Message();
        }

        public void WriteMsgToStore(Message msg)
        {
            Console.WriteLine("Inside DatabaseForMsg:WriteMsgToStore");
            throw new NotImplementedException();
        }
    }
}
