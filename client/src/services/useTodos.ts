import { useSuspenseQuery } from '@tanstack/react-query';
import { getTodosQueryKey } from './constants';
import { getAuthHeaders } from './getAuthHeaders';
import axios from 'axios';

export const useTodos = () => {
    return useSuspenseQuery(({
        queryKey: getTodosQueryKey.queryKey,
        queryFn: async () => {
            const response = await axios.get('/api/todo', {
                headers: { ...getAuthHeaders()}
            });

            return response.data;
        }
    }));
};
