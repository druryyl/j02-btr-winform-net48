using btr.application.SalesContext.CustomerAgg.Contracts;
using btr.domain.SalesContext.CustomerAgg;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.application.SalesContext.CustomerAgg.Workers;

public interface ICustomerBuilder : INunaBuilder<CustomerModel>
{
    ICustomerBuilder CreateNew();
    ICustomerBuilder Load(ICustomerKey customerKey);
    ICustomerBuilder Name(string name);
}
public class CustomerBuilder : ICustomerBuilder
{
    private CustomerModel _aggRoot = new();
    private readonly ICustomerDal _customerDal;

    public CustomerBuilder(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public CustomerModel Build()
    {
        _aggRoot.RemoveNull();
        return _aggRoot;
    }

    public ICustomerBuilder CreateNew()
    {
        _aggRoot = new CustomerModel
        {
            CustomerName = string.Empty,
            CustomerId = string.Empty
        };
        return this;
    }

    public ICustomerBuilder Load(ICustomerKey customerKey)
    {
        _aggRoot = _customerDal.GetData(customerKey)
            ?? throw new KeyNotFoundException($"CustomerId not found ({customerKey.CustomerId})");
        return this;
    }

    public ICustomerBuilder Name(string name)
    {
        _aggRoot.CustomerName = name;
        return this;
    }
}