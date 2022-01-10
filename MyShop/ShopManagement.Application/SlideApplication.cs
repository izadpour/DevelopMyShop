using System.Collections.Generic;
using _01_Framework.Application;
using ShopManagement.Application.Contracts.SlideAgg;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly  IFileUploader _fileUploader;
        public SlideApplication(ISlideRepository slideRepository,IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            OperationResult operationResult = new OperationResult();
            var fileName = _fileUploader.Upload(command.Picture,"Slide");
            Slide slide = new Slide(fileName, command.PictureTitle, command.PictureAlt, command.Heading,
                command.PictureTitle,command.Text, command.BtnText,command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            OperationResult operationResult = new OperationResult();
            Slide slide = _slideRepository.Get(command.Id);
            if (!slide.Equals(null))
            {
                var fileName = _fileUploader.Upload(command.Picture,"Slide");
                slide.Edit(fileName, command.PictureTitle, command.PictureAlt, command.Heading, command.Title,
                command.Title   , command.BtnText,command.Link);
                _slideRepository.SaveChanges();
                return operationResult.Succedded();
            }
            else
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            var s= _slideRepository.GetList();
            return s;
        }

        public OperationResult Remove(long id)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (!slide.Equals(null))
            {
                slide.Remove();
                _slideRepository.SaveChanges();
                return operationResult.Succedded();
            }
            else
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }
        }

        public OperationResult Restore(long id)
        {
            OperationResult operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (!slide.Equals(null))
            {
                slide.Restore();
                _slideRepository.SaveChanges();
                return operationResult.Succedded();
            }
            else
            {
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            }
        }
    }
}