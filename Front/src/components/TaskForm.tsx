import { useState } from 'react';
import { motion } from 'framer-motion';

interface Props {
  onAdd: (descricao: string) => Promise<void>;
}

export function TaskForm({ onAdd }: Props) {
  const [descricao, setDescricao] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!descricao.trim()) return;

    setLoading(true);
    await onAdd(descricao.trim());
    setDescricao('');
    setLoading(false);
  };

  return (
    <form onSubmit={handleSubmit} className="flex items-center gap-2 mb-6">
      <input
        disabled={loading}
        type="text"
        placeholder="Nova tarefa"
        value={descricao}
        onChange={(e) => setDescricao(e.target.value)}
        className="flex-1 p-2 border border-gray-300 rounded-md shadow-sm focus:ring-2 focus:ring-blue-400 disabled:opacity-50"
      />
      <motion.button
        whileHover={{ scale: 1.05 }}
        whileTap={{ scale: 0.95 }}
        disabled={loading}
        type="submit"
        className="bg-blue-600 text-white px-4 py-2 rounded-md transition disabled:bg-blue-400 disabled:cursor-not-allowed"
      >
        {loading ? (
          <span className="animate-pulse">Adicionando...</span>
        ) : (
          'Adicionar'
        )}
      </motion.button>
    </form>
  );
}
