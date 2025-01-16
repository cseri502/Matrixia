<template>
    <div class="relative mx-auto min-h-screen max-w-7xl flex flex-col items-center">
        <h2 class="my-5 text-3xl font-semibold tracking-tight text-gray-900 dark:text-white">Matrix Rank</h2>
        <LoadingSpinner v-if="isLoading" />
        <MatrixInput v-show="!isLoading" :isTwoInputs="true" apiUrl="/matrixia/rank" @setLoading="setLoadingState"
            @taskResult="handleResult" class="mb-4" />
        <div v-if="!isLoading && rank"
            class="mt-8 w-full max-w-4xl bg-gray-50 dark:bg-gray-800 p-6 rounded-lg shadow-md">
            <h3 class="text-xl font-semibold text-gray-900 dark:text-white">Result</h3>
            <p class="mt-2 text-lg text-gray-700 dark:text-gray-300">
                Rank: <span class="font-bold">{{ rank }}</span>
            </p>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import MatrixInput from '../components/MatrixInput.vue';
import LoadingSpinner from '../components/LoadingSpinner.vue';

const isLoading = ref(false);
const rank = ref<number | null>(null);

const handleResult = (result: any) => {
    rank.value = result?.rank;
};

function setLoadingState(state: boolean) {
    isLoading.value = state;
}
</script>