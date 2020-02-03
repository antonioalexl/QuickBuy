using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System.IO;

namespace QuickBuy.Web.Controllers
{

    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        private IHttpContextAccessor _httpContextAccessor;       

        private IWebHostEnvironment _httpHostingEnviroment;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment httpHostingEnviroment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _httpHostingEnviroment = httpHostingEnviroment;
        }

        public IActionResult Get()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            try
            {                
                _produtoRepositorio.Adicionar(produto);
                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo([FromBody]Produto produto)
        {
            try
            {

                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                string novoNomeArquivo = GerarNomeArquivo(nomeArquivo, extensao);
                var pastaArquivo = _httpHostingEnviroment.WebRootPath + "\\arquivos\\";
                var nomeCompleto = pastaArquivo + novoNomeArquivo;


                using (var stremArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(stremArquivo);
                }

                return Json(novoNomeArquivo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }

        private static string GerarNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-") + "." + extensao;

            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}";
            return novoNomeArquivo;
        }
    }
}