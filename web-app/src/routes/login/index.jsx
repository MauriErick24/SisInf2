import React, { useState } from 'react';
import { Box, Button, Checkbox, FormControlLabel, TextField } from '@mui/material';
import { useDispatch, useSelector } from 'react-redux';
import { Navigate } from 'react-router-dom';
import { login, sessionSelector } from '../../redux/slices/session';
import { makeStyles } from '@mui/styles';

const emptyValue = { username: '', password: '' };
const useStyle = makeStyles({
	root: {
		backgroundColor: '#f4ffff',
		border: 'solid',
		borderColor: 'darkcyan',
		borderWidth: '2px',
		borderRadius: '35px',
		padding: '10px 40px',
	},
	rootContainer: {
		alignContent: 'center',
		alignItems: 'center',
		height: '100vh',
	},
	container: {
		display: 'flex',
		justifyContent: 'center',
	},
	items: {
		margin: '10px 0px !important',
		justifyContent: 'center',
	},
});

const Login = () => {
	const dispatch = useDispatch();
	const { authenticated, loading } = useSelector(sessionSelector);
	const [newValue, setNewValue] = useState(emptyValue);
	const [showPassword, setShowPassword] = useState(false);
	const classNames = useStyle();

	const handleOnChange = (name, value) => {
		const changedValue = { ...newValue };
		changedValue[name] = value;
		setNewValue(changedValue);
	};

	const handleSubmit = () => {
		dispatch(login(newValue));
	};

	return (
		<div className={classNames.container + ' ' + classNames.rootContainer}>
			<div className={classNames.root}>
				<div className={classNames.container}>
					<h2>Login</h2>
				</div>
				<div className={classNames.container}>
					<Box component='form'>
						<TextField
							className={classNames.items}
							id='input-username'
							label='Email'
							value={newValue.name}
							onChange={(e) => handleOnChange('username', e.target.value)}
							error={loading === 'failed'}
							helperText={loading === 'failed' && 'Invalid account'}
						/>
						<br />
						<TextField
							className={classNames.items}
							id='input-password'
							label='Password'
							type={showPassword ? 'text' : 'password'}
							value={newValue.password}
							onChange={(e) => handleOnChange('password', e.target.value)}
							error={loading === 'failed'}
							helperText={loading === 'failed' && 'Invalid account'}
						/>
						<br />
						<FormControlLabel
							control={
								<Checkbox
									checked={showPassword}
									onClick={() => setShowPassword((prev) => !prev)}
								/>
							}
							label='Show Password'
						/>
						<br />
						<div className={classNames.container}>
							<Button className={classNames.items} onClick={handleSubmit}>
								Sign In
							</Button>
						</div>
					</Box>
				</div>
			</div>
			{authenticated && <Navigate to='/' />}
		</div>
	);
};

export default Login;
