const baseApi = 'https://localhost:44354/api';

export const loadProductsAsync = async (pageNumber, pageSize) => {
	const url = `${baseApi}/product?pageNumber=${pageNumber}&pageSize=${pageSize}`;
	return fetch(url).then((response) => {
		if (!response.ok) {
			throw new Error(`Error! status: ${response.status}`);
		}
		return response.json();
	});
};
