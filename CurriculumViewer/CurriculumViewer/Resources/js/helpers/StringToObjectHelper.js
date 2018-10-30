export default class StringToObjectHelper {
	static getValueFromObject(string, object) {
		/* If the string does not even have a nested property then don't bother */
		if (!string.includes(".")) {
			return object[string];
		}

		/* Loop through the layers of the nested object and extract the value */
		const nestedObject = string.split(".");
		let value = {...object};

		nestedObject.forEach((nestedKey) => {
			if (value[nestedKey]) {
				value = value[nestedKey];
			}
		});

		return value;
	}
}