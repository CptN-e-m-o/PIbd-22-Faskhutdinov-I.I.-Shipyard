using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractShipyardBusinessLogic.BusinessLogics;
using AbstractShipyardContracts.BusinessLogicsContracts;
using AbstractShipyardContracts.StoragesContracts;
using AbstractShipyardDatabaseImplement.Implements;
using AbstractShipyardBusinessLogic.OfficePackage;
using AbstractShipyardBusinessLogic.OfficePackage.Implements;
using Unity;
using Unity.Lifetime;

namespace AbstractShipyardView
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
            
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IComponentStorage,
            ComponentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductStorage, ProductStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComponentLogic, ComponentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductLogic, ProductLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportLogic, ReportLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
