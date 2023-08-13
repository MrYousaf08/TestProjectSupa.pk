using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupaWebApi.Models
{
    public class NetworkConfiguration
    {
        [Key]
        public string NetworkLabelName { get; set; }
        public string Networkcode { get; set; }
    }
}
