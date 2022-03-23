using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.DTOs.Email;

namespace WEBAPI_CORE.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
