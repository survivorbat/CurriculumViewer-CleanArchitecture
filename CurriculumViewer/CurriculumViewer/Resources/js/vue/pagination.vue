<template>
	<div class="flex w-100 justify-between">
		<div class="input-field small-spacing">
			<select class="small-spacing" v-model="limit" v-on:change="setLimit">
				<option value="10">10 per pagina</option>
				<option value="20">20 per pagina</option>
				<option value="50">50 per pagina</option>
				<option value="100">100 per pagina</option>
			</select>
		</div>
		<span>
			<button v-for="index in (Math.ceil(count / limit))" v-on:click="setPage(index)" class="btn">{{index}}</button>
		</span>
	</div>
</template>

<script>
	export default {
		name: 'app-data-pagination',
		props: {
			count: {
				type: Number,
				default: 1
			},
			limit: {
				type: Number,
				default: 20
			},
			setPage: {
				type: Function,
			},
			setLimit: {
				type: Function,
			}
		},
	};
</script>

<style scoped lang="scss">

</style>