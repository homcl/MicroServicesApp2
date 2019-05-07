using Microsoft.AspNetCore.Mvc;

namespace Common.Ports
{
    public interface IReadWriteStore
    {
        // Return status code
        ActionResult<int> ReadRequestFromStore();
        ActionResult<int> WriteRequestToStore();
    }
}
