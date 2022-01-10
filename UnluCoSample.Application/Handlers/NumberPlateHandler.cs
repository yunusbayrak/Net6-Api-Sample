using Mapster;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoSample.Application.Commands;
using UnluCoSample.Application.Queries;
using UnluCoSample.Application.Responses;
using UnluCoSample.Domain.Repositories;

namespace UnluCoSample.Application.Handlers
{
    public class NumberPlateHandler : IRequestHandler<GetNumberPlateByIdQuery, GetNumberPlateResponse>, IRequestHandler<SeedDbCommand, Unit>
    {
        private readonly INumberPlateRepository _numberPlateRepository;
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger<NumberPlateHandler> _logger;
        public NumberPlateHandler(INumberPlateRepository numberPlateRepository, IDistributedCache distributedCache, ILogger<NumberPlateHandler> logger)
        {
            _numberPlateRepository = numberPlateRepository;
            _distributedCache = distributedCache;
            _logger = logger;
        }
        public async Task<GetNumberPlateResponse> Handle(GetNumberPlateByIdQuery request, CancellationToken cancellationToken)
        {
            var fromCache = await _distributedCache.GetAsync(request.Id.ToString());
            if (fromCache != null)
            {
                var json = Encoding.UTF8.GetString(fromCache);
                var numberplate = JsonConvert.DeserializeObject<GetNumberPlateResponse>(json);
                if (numberplate != null)
                {
                    numberplate.FromCache = true;
                    return numberplate;
                }
            }
            var numberPlate = await _numberPlateRepository.GetById(request.Id);
            if (numberPlate == null)
            {
                return null;
            }
                var numberPlateCache = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(numberPlate));
                var options = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromDays(1))
                        .SetAbsoluteExpiration(DateTime.Now.AddDays(10));
                await _distributedCache.SetAsync(request.Id.ToString(), numberPlateCache, options);
            
            var res = numberPlate.Adapt<GetNumberPlateResponse>();
            res.FromCache = false;
            return res;
        }

        public async Task<Unit> Handle(SeedDbCommand request, CancellationToken cancellationToken)
        {
            await _numberPlateRepository.SeedDb();
            return Unit.Value;
        }
    }
}
