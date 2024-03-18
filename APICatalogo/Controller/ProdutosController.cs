﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controller;

[Route("[Controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public ActionResult< IEnumerable<Produto>> Get()
    {
        try
        {
            
            var produtos = _context.Produtos.AsNoTracking().ToList();
            if (produtos is null)
            {
               return NotFound("Produtos não encontrado");
            }
            return produtos;
        }
        catch (Exception) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }



    [HttpGet("{id:int}", Name ="ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound("Produto não localizado");
            }
            return produto;
        }
            
        
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }

    }


    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        try
        {
            if (produto == null)
            
                return BadRequest("Dados invalidos");
            
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }


    [HttpPut("{id:int}")]
    public ActionResult Put(int id,Produto produto)
    {
        try
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Produto não localizado");
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }


    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }
    

}

