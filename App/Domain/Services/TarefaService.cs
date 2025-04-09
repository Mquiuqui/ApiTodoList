namespace ApiTodoList.Domain.Services;
using ApiTodoList.Domain.Entities;
using ApiTodoList.Domain.Interfaces;

public class TarefaService
{
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public Tarefa Criar(string descricao)
    {
        var tarefa = new Tarefa(descricao);
        return _repository.Adicionar(tarefa);
    }

    public List<Tarefa> Listar() => _repository.Listar();

    public bool Concluir(int id)
    {
        var tarefa = _repository.ObterPorId(id);
        if (tarefa == null) return false;
        tarefa.Concluir();
        return true;
    }

    public bool Remover(int id) => _repository.Remover(id);
}
