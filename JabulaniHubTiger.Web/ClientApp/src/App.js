import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import FetchData from './components/FetchData';
import BicycleData from './components/BicycleData';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={BicycleData} />
            <Route path='/counter' component={BicycleData} />
        <Route path='/fetch-data' component={FetchData} />
        
      </Layout>
    );
  }
}
