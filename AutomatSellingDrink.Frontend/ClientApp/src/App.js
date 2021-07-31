import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import {UserInterface} from './components/UserInterface';
import {AdminInterface} from './components/AdminInterface';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
          <Route path='/user-interface' component={UserInterface} />
          <Route path='/admin-interface' component={AdminInterface} />
      </Layout>
    );
  }
}
