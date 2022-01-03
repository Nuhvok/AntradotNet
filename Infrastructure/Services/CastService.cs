using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastModel> GetCastMember(int id)
        {
            var castMember = await _castRepository.GetById(id);

            

            return new CastModel { Id = castMember.Id, Name = castMember.Name, Gender = castMember.Gender, TmdbUrl = castMember.TmdbUrl, ProfilePath = castMember.ProfilePath};
        }
    }
}
