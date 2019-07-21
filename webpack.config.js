var webpack = require('webpack'),
    path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const isProduction = process.env.NODE_ENV === 'production';

module.exports = {
    mode: 'development',
    entry: {
        main: './index.js'
    },
    output: {
        path: path.join(__dirname, 'wwwroot/dist'),
        filename: '[name].js'
    },
    module: {
        rules: [{
            test: /\.js$/,
            use: [{ loader: "babel-loader" }]
        },
        {
            test: /\.less$/,
            use: [
                'style-loader',
                'css-loader',
                'less-loader'
            ]
        }],
    },
    devtool: process.env.NODE_ENV !== 'production' ? 'source-map' : null,
    plugins: isProduction ? [new MiniCssExtractPlugin()] : []
};