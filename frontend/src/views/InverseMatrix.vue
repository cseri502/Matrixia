<template>
    <div class="relative mx-auto min-h-screen max-w-7xl flex flex-col items-center">
        <div class="text-center mb-8">
            <h2 class="my-5 text-3xl font-semibold tracking-tight text-gray-900 dark:text-white">
                Matrix Inverse
            </h2>

            <p class="mt-4 text-lg text-gray-600 dark:text-gray-300">
                Easily calculate the inverse of your matrix.
            </p>
        </div>

        <LoadingSpinner v-if="isLoading" />
        
        <MatrixInput v-show="!isLoading" :isTwoInputs="false" apiUrl="/matrixia/inverse" @setLoading="setLoadingState"
            @taskResult="handleResult" class="mb-4" />
        <div v-if="!isLoading && inverse"
            class="mt-8 w-full max-w-4xl bg-gray-50 dark:bg-gray-800 p-6 rounded-lg shadow-md">
            <h3 class="text-xl font-semibold text-gray-900 dark:text-white">
                Result
            </h3>
            <p class="mt-2 text-lg text-gray-700 dark:text-gray-300">
                The inverse matrix is shown below:
            </p>
            <div class="bg-white dark:bg-gray-700 p-4 rounded-lg shadow-sm mt-4">
                <table class="min-w-full border-separate border-spacing-2 border-none">
                    <thead>
                        <tr>
                            <th class="w-10"></th>
                            <th v-for="colIndex in inverse.length" :key="'header-' + colIndex"
                                class="px-2 py-1 text-center text-gray-900 dark:text-gray-300">
                                {{ 'A' + colIndex }}
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(row, rowIndex) in inverse" :key="'row-' + rowIndex">
                            <td class="w-10 px-2 py-1 text-center font-bold text-gray-900 dark:text-gray-300">
                                {{ rowIndex + 1 }}
                            </td>
                            <td v-for="(value, colIndex) in row" :key="'cell-' + rowIndex + '-' + colIndex" :class="[
                                'px-2 py-1 text-center rounded-md',
                                'bg-gray-50 dark:bg-gray-800',
                                'text-gray-900 dark:text-gray-300',
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
import MatrixInput from '../components/MatrixInput.vue';
import LoadingSpinner from '../components/LoadingSpinner.vue';
import { formatNumber } from '../utility/functions';

const isLoading = ref(false);
const inverse = ref<number[][] | null>(null);

const handleResult = (result: { inverse: number[][] }) => {
    inverse.value = result?.inverse;
};

function setLoadingState(state: boolean) {
    isLoading.value = state;
}
</script>