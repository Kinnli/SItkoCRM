import {AbstractService} from '../http/AbstractService';
import {Client} from '../entities/Client';

export class ClientsService extends AbstractService<Client> {
    protected _getResource(): string {
        return "clients";
    }

    public constructor(){
        super();
    }
}
