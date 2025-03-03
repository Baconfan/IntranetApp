const path = require("path");
var webpack = require("webpack");

module.exports = {
    
    entry: "./scripts/app.ts", // Your main TypeScript file
    output: {
        filename: "./js/bundle.js",
        path: path.resolve(__dirname, "wwwroot/")
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader",
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: [".ts", ".js"]
    },
    mode: "development"  // Change to "production" for optimized output
};