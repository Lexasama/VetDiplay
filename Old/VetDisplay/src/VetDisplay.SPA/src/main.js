import './main.vendors'
import './main.auth'
import AuthService from './services/AuthService'
import Vue from 'vue'
import App from './components/App.vue'
import router from './main.router'
import BootstrapVue from 'bootstrap-vue'
Vue.config.productionTip = false
Vue.use(BootstrapVue);
const main = async() => {
  await AuthService.init();

  new Vue({
    router,BootstrapVue,
    render: h => h(App)
  }).$mount('#app')
};

main();