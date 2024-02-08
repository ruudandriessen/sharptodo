/* @refresh reload */
import '@shoelace-style/shoelace';
import { createRoot } from 'react-dom/client';
import { App } from './App';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ChakraBaseProvider, theme } from '@chakra-ui/react';
import { GoogleOAuthProvider } from '@react-oauth/google';

const queryClient = new QueryClient();

const element = document.getElementById('root');

if (import.meta.env.DEV && !(element instanceof HTMLElement)) {
    throw new Error(
        'Root element not found. Did you forget to add it to your index.html? Or maybe the id attribute got misspelled?',
    );
}


const root = createRoot(element!);
root.render(<GoogleOAuthProvider clientId='289832142171-4pgrkds4cptbdrslrppgoontkss38ejt.apps.googleusercontent.com'>
    <QueryClientProvider client={queryClient}>
        <ChakraBaseProvider theme={theme}>
            <App />
        </ChakraBaseProvider>
    </QueryClientProvider>
</GoogleOAuthProvider>);
