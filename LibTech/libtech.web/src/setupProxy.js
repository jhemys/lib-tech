﻿const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "api/vendingmachine",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7148',
        secure: false
    });

    app.use(appProxy);
};
