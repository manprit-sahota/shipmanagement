using AutoMapper;
using Shipmanagement.Service.Contract;

namespace Shipmanagement.Service.Implementation
{
    public class AutoMapperDataMapper : IDataMapper
    {
        private readonly IMapper _mapper;
        public AutoMapperDataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
