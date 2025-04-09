using Microsoft.AspNetCore.Mvc;
using ApiTodoList.Domain.Services;
using ApiTodoList.DTOs;
using ApiTodoList.Infra.Repositories;

namespace TodoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly TarefaService _service;

    public TarefasController(TarefaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var tarefas = _service.Listar()
            .Select(TarefaResponse.FromEntity)
            .ToList();

        return Ok(tarefas);
    }

    [HttpPost]
    public IActionResult Criar([FromBody] CriarTarefaRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Descricao))
            return BadRequest("A descrição não pode ser vazia.");

        var tarefa = _service.Criar(request.Descricao);
        return CreatedAtAction(nameof(Listar), new { id = tarefa.Id }, TarefaResponse.FromEntity(tarefa));
    }

    [HttpPut("{id}/concluir")]
    public IActionResult Concluir(int id)
    {
        var sucesso = _service.Concluir(id);
        return sucesso ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Remover(int id)
    {
        var sucesso = _service.Remover(id);
        return sucesso ? NoContent() : NotFound();
    }
}
