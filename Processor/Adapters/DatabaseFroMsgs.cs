using System;
using Requester.Model;
using Requester.Port;

namespace Requester.Adapter
{
    public class DatabaseForMsgs : IAmMsgStorageForProcessorToReadAndWriteFrom
    {
        public Message ReadMsgFromStore()
        {
            throw new NotImplementedException();
            return ReadMsgFromStore();
        }

        public void WriteMsgToStore(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
