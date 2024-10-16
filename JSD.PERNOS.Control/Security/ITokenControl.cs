﻿using JSD.SUNKU.Control.Model;
using System.Collections.Generic;

namespace JSD.SUNKU.Control.Security
{
    public interface ITokenControl
    {
        ResponseContainerModel GenerateJwtToken(Dictionary<string, string> dictTokenParam, Dictionary<string, string> dictClaims);
        string IsTokenJWTValid(string paramkeytoken, string token);
        string GetClaimValueByToken(string paramkeytoken, string tipoclaim, string token);
    }
}
