import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import configureStore from './store/configureStore';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

// Service worker
//import * as serviceWorker from './common/serviceWorker';

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;
const history = createBrowserHistory({ basename: baseUrl });


// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = (window as any).initialReduxState;
const store = configureStore(history, initialState);

const rootElement = document.getElementById('root');

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <App />
    </ConnectedRouter>
  </Provider>,
  rootElement);
 
registerServiceWorker();

//ReactDOM.render(<App />, document.getElementById('root'));

//serviceWorker.unregister();
