using Minder.DTO;
using Minder.Enum;
using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class PassionService : IPassionService
    {
        private readonly IPassionRepository _passionRepository;

        public PassionService(IPassionRepository passionRepository)
        {
            _passionRepository = passionRepository;
        }

        public BaseResponse<Passion> Create(Passion passion)
        {
            BaseResponse<Passion> response = new BaseResponse<Passion>();
            Passion createdPassion = _passionRepository.GetByName(passion.Name);
            if (createdPassion is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.ExistData;
                return response;
            }
            _passionRepository.Create(passion);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = passion;
            return response;
        }

        public BaseResponse<string> Delete(Passion passion)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            Passion deletedPassion = _passionRepository.GetByName(passion.Name);
            if (deletedPassion is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.DataNotFound;
                return response;
            }
            _passionRepository.Delete(deletedPassion);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }

        public BaseResponse<List<Passion>> GetAll()
        {
            BaseResponse<List<Passion>> response = new BaseResponse<List<Passion>>();
            try
            {
                response.Data = _passionRepository.GetAll();
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.DataNotFound;
                return response;
            }
        }

        public BaseResponse<Passion> GetByName(string name)
        {
            BaseResponse<Passion> response = new BaseResponse<Passion>();
            try
            {
                response.Data = _passionRepository.GetByName(name);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.DataNotFound;
                return response;
            }
        }

        public BaseResponse<Passion> Update(Passion passion)
        {
            BaseResponse<Passion> response = new BaseResponse<Passion>();
            Passion updatedPassion = _passionRepository.GetByName(passion.Name);
            if (updatedPassion is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.DataNotFound;
                return response;
            }
            _passionRepository.Delete(updatedPassion);
            response.Data = passion;
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }
    }
}