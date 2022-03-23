using System;
using System.Collections.Generic;
using System.Text;

namespace WEBAPI_CORE.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
