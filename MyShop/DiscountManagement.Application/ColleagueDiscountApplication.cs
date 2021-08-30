using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using _01_Framework.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscountAgg;
using DiscountManagement.Domain.ColleaugeDiscountAgg;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            OperationResult operationResult = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x =>
                x.ProductId.Equals(command.ProductId) && x.DiscountRate.Equals(command.DiscountRate)))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            ColleagueDiscount colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Create(colleagueDiscount);
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            OperationResult operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleagueDiscount.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_colleagueDiscountRepository.Exists(x =>
                x.ProductId.Equals(command.ProductId) && x.DiscountRate.Equals(command.DiscountRate) &&
                x.ProductId != colleagueDiscount.ProductId))
            {
                return operationResult.Failed(ApplicationMessages.DuplicateRecord);
            }

            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var colleagueDiscout = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscout.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            colleagueDiscout.Remove();
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount.Equals(null))
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }

            colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChanges();
            return operationResult.Succedded();
        }
    }
}