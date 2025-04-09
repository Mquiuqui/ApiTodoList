import { useEffect, useState } from 'react';
import { Task } from '../types/Task';
import { TaskItem } from '../components/TaskItem';
import { TaskForm } from '../components/TaskForm';
import * as taskService from '../services/TaskService';

export default function TaskList() {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [loadingId, setLoadingId] = useState<number | null>(null);

  const loadTasks = async () => {
    const data = await taskService.getTasks();
    setTasks(data);
  };

  const handleAdd = async (descricao: string) => {
    await taskService.createTask(descricao);
    loadTasks();
  };

  const handleComplete = async (id: number) => {
    setLoadingId(id);
    await taskService.completeTask(id);
    setLoadingId(null);
    loadTasks();
  };

  const handleDelete = async (id: number) => {
    setLoadingId(id);
    await taskService.deleteTask(id);
    setLoadingId(null);
    setTasks((prev) => prev.filter((t) => t.id !== id));
  };

  useEffect(() => {
    loadTasks();
  }, []);

  return (
    <div className="min-h-screen bg-gray-100 flex items-center justify-center px-4">
      <div className="w-full max-w-xl bg-white rounded-xl shadow-md p-6">
        <h1 className="text-2xl font-bold text-blue-700 mb-6 text-center">
          📝 Lista de Tarefas
        </h1>

        <TaskForm onAdd={handleAdd} />

        <ul className="space-y-2">
          {tasks.map((task) => (
            <TaskItem
              key={task.id}
              task={task}
              isLoading={loadingId === task.id}
              onComplete={handleComplete}
              onDelete={handleDelete}
            />
          ))}
        </ul>
      </div>
    </div>
  );
}
