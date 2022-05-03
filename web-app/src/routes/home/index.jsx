import React, { useEffect } from 'react';
import ProductsList from './ProductsList';
import Pagination from '@mui/material/Pagination';
import { useDispatch, useSelector } from 'react-redux';
import { loadProducts, productsSelector, setPageNumber } from '../../redux/slices/products';
import { makeStyles } from '@mui/styles';

const useStyles = makeStyles({
	title: {
		fontSize: '2.5em',
		marginBottom: '15px',
	},
	pagination: {
		display: 'flex',
		justifyContent: 'right',
	},
});

const Home = () => {
	const classNames = useStyles();
	const dispatch = useDispatch();
	const { pageNumber, pageSize, totalPages } = useSelector(productsSelector);

	useEffect(() => {
		dispatch(loadProducts({ pageNumber, pageSize }));
	}, [pageNumber, pageSize, dispatch]);

	const handleChange = (_, value) => {
		dispatch(setPageNumber(value));
	};

	return (
		<div>
			<div className={classNames.title}>
				<b>Products</b>
			</div>
			<ProductsList />
			<div className={classNames.pagination}>
				<Pagination count={totalPages} page={pageNumber} onChange={handleChange} />
			</div>
		</div>
	);
};

export default Home;
