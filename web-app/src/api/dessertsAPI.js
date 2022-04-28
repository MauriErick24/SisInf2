export const addDessertsAsync = async (entity) => {
	const url = 'https://localhost:44354/api/dessert';
	return fetch(url, {
		method: 'POST',
		headers: {
			Accept: 'application/json',
			'Content-Type': 'application/json',
		},
		body: JSON.stringify(entity),
	}).then((response) => response.json());
};

export const getDessertsAsync = async () => {
	const url = 'https://localhost:44354/api/dessert';
	return fetch(url).then((response) => response.json());
};
