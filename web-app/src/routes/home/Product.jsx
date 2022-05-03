import React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import makeStyles from '@mui/styles/makeStyles';

const useStyles = makeStyles({
	root: {
		marginBottom: '20px',
	},
});

const Product = ({ value }) => {
	const classNames = useStyles();
	const { name, price, description } = value;

	return (
		<Card sx={{ minWidth: 275 }} className={classNames.root}>
			<CardContent>
				<Typography variant='h5' component='div'>
					{name}
				</Typography>
				<Typography sx={{ mb: 1.5 }} color='text.secondary'>
					Price: Bs. {price}
				</Typography>
				<Typography variant='body2'>{description}</Typography>
			</CardContent>
		</Card>
	);
};

export default Product;
