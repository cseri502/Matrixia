<template>
    <div class="relative mx-auto min-h-screen max-w-7xl flex flex-col items-center justify-center">
        <h2 class="my-5 text-3xl font-semibold tracking-tight text-gray-900 dark:text-white">Matrix Adjugate</h2>
        <MatrixInput :isTwoInputs="false" apiUrl="/matrixia/adjugate" @taskResult="handleMatrixCalculated" />
    </div>
</template>

<script setup lang="ts">
import MatrixInput from '../components/MatrixInput.vue';

const handleMatrixCalculated = (result: any) => {
    console.log('Adjugate result:', result);
};
</script>