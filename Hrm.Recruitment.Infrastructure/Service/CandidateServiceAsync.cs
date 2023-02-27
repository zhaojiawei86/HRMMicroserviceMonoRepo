using System;
using Hrm.Recruitment.ApplicationCore.Contract.Service;
using Hrm.Recruitment.ApplicationCore.Entity;
using Hrm.Recruitment.ApplicationCore.Model.Request;
using Hrm.Recruitment.ApplicationCore.Model.Response;
using Hrm.Recruitment.Infrastructure.Repository;

namespace Hrm.Recruitment.Infrastructure.Service
{
	public class CandidateServiceAsync : ICandidateServiceAsync
	{
        private readonly CandidateRepositoryAsync candidateRepsoitoryAsync;

        public CandidateServiceAsync(CandidateRepositoryAsync _candidateRepsoitoryAsync)
		{
            candidateRepsoitoryAsync = _candidateRepsoitoryAsync;
        }

        public Task<int> DeleteAsync(int id)
        {
            return candidateRepsoitoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllAsync()
        {
            var result = await candidateRepsoitoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new CandidateResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    currentAddress = model.currentAddress,
                    ResumeUrl = model.ResumeUrl
                });
            }
            return null;
    }

        public async Task<CandidateResponseModel> GetByIdAsync(int id)
        {
            var model = await candidateRepsoitoryAsync.GetByIdAsync(id);
            if (model != null)
            {
                return new CandidateResponseModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    currentAddress = model.currentAddress,
                    ResumeUrl = model.ResumeUrl
                };
            }
            return null;
        }

        public Task<int> InsertAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Email = model.Email,
                currentAddress = model.currentAddress,
                ResumeUrl = model.ResumeUrl
            };
            return candidateRepsoitoryAsync.InsertAsync(candidate);
        }

        public async Task<int> UpdateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Email = model.Email,
                currentAddress = model.currentAddress,
                ResumeUrl = model.ResumeUrl
            };
            return await candidateRepsoitoryAsync.UpdateAsync(candidate);
        }
    }
}

