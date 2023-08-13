using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupaApp.Services.Interfaces
{
    public interface IWiFiService
    {
        Task<string> GetWifiSSIDAsync();
    }
}
