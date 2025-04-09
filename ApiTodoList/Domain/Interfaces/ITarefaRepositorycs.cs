namespace ApiTodoList.Domain.Interfaces;
using ApiTodoList.Domain.Entities;
using System.Collections.Generic;

public interface ITarefaRepository
{
    Tarefa Adicionar(Tarefa tarefa);
    List<Tarefa> Listar();
    Tarefa ObterPorId(int id);
    bool Remover(int id);
}