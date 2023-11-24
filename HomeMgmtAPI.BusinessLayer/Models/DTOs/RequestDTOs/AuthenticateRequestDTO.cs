using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Models.DTOs.RequestDTOs
{
    public class AuthenticateRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
