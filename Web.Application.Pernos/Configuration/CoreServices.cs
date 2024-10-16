using JSD.PERNOS.Business.Logic.Layer.Implementation;
using JSD.PERNOS.Business.Logic.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Implementation;
using JSD.PERNOS.Data.Access.Layer.Interfaces;
using JSD.PERNOS.Data.Access.Layer.Utils;
using JSD.SUNKU.Business.Logic.Layer.Implementation;
using JSD.SUNKU.Business.Logic.Layer.Interfaces;
using JSD.SUNKU.Data.Access.Layer.Implementation;
using JSD.SUNKU.Data.Access.Layer.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<DataProtector>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IProductoService, ProductoService>();

            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IVentaService, VentaService>();

            services.AddScoped<IValeRepository, ValeRepository>();
            services.AddScoped<IValeService, ValeService>();

            services.AddScoped<ITipoMovimientoRepository, TipoMovimientoRepository>();
            services.AddScoped<ITipoMovimientoService, TipoMovimientoService>();

            services.AddScoped<IAlmacenRepositroy, AlmacenRepository>();
            services.AddScoped<IAlmacenService, AlmacenService>();

            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<ICompraService, CompraService>();

            services.AddScoped<ISalidaRepository, SalidaRepository>();
            services.AddScoped<ISalidaService, SalidaService>();
        }
    }
    
}
