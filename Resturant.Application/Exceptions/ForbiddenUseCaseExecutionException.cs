﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Exceptions
{
    public class ForbiddenUseCaseExecutionException : Exception
    {
        public ForbiddenUseCaseExecutionException(string useCase, string user) :
            base($"User {user} has tried to execute {useCase} without being authorized to do so.")
        {

        }
    }
}
