using AluraChallenge.Api;
using AluraChallenge.Domain.DTO;
using AluraChallenge.Domain.Entities;
using AluraChallenge.Domain.Interfaces;
using AluraChallenge.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AluraChallenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly ILogger<VideosController> _logger;
        private IBaseService<Video> _videoService;
        public VideosController(ILogger<VideosController> logger,
                                IBaseService<Video> VideoService)
        {
            _logger = logger;
            _videoService = VideoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            RetornoViewModel retorno = new RetornoViewModel();
            try
            {
                retorno.Retorno = _videoService.Get();
                if (retorno.Retorno != null)
                    return Ok(retorno);

                retorno.Retorno = "Nenhum livro foi encontrado";
                return NotFound(retorno);
            }
            catch (Exception)
            {
                retorno.Retorno = "Ocorreu um erro durante a busca de livros";
                return BadRequest(retorno);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] VideoPostDTO videoPostDTO)
        {
            RetornoViewModel retorno = new RetornoViewModel();
            try
            {
                retorno.Retorno = _videoService.Add(new Video()
                {
                    Descricao = videoPostDTO.Descricao,
                    Titulo = videoPostDTO.Titulo,
                    Url = videoPostDTO.Url
                });
                return Ok(retorno);
            }
            catch (Exception)
            {
                retorno.Retorno = "Ocorreu um erro ao adicionar o livro";
                return BadRequest(retorno);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Video video)
        {
            RetornoViewModel retorno = new RetornoViewModel();
            try
            {
                retorno.Retorno = _videoService.Update(video);
                return Ok(retorno);
            }
            catch (Exception)
            {
                retorno.Retorno = "Ocorreu um erro ao atualizar o livro";
                return BadRequest(retorno);
            }
        }

        [HttpGet]
        [Route("id:int")]
        public IActionResult Get(int id)
        {
            RetornoViewModel retorno = new RetornoViewModel();
            try
            {
                retorno.Retorno = _videoService.GetById(id);
                if (retorno.Retorno != null)
                    return Ok(retorno);

                retorno.Retorno = "Nenhum livro foi encontrado";
                return NotFound(retorno);
            }
            catch (Exception)
            {
                retorno.Retorno = "Ocorreu um erro durante a busca de livros";
                return BadRequest(retorno);
            }
        }

        [HttpDelete]
        [Route("id:int")]
        public IActionResult Delete(int id)
        {
            RetornoViewModel retorno = new RetornoViewModel();
            try
            {
                _videoService.Delete(id);
                retorno.Retorno = "O livro foi excluído com sucesso";
                return Ok(retorno);
            }
            catch (Exception)
            {
                retorno.Retorno = "Ocorreu um erro durante a exclusão do livro";
                return BadRequest(retorno);
            }
        }
    }
}
