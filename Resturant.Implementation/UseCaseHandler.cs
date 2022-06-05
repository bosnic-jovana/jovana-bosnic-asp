using Resturant.Application.UseCases;
using Resturant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation
{
    public class UseCaseHandler
    {
 
        private IApplicationUser _user;

        public UseCaseHandler(IApplicationUser user)
        {
            _user = user;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                command.Execute(data);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                var response = query.Execute(data);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
