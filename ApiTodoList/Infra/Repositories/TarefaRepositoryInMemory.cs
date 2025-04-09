namespace ApiTodoList.Infra.Repositories;
using ApiTodoList.Domain.Entities;
using ApiTodoList.Domain.Interfaces;

public class TarefaRepositoryInMemory : ITarefaRepository
{
    private readonly List<Tarefa> _tarefas = new();
    private int _idAtual = 1;

    public Tarefa Adicionar(Tarefa tarefa)
    {
        tarefa.Id = _idAtual++;
        _tarefas.Add(tarefa);
        return tarefa;
    }

    public List<Tarefa> Listar() => _tarefas;

    public Tarefa ObterPorId(int id) =>
        _tarefas.FirstOrDefault(t => t.Id == id);

    public bool Remover(int id)
    {
        var tarefa = ObterPorId(id);
        return tarefa != null && _tarefas.Remove(tarefa);
    }
}
