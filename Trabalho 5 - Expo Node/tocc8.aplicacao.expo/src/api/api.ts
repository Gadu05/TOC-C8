import axios from 'axios';

import Constants from 'expo-constants';

const apiUrl = Constants.manifest?.extra?.apiUrl;
console.log(apiUrl); // https://meuapi.com

const api = axios.create({
    baseURL: apiUrl,
});

export default api;