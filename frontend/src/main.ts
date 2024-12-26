import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import router from "./router";
import * as FaIcons from "oh-vue-icons/icons/fa";
import { BiSunFill, BiMoonFill } from "oh-vue-icons/icons";
import { addIcons, OhVueIcon } from "oh-vue-icons";

const Fa = Object.values({ ...FaIcons });
addIcons(...Fa, BiSunFill, BiMoonFill);

createApp(App).use(router).component("v-icon", OhVueIcon).mount("#app");
