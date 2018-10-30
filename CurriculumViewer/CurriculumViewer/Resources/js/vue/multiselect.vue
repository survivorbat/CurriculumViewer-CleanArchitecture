<template>
	<div class="multi-select" v-on:mouseleave="resetFilter()">
		<input class="small" v-model="filter" v-on:keyup="applyFilters" placeholder="Zoek item" />
		<div class="scroll-pane">
			<p v-for="record in visibleRecords">
				<label>
					<input type="checkbox" :name="inputName" :value="record.id" v-model="record.checked" />
					<span v-on:click="check(record.id)">{{ record.name || record.description || record.id }}</span>
				</label>
			</p>
		</div>
	</div>
</template>

<script>
	import Vue from "vue";

	export default {
		name: 'app-multi-select',
		data: function () {
			return {
				visibleRecords: [],
				records: [],
				filter: ""
			}
		},
		props: {
			dataRecords: {
				type: Array,
				default: []
			},
			inputName: {
				type: String
			},
			currentValues: {
				type: Array,
				default: []
			}
		},
		mounted() {
			this.records = this.dataRecords.map((i) => ({ ...i, checked: this.currentValues.includes(i.id + "") }));
			this.visibleRecords = [...this.records];
		},
		methods: {
			applyFilters: function () {
				let newData = [...this.records];
				if (this.filter === "") {
					this.visibleRecords = newData;
				}
				newData = newData.filter((item) => ((item.description || item.name || item.id) + "").toLowerCase().includes((this.filter + "").toLowerCase()));
				this.visibleRecords = newData;
			},
			check: function (key) {
				this.records = this.records.map((e) => {
					return e.id == key ? ({ ...e, checked: !e.checked }) : e;
				});
				this.applyFilters();
			},
			resetFilter: function () {
				this.filter = "";
				this.applyFilters();
			}
		}
	}
</script>

<style scoped lang="scss">

</style>