const path = require('path')
const { VueLoaderPlugin } = require('vue-loader')

module.exports = {

    mode: 'development',

    entry: {
        auth: './src/auth/main.js',
        register: './src/register/main.js',
        confirm: './src/confirm/main.js',
        admin: './src/admin/main.js',
    },

    output: {
        path: path.resolve(__dirname, './wwwroot/js'),
        filename: '[name].js'
    },

    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },

            {
                test: /\.js$/,
                loader: 'babel-loader'
            },

            {
                test: /\.css$/,
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            },

            {
                test: /\.png$/,
                use: [{
                    loader: 'file-loader',
                    options: {
                        outputPath: 'img'
                    }
                }],
            },
        ]
    },

    plugins: [
        new VueLoaderPlugin()
    ]

}