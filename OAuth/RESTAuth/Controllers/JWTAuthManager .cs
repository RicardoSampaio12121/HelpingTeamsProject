/*
 * lufer
 * ISI
 * */
using System;
using System.Collections.Generic;
// Incluidas
using RESTAuth.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using RESTAuth.Repository;
using System.Threading.Tasks;

namespace RESTAuth.Controllers
{
    public interface IJWTAuthManager
    {
        /// <summary>
        /// Várias possibilidades de autenticação
        /// Podem ser criadas mais!
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        Task <AuthResponse> Authenticate(AuthRequest loginDetails);
    }

    /// <summary>
    /// Classe auxiliar para gerir Autenticação e JWT
    /// </summary>
    public class JWTAuthManager : IJWTAuthManager
    {
        private readonly IDashBoardLogin _repository;

        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="repository"></param>
        public JWTAuthManager(IDashBoardLogin repository)
        {
            this._repository = repository;
        }

        private readonly string tokenKey;

        #region ACEDER_APPSETTINGS.JSON
        //caso se pretenda aceder a appsettings.json
        private IConfiguration _config;
        /// <summary>
        /// instanciado em startup.cs:
        /// services.AddSingleton<IConfiguration>(Configuration)
        /// </summary>
        /// <param name="Configuration"></param>
        public JWTAuthManager(IConfiguration Configuration)
        {
            _config = Configuration;                            //para aceder a appsettings.json
        }
        #endregion

        /// <summary>
        /// Gere Token
        /// </summary>
        /// <param name="tokenKey"></param>
        public JWTAuthManager(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        /// <summary>
        /// h2:Autenticar sem Claims mas apenas com login/password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthResponse> Authenticate(AuthRequest loginDetails)
        {
            if (!await ValidarUser(loginDetails)) return null;

            var token = GenerateTokenString(loginDetails.Username, DateTime.UtcNow);

            return new AuthResponse
            {
                Name = loginDetails.Username,
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60)
            };
        }

        #region GerarTokens

        /// <summary>
        /// H1: Gerar JWT token!
        /// Caso existam claims...
        /// </summary>
        /// <param name="username"></param>
        /// <param name="expires"></param>
        /// <param name="claims">Claims Opcional!!!</param>
        /// <returns></returns>
        string GenerateTokenString(string username, DateTime expires, Claim[] claims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                 claims ?? new Claim[]          //caso existam claims usar, senão, criar novo com username
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                //NotBefore = expires,
                Expires = expires.AddMinutes(60),    //expira em 60 minutos
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }


        /// <summary>
        /// H2: Gerar JWT
        /// </summary>
        /// <returns></returns>
        string GenerateTokenString()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);  //válido por 2 horas
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        #endregion

        #region ValidaUser

        /// <summary>
        /// Certificar dados de autenticação
        /// </summary>
        /// <param name="loginDetalhes"></param>
        /// <returns></returns>
        private async Task<bool> ValidarUser(AuthRequest loginDetalhes)
        {
            //Verifica na BD
            //var user = users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            string teste1 = loginDetalhes.Username;
            string teste2 = loginDetalhes.Password;

            if (await _repository.VerifyLogin(teste1, teste2) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        #endregion
    }
}
