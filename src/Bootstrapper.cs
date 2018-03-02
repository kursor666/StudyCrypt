using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using Chezar.Models;
using Chezar.Utils;
using Chezar.ViewModels;
using Ninject;

namespace Chezar
{
    public class Bootstrapper : BootstrapperBase
    {
        private IKernel _kernel;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            _kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            
            _kernel.Bind<ChezarAlgorithmModel>().ToSelf().InSingletonScope();
            _kernel.Bind<BelazoPortAlgorithmModel>().ToSelf().InSingletonScope();
            _kernel.Bind<BitOperationModel>().ToSelf().InSingletonScope();
            _kernel.Bind<EvklidNodModel>().ToSelf().InSingletonScope();
            _kernel.Bind<PspModel>().ToSelf().InSingletonScope();
            
            _kernel.Bind<IScreenView>().To<ChezarViewModel>();
            _kernel.Bind<IScreenView>().To<BelazoPortViewModel>();
            _kernel.Bind<IScreenView>().To<BitOperationViewModel>();
            _kernel.Bind<IScreenView>().To<EvklidNodViewModel>();
            _kernel.Bind<IScreenView>().To<PspViewModel>();

            _kernel.Bind<EntropyModel>().ToSelf();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? _kernel.Get(service) : _kernel.Get(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            _kernel.Inject(instance);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            _kernel.Dispose();
        }
    }
}