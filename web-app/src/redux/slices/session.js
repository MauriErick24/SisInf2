import { createAsyncThunk, createSelector, createSlice } from '@reduxjs/toolkit';
import { loginAsync } from '../../api/authAPI';

const TOKEN = 'token';

const initialState = {
	authenticated: false,
	loading: 'idle',
	pathToRedirect: '',
	user: undefined,
};

export const login = createAsyncThunk('login/loginAsync', async (response) => {
	const user = await loginAsync(response);
	const { token } = user;
	localStorage.setItem(TOKEN, token);

	return user;
});

export const sessionSlice = createSlice({
	name: 'session',
	initialState,
	reducers: {
		logout: (state) => {
			localStorage.removeItem(TOKEN);
			state.authenticated = false;
			state.user = undefined;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(login.pending, (state, _) => {
			state.loading = 'pending';
		});
		builder.addCase(login.fulfilled, (state, { payload }) => {
			state.authenticated = Boolean(payload.email);
			state.loading = 'succeeded';
			state.user = payload;
		});
		builder.addCase(login.rejected, (state, _) => {
			state.authenticated = false;
			state.loading = 'failed';
		});
	},
});

export const sessionSelector = createSelector(
	(state) => ({
		...state.session,
	}),
	(state) => state
);

export const { logout } = sessionSlice.actions;

export default sessionSlice.reducer;
