using Blazor.Interfaces;
using Datos.Interfaces;
using Modelos;
using Datos.Repositorios;


namespace Blazor.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        private readonly Config _config;
        private ILoginRepositorio _loginRepositorio;

        public LoginServicio(Config config)
        {
            _config = config;
            _loginRepositorio = new LoginRepositorio(config.CadenaConexion);
        }
        public async Task<bool> ValidarUsuario(Login login)
        {
            return await _loginRepositorio.ValidarUsuario(login);
        }
    }
}
