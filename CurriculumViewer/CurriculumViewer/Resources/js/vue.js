import Vue from "vue";
import table from "./vue/table.vue";
import pagination from "./vue/pagination.vue";
import StringToObjectHelper from "./helpers/StringToObjectHelper";
import multiselect from "./vue/multiselect.vue";

/* Declare components */
Vue.component('app-data-pagination', pagination);
Vue.component('app-data-table', table);

/* Export Vue instance */
const tables = document.querySelectorAll("app-data-table");

for (let i = 0; i < tables.length; i++) {
	const appDataTable = new Vue({
		el: tables[i],
		data: {
			columns: [],
			records: [],
			limit: 20
		},
		beforeMount() {
			if (!this.$el || !this.$el.dataset.columns) {
				return;
			}
			/* Get the columns from the data attribute, split it in label and name */
			this.columns = this.$el.dataset.columns.split(",").map((column) => {
				const data = column.split(":");
				return { label: data[1], name: data[0] };
			});

			/* Convert the records to be usable in the table, flatten the objects */
			this.records = JSON.parse(this.$el.dataset.records).map((record) => {
				let dataObject = {};

				// Carry over Id
				dataObject.id = record.id;

				/* Flatten object by extracting nested values and bringing them up top */
				this.columns.forEach((columnObject) => {
					if (!columnObject.name.includes(".")) {
						dataObject[columnObject.name] = record[columnObject.name];
					} else {
						const propertyValue = StringToObjectHelper.getValueFromObject(columnObject.name, record);
						dataObject[columnObject.name] = propertyValue;
					}
				});
				return dataObject;
			});

			/* Set limit and urls */
			this.limit = this.$el.dataset.limit;
			this.detailsUrl = this.$el.dataset.url_details;
		},
		render: function (createElement) {
			return createElement(table, {
				props: { columns: this.columns, records: this.records, limit: this.limit, detailsUrl: this.detailsUrl }
			});
		}
	});
}

Vue.component('app-select-list', multiselect);

const lists = document.querySelectorAll("app-select-list");

for (let i = 0; i < lists.length; i++) {
	const appSelectList = new Vue({
		el: lists[i],
		data: {
			records: [],
			inputName: ""
		},
		beforeMount() {
			this.records = JSON.parse(this.$el.dataset.records);
			this.inputName = this.$el.dataset.inputname;
			this.currentValues = JSON.parse(this.$el.dataset.currentvalues);
		},
		render: function (createElement) {
			return createElement(multiselect, {
				props: { dataRecords: this.records, inputName: this.inputName, currentValues: this.currentValues }
			});
		}
	});
}