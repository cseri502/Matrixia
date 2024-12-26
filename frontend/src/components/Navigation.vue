<template>
  <header
    class="sticky top-0 z-40 w-full backdrop-blur flex-none transition-colors duration-500 lg:z-50 lg:border-b lg:border-slate-900/10 dark:border-slate-50/[0.06] supports-backdrop-blur:bg-white/60 bg-transparent">
    <div class="max-w-7xl mx-auto">
      <div class="py-4 border-b border-slate-900/10 lg:px-8 lg:border-0 dark:border-slate-300/10 mx-4 lg:mx-0">
        <div class="relative flex items-center justify-between">
          <router-link to="/">
            <div class="flex items-center space-x-2">
              <img src="/matrix.png" alt="Matrixia logo" class="h-8">
              <h1 class="text-gray-900 dark:text-white text-lg font-bold">Matrixia</h1>
            </div>
          </router-link>
          <nav class="relative items-center ml-auto space-x-6">
            <ul class="flex space-x-6">
              <li>
                <a href="https://www.github.com/cseri502/Matrixia">
                  <div class="duration-150 cursor-pointer" :class="`hover:text-blue-500`" title="Change theme"
                  @click="() => toggleDark()">
                  <v-icon name="fa-github" scale="1.25" />
                </div>
                </a>
              </li>
              <li>
                <div class="duration-150 cursor-pointer" :class="`hover:text-blue-500`" title="Change theme"
                  @click="() => toggleDark()">
                  <v-icon :name="isDark ? 'bi-sun-fill' : 'bi-moon-fill'" scale="1.25" animation="wrench" speed="slow" hover />
                </div>
              </li>
            </ul>
          </nav>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup lang="ts">
import { useDark, useToggle } from '@vueuse/core'

const isDark = useDark()
const toggleDark = useToggle(isDark);
</script>