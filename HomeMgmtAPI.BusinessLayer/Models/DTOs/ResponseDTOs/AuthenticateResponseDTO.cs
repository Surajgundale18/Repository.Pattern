﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtAPI.BusinessLayer.Models.DTOs.ResponseDTOs
{
    public class AuthenticateResponseDTO
    {
        public bool IsAuthenticated { get; set; }
        public string AccessToken { get; set; }
    }
}
