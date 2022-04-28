import React from 'react';
import { Helmet } from 'react-helmet';

const PublicRoute = ({ children, title }) => {
	return (
		<>
			<Helmet>
				<title>{title ? `${title} - EC` : 'EC'}</title>
			</Helmet>
			{children}
		</>
	);
};

export default PublicRoute;
