const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "weatherforecast",
    "vendingmachine",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://libtech-api:7148',
        secure: false,
        changeOrigin: true
    });

    app.use(appProxy);
};
