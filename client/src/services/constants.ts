import { InvalidateQueryFilters } from '@tanstack/react-query';

export const getTodosQueryKey = { queryKey: ['todos'] } satisfies InvalidateQueryFilters;
