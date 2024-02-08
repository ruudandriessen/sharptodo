import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getAuthHeaders } from './getAuthHeaders';
import axios from 'axios';
import { getTodosQueryKey } from './constants';

export const useDeleteTodo = () => {
    const client = useQueryClient();

    return useMutation({
        mutationFn: async (todoId: string) => {
            await axios.delete(`/api/todo/${todoId}`, {
                headers: {
                    ...getAuthHeaders(),
                }
            });
        },
        onSuccess: () => client.invalidateQueries(getTodosQueryKey),
    });
};