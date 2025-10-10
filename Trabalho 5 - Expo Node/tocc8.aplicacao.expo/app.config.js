import 'dotenv/config';

export default {
    expo: {
        name: 'MeuApp',
        slug: 'meuapp',
        version: '1.0.0',
        extra: {
            apiUrl: process.env.API_URL
        },
    },
};