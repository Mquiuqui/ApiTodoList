namespace ApiTodoList.Domain.Entities;
public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; private set; }

    public Tarefa(string descricao)
    {
        Descricao = descricao;
        Concluida = false;
    }

    public void Concluir()
    {
        Concluida = true;
    }
}