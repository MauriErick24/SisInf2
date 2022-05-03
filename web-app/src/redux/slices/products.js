import { createAsyncThunk, createSelector, createSlice } from '@reduxjs/toolkit';
import { loadProductsAsync } from '../../api/productsAPI';

export const loadProducts = createAsyncThunk(
	'loadProducts/loadProductsAsync',
	async ({ pageNumber, pageSize }) => {
		const products = await loadProductsAsync(pageNumber, pageSize);

		return products;
	}
);

const initialState = {
	loading: 'idle',
	pageSize: 20,
	pageNumber: 1,
	products: [],
	totalPages: 1,
};

export const productsSlice = createSlice({
	name: 'products',
	initialState,
	reducers: {
		reset: (state) => {
			state.products = [];
			state.loading = 'idle';
		},
		setPageNumber: (state, { payload }) => {
			state.pageNumber = payload;
		},
		setPageSize: (state, { payload }) => {
			state.pageSize = payload;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(loadProducts.pending, (state, _) => {
			state.loading = 'pending';
		});
		builder.addCase(loadProducts.fulfilled, (state, { payload }) => {
			state.products = payload.data;
			state.totalPages = payload.totalPages;
			state.loading = 'succeeded';
		});
		builder.addCase(loadProducts.rejected, (state, _) => {
			state.loading = 'failed';
		});
	},
});

export const productsSelector = createSelector(
	(state) => ({
		...state.products,
	}),
	(state) => state
);

export const { reset, setPageNumber, setPageSize } = productsSlice.actions;

export default productsSlice.reducer;
