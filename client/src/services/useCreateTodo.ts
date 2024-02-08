import { useMutation, useQueryClient } from '@tanstack/react-query';
import { getTodosQueryKey } from './constants';
import axios from 'axios';
import { getAuthHeaders } from './getAuthHeaders';

export const useCreateTodo = () => {
    const client = useQueryClient();

    return useMutation({
        mutationFn: async (name: string) => {
            await axios.post(
                '/api/todo', 
                { name },
                {
                    headers: {
                        ...getAuthHeaders(),
                    }
                }
            );
        },
        onSuccess: () => {
            client.invalidateQueries(getTodosQueryKey);
        },
    });
};