import { TodoList } from './components/TodoList';
import { FC, Suspense } from 'react';
import { RouterProvider } from 'react-router';
import { createBrowserRouter } from 'react-router-dom';
import { ErrorBoundary } from 'react-error-boundary';

const router = createBrowserRouter([
    {
        path: '/',
        element: <TodoList />,
    },
]);

export const App: FC = () => <ErrorBoundary fallback={<>error</>}>
    <Suspense fallback={'loading...'}>
        <RouterProvider router={router}>
        </RouterProvider>
    </Suspense>
</ErrorBoundary>;
