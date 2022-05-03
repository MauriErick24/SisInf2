import { createAsyncThunk, createSelector, createSlice } from '@reduxjs/toolkit';
import { addDessertsAsync, getDessertsAsync } from '../../api/dessertsAPI';

export const getDesserts = createAsyncThunk('getDesserts/getDessertsAsync', async () => {
	const desserts = await getDessertsAsync();

	return desserts;
});

export const addDessert = createAsyncThunk('addDesserts/addDessertsAsync', async (dessert) => {
	const newDessert = await addDessertsAsync(dessert);

	return newDessert;
});

const initialState = {
	loading: 'idle',
	desserts: [],
};

export const dessertsSlice = createSlice({
	name: 'desserts',
	initialState,
	reducers: {
		reset: (state) => {
			state.desserts = [];
			state.loading = 'idle';
		},
	},
	extraReducers: (builder) => {
		builder.addCase(addDessert.pending, (state, _) => {
			state.loading = 'pending';
		});
		builder.addCase(addDessert.fulfilled, (state, { payload }) => {
			if (typeof payload === 'string') {
				state.loading = 'failed';
			} else {
				state.desserts = [...state.desserts, payload];
				state.loading = 'succeeded';
			}
		});
		builder.addCase(addDessert.rejected, (state, _) => {
			state.loading = 'failed';
		});
		builder.addCase(getDesserts.pending, (state, _) => {
			state.loading = 'pending';
		});
		builder.addCase(getDesserts.fulfilled, (state, { payload }) => {
			state.desserts = payload.data;
			state.loading = 'succeeded';
		});
		builder.addCase(getDesserts.rejected, (state, _) => {
			state.loading = 'failed';
		});
	},
});

export const dessertsSelector = createSelector(
	(state) => ({
		...state.desserts,
	}),
	(state) => state
);

export const { reset } = dessertsSlice.actions;

export default dessertsSlice.reducer;
