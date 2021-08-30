using System.Collections.Generic;
using _0_Framework.Application;
using _01_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            OperationResult operationResult = new OperationResult();
            if (_customerDiscountRepository.Exists(x =>
                x.ProductId.Equals(command.ProductId) && x.DiscountRate.Equals(command.DiscountRate)))
            {
                operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(), command.Reason);
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            OperationResult operationResult = new OperationResult();
            if (_customerDiscountRepository.Exists(x => x.ProductId.Equals
                (command.ProductId) && x.DiscountRate.Equals(command.DiscountRate) && x.Id != command.Id))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            var customerDiscount = _customerDiscountRepository.Get(command.Id);
            if (customerDiscount.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }
            customerDiscount.Edit(command.ProductId, command.DiscountRate, command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(), command.Reason);
            _customerDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {

           return _customerDiscountRepository.GetDetails(id);
            
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}