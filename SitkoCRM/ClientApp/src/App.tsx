import React, { Component } from 'react';
import { Route } from 'react-router';
import { Router } from 'react-router-dom';
import { createBrowserHistory } from 'history';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import ContactList from './components/ClientContactsList';

// Externals
//import { Chart } from 'react-chartjs-2';

// Material helpers
import { ThemeProvider } from '@material-ui/styles';

// ChartJS helpers
import { chartjs } from './helpers';

// Theme
import theme from './theme';

// Styles
import 'react-perfect-scrollbar/dist/css/styles.css';
import './assets/scss/index.scss';

// Routes
import Routes from './Routes';

// Browser history
const browserHistory = createBrowserHistory();

// Configure ChartJS
/*
Chart.helpers.extend(Chart.elements.Rectangle.prototype, {
    draw: chartjs.draw
});*/


export default class App extends Component {
    render() {
        return (
            <ThemeProvider theme={theme}>
                <Router history={browserHistory}>
                    <Routes />
                </Router>
            </ThemeProvider>
        );
    }
}

/*
export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/contacts' component={ContactList} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);*/
