using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Common.Adapter
{
    public class RabbitStore : IReadWriteStore
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
