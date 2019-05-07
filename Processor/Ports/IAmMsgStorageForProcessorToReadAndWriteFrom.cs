﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Requester.Model;

namespace Requester.Port
{
    public interface IAmMsgStorageForProcessorToReadAndWriteFrom
    {
        Message ReadMsgFromStore(); // includes polling storage
        void WriteMsgToStore(Message msg);
    }
}
