<template>
    <div class="relative mx-auto min-h-screen max-w-7xl flex flex-col items-center">
        <div class="text-center mb-8">
            <h2 class="my-5 text-3xl font-semibold tracking-tight text-gray-900 dark:text-white">
                {{ title }}
            </h2>

            <p class="mt-4 text-lg text-gray-600 dark:text-gray-300">
                {{ description }}
            </p>
        </div>

        <LoadingSpinner v-if="isLoading" />

        <MatrixInput 
            v-show="!isLoading" 
            :isTwoInputs="!squareMatrixOnly" 
            :apiUrl="apiUrl" 
            @setLoading="setLoadingState"
            @taskResult="handleResult" 
            class="mb-4" 
        />

        <div v-if="!isLoading && resultData" 
            class="mt-8 w-full max-w-4xl bg-gray-50 dark:bg-gray-800 p-6 rounded-lg shadow-md">
            <h3 class="text-xl font-semibold text-gray-900 dark:text-white">
                Result
            </h3>
            <p class="mt-2 text-lg text-gray-700 dark:text-gray-300">
                {{ resultText }}
            </p>
            <div class="bg-white dark:bg-gray-700 p-4 rounded-lg shadow-sm mt-4">
                <table class="min-w-full border-separate border-spacing-2 border-none">
                    <thead>
                        <tr>
                            <th class="w-10"></th>
                            <th v-for="colIndex in (resultData[0]?.length || 0)" :key="'header-' + colIndex"
                                class="px-2 py-1 text-center text-gray-900 dark:text-gray-300">
                                {{ 'A' + colIndex }}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(row, rowIndex) in resultData" :key="'row-' + rowIndex">
                            <td class="w-10 px-2 py-1 text-center font-bold text-gray-900 dark:text-gray-300">
                                {{ rowIndex + 1 }}
                            </td>
                            <td v-for="(value, colIndex) in row" :key="'cell-' + rowIndex + '-' + colIndex" :class="[ 
                                'px-2 py-1 text-center rounded-md', 
                                'bg-gray-50 dark:bg-gray-800', 
                                'text-gray-900 dark:text-gray-300' 
                            ]">
                                {{ formatNumber(value) }}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import MatrixInput from './MatrixInput.vue';
import LoadingSpinner from './LoadingSpinner.vue';
import { formatNumber } from '../utility/functions';

const props = defineProps<{
    title: string,
    description: string,
    apiUrl: string,
    squareMatrixOnly: boolean,
    resultText: string,
    resultKey: string,
}>();

const isLoading = ref(false);
const resultData = ref<number[][] | null>(null);

function handleResult(result: Record<string, number[][]>) {
    resultData.value = result[props.resultKey];
}

function setLoadingState(state: boolean) {
    isLoading.value = state;
}
</script>
