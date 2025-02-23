﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VinculacionBackend.CostumeDataNotations
{
    public class ValidDomainAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            var email=value.ToString();
            Regex validDomain = new Regex(@"^[a-z0-9]+[.]?[a-z0-9]+@unitec\.edu$");
            return validDomain.Match(email).Success;
        }

    }
}
