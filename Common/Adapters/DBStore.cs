using System;
using Common.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Common.Adapter
{
    public class DBStore : IReadWriteStore
    {
        public ActionResult<int> ReadRequestFromStore()
        {
            throw new NotImplementedException();
        }

        public ActionResult<int> WriteRequestToStore()
        {
            throw new NotImplementedException();
        }
    }
}
