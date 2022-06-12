using FluentValidation;
using Resturant.Application;
using Resturant.Application.UseCases.Queries;
using Resturant.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Implementation.UseCases.Queries
{
    public class GetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private IUseCaseLogger _logger;
        private SearchUseCaseLogsValidator _validator;

        public GetUseCaseLogsQuery(IUseCaseLogger logger, SearchUseCaseLogsValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Search use case logs";


        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch search)
        {
            _validator.ValidateAndThrow(search);
            return _logger.GetLogs(search);
        }
    }
}
