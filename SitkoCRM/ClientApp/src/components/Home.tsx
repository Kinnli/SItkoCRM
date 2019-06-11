import React, {Component} from 'react';
import {bindActionCreators} from 'redux';
import {connect} from 'react-redux';
import {actionCreators} from '../store/Clients';
import {Client} from './entities/Client';
import {CrmStore} from '../store/configureStore';


interface ClientsState {
    clients: Client[];
    requestClients();
}

class Home extends Component<ClientsState> {

    ensureDataFetched(): void {
        this.props.requestClients();
    }

    componentDidMount() {
        console.log('mount');
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    render(): React.ReactElement<any, string | React.JSXElementConstructor<any>> | string | number | {} | React.ReactNodeArray | React.ReactPortal | boolean | null | undefined {
        return (
            <div>
                <h2>Clients</h2>
                <ul>
                    {this.props.clients.map((client, i) => {
                        return (<li>{client.id}: {client.name}</li>)
                    })}
                </ul>
            </div>
        );
    }
}


export default connect(
    (state: CrmStore) => state.clientsReducer,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
