<template>
    <div class="relative flex flex-col items-center justify-center min-h-screen p-4 bg-slate-900 overflow-hidden">
        <div
            class="absolute w-[60%] h-[60%] z-0 rounded-full bottom-40 right-10 bg-blue-500 filter blur-[200px] opacity-35 animate-blob">
        </div>

        <div class="z-[1]">
            <h1 class="text-4xl text-center font-bold text-white mb-6">Welcome to Matrixia!</h1>
            <p class="text-lg text-center text-slate-300 mb-8">
                Your go-to solution for performing various matrix operations with ease.
            </p>

            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 w-full max-w-7xl">
                <div v-for="(operation, index) in operations" :key="index"
                    class="block max-w-sm p-6 bg-slate-800 border border-slate-700 rounded-lg shadow-lg transition-transform duration-300 ease-in-out hover:bg-slate-800/75 hover:-translate-y-2">
                    <h2 class="mb-2 text-2xl font-bold tracking-tight text-white">{{ operation.title }}</h2>
                    <p class="font-normal text-slate-300">{{ operation.description }}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
const operations = [
    {
        title: "Determinant Calculation",
        description: "Determine the scalar value representing key properties of a matrix, useful in understanding its behavior and applications."
    },
    {
        title: "Rank Determination",
        description: "Identify the rank of a matrix, representing the maximum number of linearly independent rows or columns."
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