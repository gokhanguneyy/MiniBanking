using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using MiniBanking.Api.Contracts.Auth;
using MiniBanking.Application.Abstractions;

namespace MiniBanking.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("token")]
        public ActionResult<TokenResponse> GenerateToken([FromBody] MockTokenRequest request)
        {
            var token = _jwtTokenService.GenerateToken(
                request.UserId,
                request.Email);

            return Ok(new TokenResponse
            {
                AccessToken = token
            });
        }
    }
}
