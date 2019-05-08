using Processor.Port;
using System;
using Processor.Model;

namespace Processor.Adapter
{
    public class DatabaseForMsgs : IAmMsgStorageForProcessorToReadAndWriteFrom
    {
        public void ReadMsgFromStore()
        {
            throw new NotImplementedException();
        }

        public void WriteMsgToStore(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
