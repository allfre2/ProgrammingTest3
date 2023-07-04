export interface Config {
    api: string;
    port: string;
    productsEndpoint: string;
    modelsEndpoint: string;
}

const DefaultConfig : Config = {
    api: 'http://localhost:',
    port: '5279',
    productsEndpoint: '/api/Product',
    modelsEndpoint: '/api/Model'
};

export { DefaultConfig };