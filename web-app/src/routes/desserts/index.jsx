import { Box, Button, TextField } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { dessertsSelector, addDessert, getDesserts } from '../../redux/slices/desserts';

const emptyValue = { name: '', price: 0 };

const DessertsPage = () => {
	const dispatch = useDispatch();
	const { desserts, loading } = useSelector(dessertsSelector);
	const [newValue, setNewValue] = useState(emptyValue);

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
		<React.Fragment>
			<h2>Desserts</h2>
			<div>
				<Box component='form'>
					<TextField
						id='input-name'
						label='Name'
						value={newValue.name}
						onChange={(e) => handleOnChange('name', e.target.value)}
						error={loading === 'failed'}
						helperText={loading === 'failed' && 'Dessert already exists'}
					/>
					<TextField
						id='input-price'
						label='Price'
						value={newValue.price}
						onChange={(e) => handleOnChange('price', e.target.value)}
					/>
					<Button onClick={handleSubmit}>Add Dessert</Button>
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
		</React.Fragment>
	);
};

export default DessertsPage;
