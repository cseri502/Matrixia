<template>
  <div class="relative mx-auto min-h-screen max-w-7xl px-4 py-8 flex flex-col">
    <!-- Title -->
    <div class="text-center mb-8">
      <h2 class="text-4xl font-semibold tracking-tight text-gray-900 dark:text-white">
        Calculate the Determinant of a Matrix
      </h2>
      <p class="mt-4 text-lg text-gray-600 dark:text-gray-300">
        Easily calculate the determinant of your matrix. Provide the matrix below and optionally view step-by-step
        calculations.
      </p>
    </div>

    <!-- Matrix Input section -->
    <div class="flex flex-col items-center">
      <LoadingSpinner v-if="isLoading" />
      
      <MatrixInput v-show="!isLoading"
        :isTwoInputs="false"
        apiUrl="/matrixia/determinant"
        :allowShowSteps="true"
        @taskResult="handleResult"
        @setLoading="setLoadingState"
      />
    </div>

    <!-- Result section -->
    <div
      v-if="!isLoading && calculationResult"
      class="mt-8 bg-gray-50 dark:bg-gray-800 p-6 rounded-lg shadow-md"
    >
      <h3 class="text-xl font-semibold text-gray-900 dark:text-white">Result</h3>
      <p class="mt-2 text-lg text-gray-700 dark:text-gray-300">
        Determinant: <span class="font-bold">{{ calculationResult.determinant }}</span>
      </p>

      <!-- Calculation Steps -->
      <div v-if="stepsExist && calculationResult.steps" class="mt-4">
        <h4 class="mb-2 text-lg font-semibold text-gray-900 dark:text-white">
          Calculation Steps using Gaussian elimination
        </h4>
        <div class="space-y-6">
          <div
            v-for="(stepMatrix, stepIndex) in calculationResult.steps"
            :key="stepIndex"
            class="bg-white dark:bg-gray-700 p-4 rounded-lg shadow-sm"
          >
            <p class="text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">
              Step {{ stepIndex + 1 }}
            </p>
            <table class="min-w-full border-separate border-spacing-2 border-none">
              <thead>
                <tr>
                  <th class="w-10"></th>
                  <th
                    v-for="colIndex in stepMatrix.length"
                    :key="'header-' + colIndex"
                    class="px-2 py-1 text-center text-gray-900 dark:text-gray-300"
                  >
                    {{ 'A' + colIndex }}
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(row, rowIndex) in stepMatrix" :key="'row-' + rowIndex">
                  <td
                    class="w-10 px-2 py-1 text-center font-bold text-gray-900 dark:text-gray-300"
                  >
                    {{ rowIndex + 1 }}
                  </td>
                  <td
                    v-for="(value, colIndex) in row"
                    :key="'cell-' + rowIndex + '-' + colIndex"
                    :class="[ 
                      'px-2 py-1 text-center rounded-md',
                      stepIndex === calculationResult.steps.length - 1 && rowIndex === colIndex
                        ? 'bg-yellow-200 dark:bg-yellow-500 dark:text-slate-900'
                        : 'bg-gray-50 dark:bg-gray-800',
                      'text-gray-900 dark:text-gray-300',
                    ]"
                  >
                    {{ typeof value === 'object' ? value['value'] : formatNumber(value) }}
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>

    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';
import { formatNumber } from '../utility/functions';
import MatrixInput from '../components/MatrixInput.vue';
import LoadingSpinner from '../components/LoadingSpinner.vue';

interface IDeterminantResult {
  determinant: number;
  steps?: number[][];
}

const isLoading = ref(false);
const calculationResult = ref<null | IDeterminantResult>(null);

const stepsExist = computed(
  () =>
    calculationResult.value?.steps &&
    calculationResult.value.steps.length > 0
);

const handleResult = (result: IDeterminantResult) => {
  calculationResult.value = result;
};

function setLoadingState(state: boolean) {
  isLoading.value = state;
}
</script>
