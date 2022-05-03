import { combineReducers } from 'redux';
import { persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';

import dessertsReducer from './slices/desserts';
import productsReducer from './slices/products';
import sessionReducer from './slices/session';

const sessionPersistConfig = {
	key: 'session',
	storage,
};

const rootReducer = combineReducers({
	desserts: dessertsReducer,
	products: productsReducer,
	session: persistReducer(sessionPersistConfig, sessionReducer),
});

export default rootReducer;
