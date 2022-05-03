import React from 'react';
import { Link } from 'react-router-dom';
import Container from '@mui/material/Container';
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import makeStyles from '@mui/styles/makeStyles';
import { useSelector } from 'react-redux';
import { sessionSelector } from '../../redux/slices/session';

const useStyles = makeStyles({
	container: {
		alignItems: 'center',
		backgroundColor: '#A0BDA7',
		display: 'flex !important',
		height: '48px',
		justifyContent: 'space-between',
	},
	center: {},
	left: {},
	right: {
		alignItems: 'center',
		display: 'flex',
		gap: '10px',
	},
	theme: {
		alignItems: 'center',
		cursor: 'pointer',
		display: 'flex',
	},
	login: {
		textDecoration: 'none',
	},
});

const Header = ({ content }) => {
	const { authenticated } = useSelector(sessionSelector);
	const classNames = useStyles();

	return (
		<header className='header'>
			<Container className={classNames.container} maxWidth={false}>
				<div className={classNames.left}>ECommerce SI2</div>
				<div className={classNames.center}>{content}</div>
				<div className={classNames.right}>
					<div className={classNames.theme}>
						{authenticated ? (
							<AccountCircleIcon />
						) : (
							<Link className={classNames.login} to='/login'>
								Login
							</Link>
						)}
					</div>
				</div>
			</Container>
		</header>
	);
};

export default Header;
