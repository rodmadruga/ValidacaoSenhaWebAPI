using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ValidacaoSenhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenhaController : ControllerBase
    {
        [HttpGet("Validar")]
        public IActionResult Validar(string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(senha) || senha.Length < 9)
                    return BadRequest("Necessário possuir nove ou mais caracteres");

                if (!senha.Any(char.IsDigit))
                    return BadRequest("Necessário possuir ao menos 1 dígito");

                if (!senha.Any(char.IsLower))
                    return BadRequest("Necessário possuir ao menos 1 letra minúscula");

                if (!senha.Any(char.IsUpper))
                    return BadRequest("Necessário possuir ao menos 1 letra maiúscula");

                char[] caracteresEspeciais = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };
                if (senha.IndexOfAny(caracteresEspeciais) == -1)
                    return BadRequest("Necessário possuir ao menos 1 caractere especial");

                if (senha.Zip(senha.Skip(1), (a, b) => a == b).Any(x => x))
                    return BadRequest("Não pode possuir caracteres repetidos dentro do conjunto");

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
