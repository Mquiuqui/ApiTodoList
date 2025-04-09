import { motion } from 'framer-motion';
import { Task } from '../types/Task';

interface Props {
  task: Task;
  isLoading: boolean;
  onComplete: (id: number) => void;
  onDelete: (id: number) => void;
}

export function TaskItem({ task, isLoading, onComplete, onDelete }: Props) {
  return (
    <motion.li
      className="flex items-center justify-between p-3 bg-gray-50 border border-gray-200 rounded-lg shadow-sm hover:shadow-md transition"
      initial={{ opacity: 0, y: -10 }}
      animate={{ opacity: 1, y: 0 }}
      exit={{ opacity: 0, x: -20 }}
      layout
    >
      <span
        className={`flex-1 ${
          task.concluida ? 'line-through text-gray-400' : 'text-gray-800'
        }`}
      >
        {task.descricao}
      </span>

      <div className="flex gap-2 ml-4">
        {isLoading ? (
          <span className="text-gray-400 animate-pulse text-sm">Aguarde...</span>
        ) : (
          <>
            {!task.concluida && (
              <motion.button
                whileHover={{ scale: 1.1 }}
                whileTap={{ scale: 0.9 }}
                onClick={() => onComplete(task.id)}
                className="text-green-600 hover:text-green-800"
                title="Concluir"
              >
                ✔️
              </motion.button>
            )}
            <motion.button
              whileHover={{ scale: 1.1 }}
              whileTap={{ scale: 0.9 }}
              onClick={() => onDelete(task.id)}
              className="text-red-600 hover:text-red-800"
              title="Excluir"
            >
              🗑️
            </motion.button>
          </>
        )}
      </div>
    </motion.li>
  );
}
