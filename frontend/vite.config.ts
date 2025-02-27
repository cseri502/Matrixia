import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    proxy: {
      '/matrixia': {
        target: 'http://localhost:5139',
        changeOrigin: true,
      },
    },
  }
})
