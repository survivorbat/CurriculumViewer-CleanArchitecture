/// <binding BeforeBuild='Run - Development' />
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
	target: 'web',
	mode: 'production',
	entry: ['./Resources/js/main.js'],
	devtool: "source-map",
	resolve: {
		extensions: ['.js', '.css', '.scss', '.html', '.sass']
	},
	output: {
		filename: 'js/[name].js',
		path: __dirname + '/wwwroot'
	},
	module: {
		rules: [
			{
				test: /\.scss$/,
				use: [
					{
						loader: MiniCssExtractPlugin.loader
					},
					"css-loader",
					"sass-loader"
				]
			},
			{
				test: /\.css$/,
				use: [
					{
						loader: MiniCssExtractPlugin.loader
					},
					"css-loader"
				]
			},
			{
				test: /\.jpg|\.png/,
				loader: ['file-loader?name=images/[name].[ext]']
			},
			{
				test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
				use: ['file-loader?name=/fonts/[name].[ext]']
			},
			{
				test: /\.(ttf|otf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
				loader: ['file-loader?name=/fonts/[name].[ext]']
			},
			{
				test: /\.vue$/,
				use: ["vue-loader"]
			}
		]
	},
	plugins: [
		new MiniCssExtractPlugin({
			filename: "./css/[name].css",
			chunkFilename: "[id].css"
		}),
		new VueLoaderPlugin(),
		new OptimizeCSSAssetsPlugin()
	]
};