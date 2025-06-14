﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Extensions.Installers;

namespace Uplay.Application.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(InstallerExtension).Assembly.ExportedTypes.
                Where(x =>
                          typeof(IInstaller).IsAssignableFrom(x)
                          && !x.IsInterface
                          && !x.IsAbstract)
                         .Select(Activator.CreateInstance)
                         .Cast<IInstaller>().ToList();

            installers.ForEach(i => i.InstallServices(services, configuration));
        }
    }
}
