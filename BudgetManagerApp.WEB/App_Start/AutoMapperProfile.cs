using AutoMapper;
using BudgetManagerApp.BLL.DTO;
using BudgetManagerApp.DAL.Entities;
using BudgetManagerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetManagerApp.WEB.App_Start
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<OperationDTO, Operation>()
                .ConstructUsing(x => new Operation(x.Type));

            CreateMap<Operation, OperationDTO>()
                .ConstructUsing(x => new OperationDTO(x.Type));


            CreateMap<OperationDTO, OperationModel>()
                .ConstructUsing(x => new OperationModel(x.Type));

            CreateMap<OperationModel, OperationDTO>()
                .ConstructUsing(x => new OperationDTO(x.Type));


            CreateMap<CategoryDTO, Category>()
                .ConstructUsing(x => new Category(x.Type));

            CreateMap<Category, CategoryDTO>()
                .ConstructUsing(x => new CategoryDTO(x.Type));

        }

    }
}