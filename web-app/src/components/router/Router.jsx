import React, { lazy, Suspense } from 'react';
import PublicRoute from './PublicRoute';
import { Route, Routes } from 'react-router-dom';

const DessertsPage = lazy(() => import('../../routes/desserts'));

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
				<Route path='*' element={'Not found'} />
			</Routes>
		</Suspense>
	);
};

export default AppRouter;
