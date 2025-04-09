using Xunit;
using ApiTodoList.Domain.Services;
using ApiTodoList.Infra.Repositories;

namespace TodoApp.Tests
{
    public class TarefaServiceTests
    {
        private readonly TarefaService _service;

        public TarefaServiceTests()
        {
            var repository = new TarefaRepositoryInMemory();
            _service = new TarefaService(repository);
        }

        [Fact]
        public void DeveCriarTarefa_ComDescricaoValida()
        {
            // Arrange
            var descricao = "Estudar SOLID";

            // Act
            var tarefa = _service.Criar(descricao);

            // Assert
            Assert.NotNull(tarefa);
            Assert.Equal(descricao, tarefa.Descricao);
            Assert.False(tarefa.Concluida);
        }

        [Fact]
        public void DeveListarTarefas_AposAdicionar()
        {
            // Arrange
            _service.Criar("Tarefa 1");
            _service.Criar("Tarefa 2");

            // Act
            var tarefas = _service.Listar();

            // Assert
            Assert.Equal(2, tarefas.Count);
        }

        [Fact]
        public void DeveConcluirTarefaExistente()
        {
            // Arrange
            var tarefa = _service.Criar("Concluir tarefa");
            var id = tarefa.Id;

            // Act
            var sucesso = _service.Concluir(id);

            // Assert
            Assert.True(sucesso);
            Assert.True(_service.Listar().First(t => t.Id == id).Concluida);
        }

        [Fact]
        public void NaoDeveConcluirTarefaInexistente()
        {
            var sucesso = _service.Concluir(999);
            Assert.False(sucesso);
        }

        [Fact]
        public void DeveRemoverTarefaExistente()
        {
            // Arrange
            var tarefa = _service.Criar("Tarefa para remover");

            // Act
            var sucesso = _service.Remover(tarefa.Id);

            // Assert
            Assert.True(sucesso);
            Assert.DoesNotContain(_service.Listar(), t => t.Id == tarefa.Id);
        }

        [Fact]
        public void NaoDeveRemoverTarefaInexistente()
        {
            var sucesso = _service.Remover(999);
            Assert.False(sucesso);
        }
    }
}
