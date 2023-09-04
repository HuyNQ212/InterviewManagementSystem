using AutoMapper;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace InterviewManagementSystem.MVC.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Candidate, CandidateViewModel>();
            CreateMap<CandidateViewModel, Candidate>();
        }
    }
}
