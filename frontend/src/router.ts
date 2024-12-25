import { createRouter, createWebHistory } from 'vue-router';
import Determinant from './views/Determinant.vue';
import InverseMatrix from './views/InverseMatrix.vue';
import MatrixRank from './views/MatrixRank.vue';
import MatrixTranspose from './views/MatrixTranspose.vue';
import Adjugate from './views/Adjugate.vue';
import PageNotFound from './views/PageNotFound.vue';
import Hero from './views/Hero.vue';

export const routes = [
  { path: '/', component: Hero, title: 'Hero Section' },
  { path: '/rank', component: MatrixRank, title: 'Matrix Rank' },
  { path: '/determinant', component: Determinant, title: 'Determinant' },
  { path: '/inverse', component: InverseMatrix, title: 'Inverse Matrix' },
  { path: '/transpose', component: MatrixTranspose, title: 'Matrix Transpose' },
  { path: '/adjugate', component: Adjugate, title: 'Adjugate Matrix' },
  { path: '/:catchAll(.*)', component: PageNotFound }
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default router;