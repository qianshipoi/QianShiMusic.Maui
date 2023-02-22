using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QianShiMusic.IServices
{
    public interface INotificationService
    {

        Task Show(string message);

    }
}
