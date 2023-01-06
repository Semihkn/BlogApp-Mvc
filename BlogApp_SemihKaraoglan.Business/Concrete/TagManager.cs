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
    public class TagManager : ITagService
    {
        private ITagRepository _tagRepository;

        public TagManager(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task CreateAsync(Tag tag)
        {
            await _tagRepository.CreateAsync(tag);
        }

        public void Delete(Tag tag)
        {
            _tagRepository.Delete(tag);
        }

        public async Task<List<Tag>> GetAllAsync(Expression<Func<Tag, bool>> expression)
        {
            return await _tagRepository.GetAllAsync(expression);
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            return await _tagRepository.GetByIdAsync(id);
        }

        public void Update(Tag tag)
        {
            _tagRepository.Update(tag);
        }
    }
}
