import { Container } from '@mui/material';
import makeStyles from '@mui/styles/makeStyles';
import React from 'react';
import Header from './Header';

const useStyles = makeStyles({
	root: {
		backgroundColor: '#D5FCDF',
		height: '100vh',
	},
	container: {
		marginTop: '20px',
	},
});
const Layout = ({ children, contentHeader }) => {
	const classNames = useStyles();

	return (
		<div className={classNames.root}>
			<Header content={contentHeader} />
			<Container className={classNames.container} maxWidth='lg'>
				{children}
			</Container>
		</div>
	);
};

export default Layout;
