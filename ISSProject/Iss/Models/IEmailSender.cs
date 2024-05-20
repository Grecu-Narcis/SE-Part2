using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IEmailSender
    {
        Task SendDocEmailAsync(string recipient, string filename);
    }
}
