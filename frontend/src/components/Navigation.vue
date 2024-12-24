<template>
  <nav
    class="sticky top-0 z-40 w-full backdrop-blur flex-none transition-colors duration-500 lg:z-50 lg:border-b lg:border-slate-900/10 dark:border-slate-50/[0.06] bg-white/95 supports-backdrop-blur:bg-white/60 dark:bg-transparent">
      <div class="max-w-7xl mx-auto">
        <div class="py-4 border-b border-slate-900/10 lg:px-8 lg:border-0 dark:border-slate-300/10 mx-4 lg:mx-0">
          <div class="relative flex items-center">
            <div class="flex flex-row justify-between items-center space-x-2">
              <img src="/matrix.png" alt="matrix" class="h-8">
              <p class="text-white text-lg font-bold">Matrixia</p>
            </div>
            <div class="relative hidden lg:flex items-center ml-auto space-x-4">
              <router-link to="/determinant"
                class="text-gray-300 hover:text-blue-500 transition duration-200">Determinant</router-link>
              <router-link to="/inverse-matrix" class="text-gray-300 hover:text-blue-500 transition duration-200">Inverse
                Matrix</router-link>
              <router-link to="/matrix-rank" class="text-gray-300 hover:text-blue-500 transition duration-200">Matrix
                Rank</router-link>
              <router-link to="/matrix-transpose" class="text-gray-300 hover:text-blue-500 transition duration-200">Matrix
                Transpose</router-link>
              <router-link to="/addition-subtraction"
                class="text-gray-300 hover:text-blue-500 transition duration-200">Addition/Subtraction</router-link>
              <router-link to="/gauss-elimination" class="text-gray-300 hover:text-blue-500 transition duration-200">Gauss
                Elimination</router-link>
            </div>
          </div>
        </div>
      </div>
  </nav>
</template>

<script setup lang="ts">

</script>