<template>
  <div class="p-6 bg-gray-100 dark:bg-slate-800 rounded-lg shadow-lg min-w-full md:min-w-[30rem]">
    <!-- Generate matrix -->
    <div class="p-4 bg-white dark:bg-slate-700 rounded-lg shadow-md mb-6">
      <div class="flex items-center justify-between">
        <div class="flex gap-4">
          <div class="flex flex-col">
            <label for="rows" class="block text-sm font-medium text-gray-900 dark:text-white">
              {{ props.isTwoInputs ? "Number of Rows:" : "Size of Matrix:" }}
            </label>
            <input type="number" v-model="rows" class="input-primary h-10" min="1" max="10" />
          </div>
          <div v-if="isTwoInputs" class="flex flex-col">
            <label for="cols" class="block text-sm font-medium text-gray-900 dark:text-white">
              Number of Columns:
            </label>
            <input type="number" v-model="cols" class="input-primary h-10" min="1" max="10" />
          </div>
        </div>
        <div>
          <button @click="generateMatrix"
            class="h-10 px-6 bg-blue-600 text-white rounded-md hover:bg-blue-700 dark:bg-blue-500 dark:hover:bg-blue-600 transition duration-150">
            Set Values
          </button>
        </div>
      </div>
    </div>


    <!-- Matrix table -->
    <div v-if="matrix.length > 0" class="mt-6 overflow-x-auto">
      <table class="min-w-full border-separate border-spacing-2 border-none">
        <thead>
          <tr>
            <th></th>
            <th v-for="colIndex in matrix[0].length" :key="'header-' + colIndex"
              class="text-center text-gray-900 dark:text-gray-300">
              {{ 'A' + colIndex }}
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(row, rowIndex) in matrix" :key="'row-' + rowIndex">
            <td class="text-center font-bold text-gray-900 dark:text-gray-300">
              {{ rowIndex + 1 }}
            </td>
            <td v-for="(_, colIndex) in row" :key="'cell-' + rowIndex + '-' + colIndex">
              <input type="number" v-model.number="matrix[rowIndex][colIndex]"
                class="input-primary text-center w-full" />
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- Calculate button -->
    <div v-if="matrix.length > 0" class="flex justify-end mt-4">
      <button @click="calculate"
        class="px-6 py-2 bg-green-600 text-white rounded-md hover:bg-green-700 dark:bg-green-500 dark:hover:bg-green-600 transition duration-150">
        Calculate
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios';

const props = defineProps<{
  isTwoInputs: boolean;
  apiUrl: string;
  apiParams?: Record<string, any>;
}>();
const emit = defineEmits(['taskResult', 'setLoading']);

const rows = ref(1);
const cols = ref(1);
const matrix = ref<number[][]>([]);

const generateMatrix = () => {
  const numberOfRows = rows.value;
  const numberOfCols = props.isTwoInputs ? cols.value : rows.value;

  matrix.value = Array.from({ length: numberOfRows }, () =>
    Array.from({ length: numberOfCols }, () => 0)
  );
};

async function calculate() {
  emit('setLoading', true);
  try {
    const payload = {
      matrix: matrix.value,
      ...props.apiParams,
    };

    const response = await axios.post(props.apiUrl, payload);
    emit('taskResult', response.data);
    emit('setLoading', false);
  } catch (error) {
    console.error('Error sending matrix:', error);
  }
};
</script>
