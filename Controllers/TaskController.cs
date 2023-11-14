using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Enums;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Response;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // TODO: Buscar o Id no banco utilizando o EF
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            // TODO: Validar o tipo de retorno. Se não encontrar a tarefa, retornar NotFound
            if (task == null)
            {
                return ErrorResponse.EntityNotFoundResponse();
            }
            // caso contrário retornar OK com a tarefa encontrada
            return Ok(task);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Buscar todas as tarefas no banco utilizando o EF
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpGet("Title/{title}")]
        public IActionResult GetByTitle(string title)
        {
            if (title == null) {
                return RequiredFieldResponse.TitleIsRequiredResponse(); 
            }
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o titulo recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var tasksByTitle = _context.Tasks.Where(c => c.Title.ToLower() == title.ToLower()).ToList();

            if (tasksByTitle.Count == 0) {
                return ErrorResponse.EntityNotFoundResponse();
            }
           
            return Ok(tasksByTitle);
        }

        [HttpGet("GetByDate")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tasks.Where(x => x.DateTask.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("GetByStatus")]
        public IActionResult ObterPorStatus(StatusTaskEnum status)
        {
            // TODO: Buscar  as tarefas no banco utilizando o EF, que contenha o status recebido por parâmetro
            // Dica: Usar como exemplo o endpoint ObterPorData
            var tarefa = _context.Tasks.Where(x => x.Status == status);
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (task.Title == null)
                return RequiredFieldResponse.TitleIsRequiredResponse();
            if (task.Description == null)
                return RequiredFieldResponse.DescriptionIsRequiredResponse();
                
            if (task.DateTask == DateTime.MinValue)
                return ErrorResponse.InvalidDateResponse();

            // TODO: Adicionar a tarefa recebida no EF e salvar as mudanças (save changes)
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TaskModel task)
        {
            var taskBd = _context.Tasks.Find(id);

            if (taskBd == null)
                return ErrorResponse.EntityNotFoundResponse();

            if (task.DateTask == DateTime.MinValue)
                return ErrorResponse.InvalidDateResponse();

            // TODO: Atualizar as informações da variável tarefaBanco com a tarefa recebida via parâmetro
            // TODO: Atualizar a variável tarefaBanco no EF e salvar as mudanças (save changes)
            if (task.Title != null)
                taskBd.Title = task.Title;
            if (task.Description != null)
                taskBd.Description = task.Description;
            
            taskBd.DateTask = task.DateTask;
            taskBd.Status = task.Status;

            _context.Tasks.Update(taskBd);
            _context.SaveChanges();

            return Ok(_context.Tasks.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var taskBd = _context.Tasks.Find(id);

            if (taskBd == null)
                return ErrorResponse.EntityNotFoundResponse();

            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
            _context.Remove(taskBd);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
