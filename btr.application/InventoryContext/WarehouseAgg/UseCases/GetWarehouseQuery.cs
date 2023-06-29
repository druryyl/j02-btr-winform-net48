﻿using btr.application.InventoryContext.WarehouseAgg.Workers;
using btr.domain.InventoryContext.WarehouseAgg;
using Dawn;
using Mapster;
using MediatR;

namespace btr.application.InventoryContext.WarehouseAgg.UseCases;

public record GetWarehouseQuery(string WarehouseId) 
    : IRequest<GetWarehouseResponse>, IWarehouseKey;

public class GetWarehouseResponse
{
    public string WarehouseId { get; set; }
    public string WarehouseName { get; set; }
}

public class GetWarehouseHandler : IRequestHandler<GetWarehouseQuery, GetWarehouseResponse>
{
    private WarehouseModel _aggRoot = new();
    private readonly IWarehouseBuilder _builder;

    public GetWarehouseHandler(IWarehouseBuilder builder)
    {
        _builder = builder;
    }

    public Task<GetWarehouseResponse> Handle(GetWarehouseQuery request, CancellationToken cancellationToken)
    {
        //  GUARD
        Guard.Argument(() => request).NotNull()
            .Member(x => x.WarehouseId, y => y.NotEmpty());
        
        //  BUILD
        _aggRoot = _builder
            .Load(request)
            .Build();
        
        //  APPLY
        return Task.FromResult(GenResponse());
    }
    
    private GetWarehouseResponse GenResponse()
    {
        var result = _aggRoot.Adapt<GetWarehouseResponse>();
        return result;
    }
}