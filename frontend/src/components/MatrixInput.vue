<template>
  <div class="p-6 bg-gray-100 dark:bg-slate-800 rounded-lg shadow-lg">
    <div class="flex flex-col sm:flex-row items-center justify-center space-y-4 sm:space-y-0 sm:space-x-2">
      <div class="flex flex-col">
        <label for="rows" class="block text-sm font-medium text-gray-900 dark:text-white">Number of Rows:</label>
        <input type="number" v-model="rows" class="input-primary h-10" min="1" max="10" />
      </div>
      <div v-if="isTwoInputs" class="flex flex-col">
        <label for="cols" class="block text-sm font-medium text-gray-900 dark:text-white">Number of Columns:</label>
        <input type="number" v-model="cols" class="input-primary h-10" min="1" max="10" />
      </div>
      <button @click="generateMatrix"
        class="h-10 px-4 bg-blue-600 text-white rounded-md hover:bg-blue-700 dark:bg-blue-500 dark:hover:bg-blue-600 transition duration-150">
        Set Values
      </button>
    </div>

    <div v-if="matrix.length > 0" class="mt-4">
      <table class="min-w-full border-separate border-spacing-2 border-none">
        <tbody>
          <tr v-for="(row, rowIndex) in matrix" :key="rowIndex">
            <td v-for="(_, colIndex) in row" :key="colIndex">
              <input type="number" v-model.number="matrix[rowIndex][colIndex]" class="input-primary text-center" />
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <button @click="calculate"
      class="mt-4 px-4 py-2 bg-green-600 text-white rounded-md hover:bg-green-700 dark:bg-green-500 dark:hover:bg-green-600 transition duration-150">
      Calculate
    </button>
  </div>
</template>

<script setup lang="ts">
import { ref, defineEmits, defineProps } from 'vue';
import axios from 'axios';

const props = defineProps < { isTwoInputs: boolean, apiUrl: string } > ();
const emit = defineEmits(['taskResult']);

const rows = ref(1);
const cols = ref(1);
const matrix = ref < number[][] > ([]);

const generateMatrix = () => {
  const numberOfRows = rows.value;
  const numberOfCols = props.isTwoInputs ? cols.value : rows.value;

  matrix.value = Array.from({ length: numberOfRows }, () =>
    Array.from({ length: numberOfCols }, () => 0)
  );
};

const calculate = async () => {
  try {
    const response = await axios.post(props.apiUrl, { matrix: matrix.value });
    emit('taskResult', response.data);
  } catch (error) {
    console.error('Error sending matrix:', error);
  }
};
</script>