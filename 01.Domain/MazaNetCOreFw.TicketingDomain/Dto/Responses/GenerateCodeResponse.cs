using MazaNetCOreFw.BaseDomain.Common;

using MazaNetCOreFw.TicketingDomain.Dto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.TicketingDomain.Dto.Responses
{
    public class GenerateCodeResponse : UseCaseResponseMessage
    {
        public GenerateCodeResponse(string code,
                bool status,
                string message = "") : base(status, message: message)
        {
            Code = code;
        }
        [JsonConstructor]
        public GenerateCodeResponse(bool status,
                                string message = "") : this(null, status, message: message)
        {
        }
        public string Code { get; set; }
    }
}
