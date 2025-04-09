using ApiTodoList.Domain.Entities;

namespace ApiTodoList.DTOs;

public class TarefaResponse
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public static TarefaResponse FromEntity(Tarefa tarefa)
    {
        return new TarefaResponse
        {
            Id = tarefa.Id,
            Descricao = tarefa.Descricao,
            Concluida = tarefa.Concluida
        };
    }
}
