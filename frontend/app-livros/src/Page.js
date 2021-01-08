import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import Routes from './Routes';

function Page() {
  return (
    <BrowserRouter>
      <Routes />
    </BrowserRouter>
  );
}

export default Page;