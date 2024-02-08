import { InvalidateQueryFilters } from '@tanstack/react-query';

export const getTodosQueryKey: InvalidateQueryFilters = {queryKey: ['todos']} as const;