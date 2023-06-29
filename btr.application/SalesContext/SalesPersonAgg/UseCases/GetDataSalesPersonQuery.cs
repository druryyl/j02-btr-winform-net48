using System.Threading;
using System.Threading.Tasks;
using btr.application.SalesContext.SalesPersonAgg.Workers;
using btr.domain.SalesContext.SalesPersonAgg;
using Dawn;
using Mapster;
using MediatR;

namespace btr.application.SalesContext.SalesPersonAgg.UseCases
{
    public class GetDataSalesPersonQuery : IRequest<GetDataSalesPersonResponse>, ISalesPersonKey
    {
        public GetDataSalesPersonQuery(string id) => SalesPersonId = id;
        public string SalesPersonId { get; }
    }

    public class GetDataSalesPersonResponse
    {
        public string SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }
    }

    public class GetDataSalesPersonHandler : IRequestHandler<GetDataSalesPersonQuery, GetDataSalesPersonResponse>
    {
        private SalesPersonModel _aggRoot = new SalesPersonModel();
        private readonly ISalesPersonBuilder _builder;

        public GetDataSalesPersonHandler(ISalesPersonBuilder builder)
        {
            _builder = builder;
        }

        public Task<GetDataSalesPersonResponse> Handle(GetDataSalesPersonQuery request,
            CancellationToken cancellationToken)
        {
            //  GUARD
            Guard.Argument(() => request).NotNull()
                .Member(x => x.SalesPersonId, y => y.NotEmpty());

            //  BUILD
            _aggRoot = _builder
                .Load(request)
                .Build();

            //  APPLY
            return Task.FromResult(GenResponse());
        }

        private GetDataSalesPersonResponse GenResponse()
        {
            var result = _aggRoot.Adapt<GetDataSalesPersonResponse>();
            return result;
        }
    }
}