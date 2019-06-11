import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import ContactList from './components/ClientContactsList';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route exact path='/contacts' component={ContactList} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);
