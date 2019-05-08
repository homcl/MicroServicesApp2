using Processor.Model;

namespace Processor.Port
{
    public interface IAmMsgStorageForProcessorToReadAndWriteFrom
    {
        void ReadMsgFromStore();
        void WriteMsgToStore(Message msg);
    }
}
