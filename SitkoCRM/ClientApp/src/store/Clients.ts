import {Client} from '../components/entities/Client';
import {ClientsService} from '../components/services/ClientsService';
import {IRestResponse} from 'typed-rest-client/RestClient';
import {AbstractListResult} from '../components/http/AbstractService';

const requestClientsType = 'REQUEST_CLIENTS';
const receiveClientsType = 'RECEIVE_CLIENTS';
const initialState = {clients: [], isLoading: false};

export const actionCreators = {
    requestClients: () => async (dispatch, getState) => {
        dispatch({type: requestClientsType});

        let clientsService = new ClientsService();
        clientsService.getAll().then((res: IRestResponse<AbstractListResult<Client>>) => {

            if (res.result != null) {
                let clients = res.result.data;
                dispatch({type: receiveClientsType, clients});
            }
        });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestClientsType) {
        return {
            ...state,
            isLoading: true
        };
    }

    if (action.type === receiveClientsType) {
        return {
            ...state,
            clients: action.clients,
            isLoading: false
        };
    }

    return state;
};
