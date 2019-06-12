import { AbstractService } from '../http/AbstractService';
import { Domain } from '../entities/Domain';

export class DomainsService extends AbstractService<Domain> {
    protected _getResource(): string {
        return "domains";
    }

    public constructor() {
        super();
    }
}
