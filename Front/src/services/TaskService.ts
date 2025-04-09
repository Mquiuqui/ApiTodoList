import { Task } from '../types/Task';

const API_URL = 'https://apitodolist-luz8.onrender.com/api/tarefas';

export const getTasks = async (): Promise<Task[]> => {
  const res = await fetch(API_URL);
  return await res.json();
};

export const createTask = async (descricao: string): Promise<void> => {
  await fetch(API_URL, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ descricao })
  });
};

export const completeTask = async (id: number): Promise<void> => {
  await fetch(`${API_URL}/${id}/concluir`, { method: 'PUT' });
};

export const deleteTask = async (id: number): Promise<void> => {
  await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
};
