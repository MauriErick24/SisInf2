import React from 'react';
import { useSelector } from 'react-redux';
import { productsSelector } from '../../redux/slices/products';
import Container from '@mui/material/Container';
import Product from './Product';

const ProductsList = () => {
	const { loading, products } = useSelector(productsSelector);

	return (
		<Container maxWidth='lg' disableGutters>
			{loading === 'loading' ? (
				<span>Loading products...</span>
			) : loading === 'succeeded' ? (
				products.map((product) => <Product value={product} key={product.id} />)
			) : (
				<span>Failed to load products. Try again...</span>
			)}
		</Container>
	);
};

export default ProductsList;
