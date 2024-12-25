<template>
  <header
    class="sticky top-0 z-40 w-full backdrop-blur flex-none transition-colors duration-500 lg:z-50 lg:border-b lg:border-slate-900/10 dark:border-slate-50/[0.06] bg-white/95 supports-backdrop-blur:bg-white/60 dark:bg-transparent">
    <div class="max-w-7xl mx-auto">
      <div class="py-4 border-b border-slate-900/10 lg:px-8 lg:border-0 dark:border-slate-300/10 mx-4 lg:mx-0">
        <div class="relative flex items-center justify-between">
          <router-link to="/">
            <div class="flex items-center space-x-2">
              <img src="/matrix.png" alt="Matrixia logo" class="h-8">
              <h1 class="text-white text-lg font-bold">Matrixia</h1>
            </div>
          </router-link>
          <nav class="relative hidden lg:flex items-center ml-auto space-x-6">
            <ul class="flex space-x-6">
              <li v-for="n in routes.length - 1" :key="n">
                <router-link :to="routes[n].path" class="text-gray-300 hover:text-blue-500 transition duration-200">
                  {{ routes[n].title }}
                </router-link>
              </li>
            </ul>
          </nav>
          <button class="lg:hidden ml-auto" @click="toggleMenu">
            <span class="text-gray-300">Menu</span>
          </button>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup lang="ts">
import { routes } from '../router';
import { ref } from 'vue';

const isMenuOpen = ref(false);

const toggleMenu = () => {
  isMenuOpen.value = !isMenuOpen.value;
};
</script>

<style scoped>
@media (max-width: 1024px) {
  nav ul {
    display: none;
    flex-direction: column;
    position: absolute;
    top: 100%;
    left: 0;
    right: 0;
    background-color: white;
    z-index: 50;
  }

  nav ul.show {
    display: flex;
  }

  nav button {
    display: block;
  }
}
</style>