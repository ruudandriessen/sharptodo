import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import eslint from 'vite-plugin-eslint';
// import devtools from 'solid-devtools/vite';

export default defineConfig({
    plugins: [
    /*
    Uncomment the following line to enable solid-devtools.
    For more info see https://github.com/thetarnav/solid-devtools/tree/main/packages/extension#readme
    */
        // devtools(),
        react(),
        eslint(),
    ],
    server: {
        port: 3001,
        proxy: {
            ['/api']: {
                target: 'http://localhost:5252',
                changeOrigin: true,
                rewrite: (path) => path.replace(/^\/api/, ''),
            },
        },
    },
    build: {
        target: 'esnext',
    },
});
