using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class BFFUserInfoDTO
    {
        public static readonly BFFUserInfoDTO Anonymous = new BFFUserInfoDTO();
        public List<ClaimValueDTO> Claims { get; set; }
    }
}
