import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getAuthHeaders } from './getAuthHeaders';
import axios from 'axios';
import { getTodosQueryKey } from './constants';

export const useUpdateTodo = () => {
    const client = useQueryClient();

    return useMutation({
        mutationFn: async (todo: any) => {
            await axios.put(`/api/todo/${todo.id}`, {
                checked: todo.checked,
            }, 
            {
                headers: {
                    ...getAuthHeaders(),
                }
            });
        },
        onSuccess: () => {
            client.invalidateQueries(getTodosQueryKey);
        },
    });
};