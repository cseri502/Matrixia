<template>
  <div class="relative mx-auto min-h-screen max-w-7xl px-4 py-8 flex flex-col">
    <!-- Title -->
    <div class="text-center mb-8">
      <h2 class="text-4xl font-extrabold tracking-tight text-gray-900 dark:text-white">
        Calculate the Determinant of a Matrix
      </h2>
      <p class="mt-4 text-lg text-gray-600 dark:text-gray-300">
        Easily calculate the determinant of your matrix. Provide the matrix below and optionally view step-by-step
        calculations.
      </p>
    </div>

    <!-- Matrix Input section -->
    <div class="flex flex-col items-center">
      <MatrixInput :isTwoInputs="false" apiUrl="/matrixia/determinant" :apiParams="{ showSteps }"
        @taskResult="handleResult" />

      <!-- Show Steps input button -->
      <div class="mt-4 flex items-center space-x-2">
        <input id="showSteps" type="checkbox" v-model="showSteps"
          class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:bg-gray-700 dark:border-gray-600" />
        <label for="showSteps" class="text-sm font-medium text-gray-900 dark:text-gray-300">
          Show Calculation Steps
        </label>
      </div>
    </div>

    <!-- Result section -->
    <div v-if="calculationResult" class="mt-8 bg-gray-50 dark:bg-gray-800 p-6 rounded-lg shadow-md">
      <h3 class="text-xl font-semibold text-gray-900 dark:text-white">Result</h3>
      <p class="mt-2 text-lg text-gray-700 dark:text-gray-300">
        Determinant: <span class="font-bold">{{ calculationResult.determinant }}</span>
      </p>

      <!-- Calculation Steps -->
      <div v-if="showSteps && stepsExist" class="mt-4">
        <h4 class="text-lg font-semibold text-gray-900 dark:text-white">Calculation Steps</h4>
        <div class="space-y-6">
          <div v-for="(stepMatrix, stepIndex) in calculationResult.steps?.slice(0, -1)" :key="stepIndex"
            class="bg-white dark:bg-gray-700 p-4 rounded-lg shadow-sm">
            <p class="text-sm font-medium text-gray-700 dark:text-gray-300 mb-2">
              Step {{ stepIndex + 1 }}
            </p>
            <table class="min-w-full border-separate border-spacing-2 border-none">
              <tbody>
                <tr v-for="(row, rowIndex) in stepMatrix" :key="rowIndex">
                  <td v-for="(value, colIndex) in row" :key="colIndex"
                    class="px-2 py-1 text-center text-gray-900 dark:text-gray-300 bg-gray-50 dark:bg-gray-800 rounded-md">
                    {{ formatNumber(value) }}
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
import { formatNumber } from '../utility/functions'
import MatrixInput from '../components/MatrixInput.vue';

interface IDeterminantResult {
  determinant: number; 
  steps?: number[][]
}

const showSteps = ref(false);
const calculationResult = ref<null | IDeterminantResult>(null);

const stepsExist = computed(() => calculationResult.value?.steps && calculationResult.value.steps.length > 0);

const handleResult = (result: IDeterminantResult) => {
  calculationResult.value = result;
};
</script>
