<template>
    <div class="relative flex flex-col items-center justify-center min-h-screen p-4 overflow-hidden bg-white dark:bg-slate-900">
        <div class="z-[1]">
            <h1 class="text-4xl text-center font-bold text-gray-900 dark:text-white mb-6">
                Welcome to <span class="text-blue-500 duration-150 hover:text-blue-600">Matrixia</span>!
            </h1>
            <p class="text-lg text-center text-gray-700 dark:text-slate-300 mb-8">
                Your go-to solution for performing various matrix operations with ease.
            </p>

            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 w-full max-w-7xl">
                <div v-for="(operation, index) in operations" :key="index"
                    class="block max-w-sm p-6 bg-gray-100/50 dark:bg-slate-800 border border-gray-300 dark:border-slate-700 rounded-lg shadow-lg transition-transform duration-300 ease-in-out hover:bg-gray-100 dark:hover:bg-slate-800/75 hover:-translate-y-2">
                    <h5 class="mb-2 text-2xl font-semibold tracking-tight text-gray-900 dark:text-white">{{ operation.title }}</h5>
                    <p class="mb-3 font-normal text-gray-600 dark:text-gray-400">{{ operation.description }}</p>
                    <router-link :to="routes[index + 1].path" class="inline-flex font-medium items-center text-blue-600 hover:underline">
                        Get started
                        <svg class="w-3 h-3 ms-2.5 rtl:rotate-[270deg]" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 18 18">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 11v4.833A1.166 1.166 0 0 1 13.833 17H2.167A1.167 1.167 0 0 1 1 15.833V4.167A1.166 1.166 0 0 1 2.167 3h4.618m4.447-2H17v5.768M9.111 8.889l7.778-7.778"/>
                        </svg>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { routes } from '../router';

const operations = [
    {
        title: "Rank Determination",
        description: "Identify the rank of a matrix, representing the maximum number of linearly independent rows or columns."
    },
    {
        title: "Determinant Calculation",
        description: "Determine the scalar value representing key properties of a matrix, useful in understanding its behavior and applications."
    },
    {
        title: "Matrix Inversion",
        description: "Compute the inverse of a matrix, a fundamental step in solving linear equation systems and various analytical processes."
    },
    {
        title: "Matrix Transposition",
        description: "Generate the transpose of a matrix by interchanging its rows and columns, effectively reflecting it across its diagonal."
    },
    {
        title: "Adjoint Computation",
        description: "Calculate the adjoint (or adjugate) of a matrix, a crucial component in the matrix inversion process."
    }
];
</script>