﻿using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManegement.Aplication.Exeptions
{
    public class ValidationException : ApplicationException
    {
        public List<string>  Errors{ get; set; } = new List<string>();  

        public ValidationException(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
