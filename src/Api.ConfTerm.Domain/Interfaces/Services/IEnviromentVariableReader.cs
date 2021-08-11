using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ConfTerm.Domain.Interfaces.Services
{
    public interface IEnviromentVariableReader
    {
        public string DatabaseUrl { get; }
    }
}
