import { AbstractService } from '../http/AbstractService';
import { ClientContact } from '../entities/ClientContact';

export class ClientContactsService extends AbstractService<ClientContact> {
    protected _getResource(): string {
        return "clientcontacts";
    }

    public constructor() {
        super();
    }
}
