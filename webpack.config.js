var path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = {
    mode: 'development',
    entry: {
        home: './webpackconfig/home.js',
        news: './webpackconfig/news.js',
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
                'style-loader', MiniCssExtractPlugin.loader, 'css-loader'
            ]
        }],
    },
    devtool: process.env.NODE_ENV !== 'production' ? 'source-map' : null,
    plugins: [new MiniCssExtractPlugin({
        filename: "[name].css"
    })]
};