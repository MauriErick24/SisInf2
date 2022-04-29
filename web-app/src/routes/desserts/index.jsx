import { Box, Button, TextField } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { dessertsSelector, addDessert, getDesserts } from '../../redux/slices/desserts';

import makeStyles from '@mui/styles/makeStyles';

 const useStyles = makeStyles({ 
	Items: {
		display: "flex",
		justifyContent: "center",

 	},
	Border:{
		    border: "solid",
    		borderColor: "chocolate",
    		borderWidth: "medium",
    		borderRadius: "60px",
    		padding: "20px",
    		width: "30%",
	} ,
	borderBut:{
		justifyContent: "right",
		display: "flex",
	}	
});


const emptyValue = { name: null, lastname: null, email: null, birthdate: null};

const DessertsPage = () => {
	const dispatch = useDispatch();
	const { desserts, loading } = useSelector(dessertsSelector);
	const [newValue, setNewValue] = useState(emptyValue);

	const classNames = useStyles();

	useEffect(() => {
		dispatch(getDesserts());
	}, []);

	const handleOnChange = (name, value) => {
		const changedValue = { ...newValue };
		changedValue[name] = value;
		setNewValue(changedValue);
	};

	const handleSubmit = () => {
		dispatch(addDessert(newValue));
	};



	return (
		<div className={
			classNames.Items	
	}>
		<div className={
			classNames.Border	
	}>
			<h2 align="center">SIGN UP</h2>
			<div className={
					classNames.Items	
			}>
				<Box component='form' >
					<TextField className={
					classNames.Items	
					}
						id='input-name'
						label='Name'
						value={newValue.name}
						onChange={(e) => handleOnChange('name', e.target.value)}
						
					/>
					<br /><br />
					<TextField
						id='input-lastname'
						label='Lastname'
						value={newValue.lastname}
						onChange={(e) => handleOnChange('lastname', e.target.value)}
					/>
					<br /><br />
					<TextField
						id='input-email'
						label='e-mail'
						value={newValue.email}
						onChange={(e) => handleOnChange('email', e.target.value)}
						// error={loading === 'failed'}
						// helperText={loading === 'failed' && 'e-mail already exists'}
					/>
					<br /><br />
					<TextField
						id='input-password'
						label='Password'
						value={newValue.password}
						onChange={(e) => handleOnChange('password', e.target.value)}
					/>

					{/* 
						<InputLabel htmlFor="outlined-adornment-password">Password</InputLabel>
         				<OutlinedInput
         				  id="outlined-adornment-password"
         				  type={values.showPassword ? 'text' : 'password'}
         				  value={values.password}
         				  onChange={handleChange('password')}
         				  endAdornment={
         				    <InputAdornment position="end">
         				      <IconButton
         				        aria-label="toggle password visibility"
         				        onClick={handleClickShowPassword}
         				        onMouseDown={handleMouseDownPassword}
         				        edge="end"
         				      >
         				        {values.showPassword ? <VisibilityOff /> : <Visibility />}
         				      </IconButton>
         				    </InputAdornment>
         				  }
         				  label="Password"
         				/>
       					 </FormControl>
					*/}

					<br /><br />
					<TextField
						id='input-birthdate'
						label='Birthdate'
						value={newValue.birthdate}
						onChange={(e) => handleOnChange('birthdate', e.target.value)}
					/>
					<br /><br />
					<div className={
						classNames.borderBut	
					}>
						<Button onClick={handleSubmit}>Let's sell</Button>
					</div>
				</Box>
			</div>

			<div className='desserts'>
				<ul>
					{desserts.map((dessert) => (
						<li
							key={dessert.id}
						>{`Name: ${dessert.name} - Price: ${dessert.price}`}</li>
					))}
				</ul>
			</div>

		</div>
	</div>
	);
};

export default DessertsPage;
