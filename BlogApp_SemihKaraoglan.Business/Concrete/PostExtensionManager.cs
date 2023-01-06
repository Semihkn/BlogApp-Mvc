using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Data.Abstract;
using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Concrete
{
    public class PostExtensionManager : IPostExtensionService
    {
        private IPostExtensionRepository _postExtensionRepository;

        public PostExtensionManager(IPostExtensionRepository postExtensionRepository)
        {
            _postExtensionRepository = postExtensionRepository;
        }

        public async Task CreateAsync(PostExtension postExtension)
        {
            await _postExtensionRepository.CreateAsync(postExtension);
        }

        public void Delete(PostExtension postExtension)
        {
           _postExtensionRepository.Delete(postExtension);
        }

        public async Task<List<PostExtension>> GetAllAsync(Expression<Func<PostExtension, bool>> expression)
        {
            return await _postExtensionRepository.GetAllAsync(expression);
        }

        public async Task<PostExtension> GetByIdAsync(int id)
        {
            return await _postExtensionRepository.GetByIdAsync(id);
        }

        public void Update(PostExtension postExtension)
        {
           _postExtensionRepository.Update(postExtension);
        }
    }
}
