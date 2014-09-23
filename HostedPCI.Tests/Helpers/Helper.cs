using HostedPCI.Domain.Abstract.Services;
using HostedPCI.Domain.Helpers;
using Ninject;

namespace HostedPCI.Tests.Helpers
{
    public static class Helper
    {
        public static StandardKernel GetNinjectKernel()
        {
            var ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IHostedPciDataConverter>().To<HostedPciDataConverter>().InThreadScope();
            ninjectKernel.Bind<IHostedPciConfiguration>().To<HostedPciConfiguration>().InThreadScope();
            ninjectKernel.Bind<IHostedPciService>().To<HostedPciService>().InThreadScope();

            return ninjectKernel;
        }
    }
}
