
using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Requests
{
    public class InsertCodeSequenceReq
    {
        public InsertCodeSequenceReq(CodeSequence codesequence)
        {
            CodeSequence = codesequence;
        }

        public CodeSequence CodeSequence { get; }
    }
}
