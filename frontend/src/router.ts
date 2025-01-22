import { createRouter, createWebHistory } from 'vue-router';
import Determinant from './views/Determinant.vue';
import MatrixRank from './views/MatrixRank.vue';
import MatrixOperation from './components/MatrixOperation.vue';
import PageNotFound from './views/PageNotFound.vue';
import Hero from './views/Hero.vue';

export const routes = [
  { path: '/', component: Hero, title: 'Hero Section' },
  { path: '/rank', component: MatrixRank, title: 'Matrix Rank' },
  { path: '/determinant', component: Determinant, title: 'Determinant' },
  {
    path: '/inverse',
    component: MatrixOperation,
    props: {
      title: 'Matrix Inverse',
      description: 'Easily calculate the inverse of your matrix.',
      apiUrl: '/matrixia/inverse',
      squareMatrixOnly: true,
      resultText: 'The inverse matrix is shown below:',
      resultKey: 'inverse',
    },
  },
  {
    path: '/transpose',
    component: MatrixOperation,
    props: {
      title: 'Matrix Transpose',
      description: 'Easily calculate the transposed version of your matrix.',
      apiUrl: '/matrixia/transpose',
      squareMatrixOnly: false,
      resultText: 'The transposed matrix is shown below:',
      resultKey: 'transpose',
    },
  },
  {
    path: '/adjugate',
    component: MatrixOperation,
    props: {
      title: 'Matrix Adjoint',
      description: 'Easily calculate the adjoint (or adjugate) of your matrix.',
      apiUrl: '/matrixia/adjugate',
      squareMatrixOnly: true,
      resultText: 'The adjugate matrix is shown below:',
      resultKey: 'adjugate',
    },
  },
  { path: '/:catchAll(.*)', component: PageNotFound }
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default router;