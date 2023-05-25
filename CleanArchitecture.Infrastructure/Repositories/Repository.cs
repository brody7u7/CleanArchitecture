using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public abstract class Repository
    {
        private readonly Core.Configuration.ApiSettings _apiSettings;
        private readonly Core.Interfaces.ICurrentUserService _currentUserService;
        private readonly ILogger _logger;

        public Repository(IOptions<Core.Configuration.ApiSettings> options,
                          Core.Interfaces.ICurrentUserService currentUserService,
                          ILogger logger)
        {
            _apiSettings = options.Value;
            _currentUserService = currentUserService;
            _logger = logger;
        }

        protected Core.Configuration.ApiSettings ApiSettings => _apiSettings;
        protected Core.Interfaces.ICurrentUserService CurrentUserService => _currentUserService;
        protected ILogger Logger => _logger;
    }
}
