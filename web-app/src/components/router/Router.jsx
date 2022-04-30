import React, { lazy, Suspense } from 'react';
import PublicRoute from './PublicRoute';
import { Route, Routes } from 'react-router-dom';

const DessertsPage = lazy(() => import('../../routes/desserts'));
const LoginPage = lazy(() => import('../../routes/login'));

const AppRouter = () => {
	return (
		<Suspense fallback={<React.Fragment>Loading...</React.Fragment>}>
			<Routes>
				<Route
					element={
						<PublicRoute title='Desserts'>
							<DessertsPage />
						</PublicRoute>
					}
					path='/'
				/>
				<Route
					element={
						<PublicRoute title='Login'>
							<LoginPage />
						</PublicRoute>
					}
					path='/login'
				/>
				<Route path='*' element={'Not found'} />
			</Routes>
		</Suspense>
	);
};

export default AppRouter;
