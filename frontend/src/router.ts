import { createRouter, createWebHistory } from 'vue-router';
import Determinant from './views/Determinant.vue';
import InverseMatrix from './views/InverseMatrix.vue';
import MatrixRank from './views/MatrixRank.vue';
import MatrixTranspose from './views/MatrixTranspose.vue';
import AdditionSubtraction from './views/AdditionSubtraction.vue';
import GaussElimination from './views/GaussElimination.vue';

const routes = [
  { path: '/determinant', component: Determinant },
  { path: '/inverse-matrix', component: InverseMatrix },
  { path: '/matrix-rank', component: MatrixRank },
  { path: '/matrix-transpose', component: MatrixTranspose },
  { path: '/addition-subtraction', component: AdditionSubtraction },
  { path: '/gauss-elimination', component: GaussElimination },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default router;