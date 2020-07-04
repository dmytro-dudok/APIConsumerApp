using WpfUI.Library;
using WpfUI.Library.Api;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfUI.Helpers;
using WpfUI.ViewModels;
using App.Library.Api;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace WpfUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        private readonly SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void Configure()
        {
            _container.Instance(_container)
                .PerRequest<IFoxImageEndpoint, FoxImageEndpoint>();

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IApiHelper, ApiHelper>()
                .Singleton<IFoxProcessor, FoxProcessor>()
                .Singleton<IEventAggregator, EventAggregator>();

            _container.PerRequest<ShellViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
    }
}
