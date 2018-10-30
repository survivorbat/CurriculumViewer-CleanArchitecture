<template>
	<div class="responsive-table">
		<table class="striped data-table highlight">
			<thead>
				<tr>
					<td v-bind:colspan="columns.length">
						<app-data-pagination :setLimit="setLimit" :limit="limit" :count="records.length" :setPage="setPage"></app-data-pagination>
					</td>
				</tr>
				<tr>
					<th v-for="name in columns" class="small-spacing">
						{{name.label}}
						<br />
						<div class="input-field small-spacing small-text">
							<input class="small" v-model="filters[name.name]" v-on:keyup="applyFilters" v-bind:placeholder="'Filter op ' + name.label" />
						</div>
					</th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="value in visibleRecords" class="data-row">
					<td v-for="column in columns">
						<a v-bind:href="detailsUrl + '/' + value.id">
							<pre>{{ value[column.name] }}</pre>
						</a>
					</td>
				</tr>
			</tbody>
			<tfoot>
				<tr>
					<td v-bind:colspan="columns.length">
						<app-data-pagination :setLimit="setLimit" :limit="limit" :count="records.length" :setPage="setPage"></app-data-pagination>
					</td>
				</tr>
			</tfoot>
		</table>
	</div>
</template>

<script>
	import Vue from "vue";

	export default {
		name: 'app-data-table',
		data: function () {
			return {
				visibleRecords: [],
				offset: 0,
				filters: {}
			}
		},
		props: {
			records: {
				type: Array,
				default: []
			},
			columns: {
				type: Array,
				default: []
			},
			limit: {
				type: Number,
				default: 20
			},
			detailsUrl: {
				type: String,
				default: null
			},
			deleteUrl: {
				type: String,
				default: null
			},
			editUrl: {
				type: String,
				default: null
			},
		},
		mounted() {
			this.visibleRecords = [...this.records].splice(this.offset, this.limit);
		},
		methods: {
			applyFilters: function () {
				let newData = [...this.records];
				Object.keys(this.filters).forEach((filterName) => {
					if (this.filters[filterName] === "") {
						return;
					}
					newData = newData.filter((item) => (item[filterName] + "").toLowerCase().includes((this.filters[filterName] + "").toLowerCase()));
				})
				this.visibleRecords = newData.splice(this.offset, this.limit);
			},
			setPage: function (page) {
				this.offset = ((this.limit * page) - this.limit);
				this.applyFilters();
			},
			setLimit: function ({ target }) {
				this.limit = target.value;
				this.offset = 0;
				this.applyFilters();
			}
		}
	}
</script>

<style scoped lang="scss">

</style>