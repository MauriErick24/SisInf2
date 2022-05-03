const baseApi = 'https://localhost:44354/api/auth';

export const loginAsync = async (entity) => {
	const url = `${baseApi}/login`;
	return fetch(url, {
		method: 'POST',
		headers: {
			Accept: 'application/json',
			'Content-Type': 'application/json',
		},
		body: JSON.stringify(entity),
	}).then((response) => {
		if (!response.ok) {
			throw new Error(`Error! status: ${response.status}`);
		}
		return response.json();
	});
};
