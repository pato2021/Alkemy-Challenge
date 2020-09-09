using AutoMapper;
using BudgetManagerApp.BLL.DTO;
using BudgetManagerApp.BLL.Interfaces;
using BudgetManagerApp.DAL.Entities;
using BudgetManagerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.Logic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void Add(CategoryDTO categoryDTO)
        {
            var category = Mapper.Map<Category> (categoryDTO);
            _categoryRepository.Add(category);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }
            _categoryRepository.Delete(id.Value);
        }

        public void Edit(CategoryDTO categoryDTO)
        {
            var category = Mapper.Map<Category>(categoryDTO);
            _categoryRepository.Edit(category);
        }


        public CategoryDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException("id null");
            }
            var category = _categoryRepository.Get(id.Value);
            var categoryDTO = Mapper.Map<CategoryDTO>(category);
            return categoryDTO;
            
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDTO = Mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }

        public IEnumerable<CategoryDTO> GetCategoriesByType(string typeCategory)
        {
            var categories = _categoryRepository.GetCategoriesByType(typeCategory);
            var categoriesDTO = Mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }

    }
}
