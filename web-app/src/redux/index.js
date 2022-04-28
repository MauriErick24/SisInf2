import { combineReducers } from 'redux';
// import { persistReducer } from 'redux-persist';
// import storage from 'redux-persist/lib/storage';

import dessertsReducer from './slices/desserts';

// const sessionPersistConfig = {
// 	key: 'session',
// 	storage,
// };

const rootReducer = combineReducers({
	desserts: dessertsReducer,
	// session: persistReducer(sessionPersistConfig, sessionReducer),
});

export default rootReducer;
