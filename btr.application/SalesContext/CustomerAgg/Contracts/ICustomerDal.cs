﻿using btr.domain.SalesContext.CustomerAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.SalesContext.CustomerAgg.Contracts;

public interface ICustomerDal :
    IInsert<CustomerModel>,
    IUpdate<CustomerModel>,
    IDelete<ICustomerKey>,
    IGetData<CustomerModel, ICustomerKey>,
    IListData<CustomerModel>
{
}