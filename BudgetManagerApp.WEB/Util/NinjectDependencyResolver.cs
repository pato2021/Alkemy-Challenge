using BudgetManagerApp.BLL.Interfaces;
using BudgetManagerApp.BLL.Logic;
using BudgetManagerApp.DAL.Context;
using BudgetManagerApp.DAL.Interfaces;
using BudgetManagerApp.DAL.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetManagerApp.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        private void AddBindings()
        {


            //var context = new BudgetManagerDBContext();

            kernel.Bind<ICategoryRepository>().To<CategoryRepository>()
                .WithConstructorArgument("storeContext", BudgetManagerDBContext.BudgetManagerInstance);

            kernel.Bind<IOperationRepository>().To<OperationRepository>()
                .WithConstructorArgument("storeContext", BudgetManagerDBContext.BudgetManagerInstance);

            kernel.Bind<IUnitOfWork>().To<IdentityUnitOfWork>()
                .WithConstructorArgument("storeContext", BudgetManagerDBContext.BudgetManagerInstance);

            kernel.Bind<IUserProfileManager>().To<UserProfileManager>()
                .WithConstructorArgument("storeContext", BudgetManagerDBContext.BudgetManagerInstance);

            kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>()
                .WithConstructorArgument("storeContext", BudgetManagerDBContext.BudgetManagerInstance);




            kernel.Bind<ICategoryLogic>().To<CategoryLogic>();

            kernel.Bind<IOperationLogic>().To<OperationLogic>();

            kernel.Bind<IUserProfileLogic>().To<UserProfileLogic>();


        }
    }
}