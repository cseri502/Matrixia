<template>
  <div class="relative flex flex-col items-center justify-center h-screen bg-white dark:bg-slate-900 overflow-hidden">
    <div class="absolute w-[60%] h-[60%] z-[0] rounded-full bottom-40 right-10 bg-blue-300 dark:bg-blue-500 filter blur-[200px] opacity-40 animate-blob"></div>
    
    <h1 class="text-6xl font-bold text-black dark:text-white mb-4 z-[1]">404</h1>
    <h2 class="text-2xl font-semibold text-slate-700 dark:text-slate-300 mb-6 z-[1]">Oops! Page Not Found</h2>
    <p class="text-lg text-slate-600 dark:text-slate-400 mb-8 text-center z-[1]">
      The page you are looking for does not exist. It might have been removed, or you may have entered the wrong URL.
    </p>
    <router-link to="/" class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 transition duration-200 z-[1]">
      Go Back Home
    </router-link>
  </div>
</template>

<script setup lang="ts">
</script>