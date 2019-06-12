import { AbstractService } from '../http/AbstractService';
import { DomainStatus } from '../entities/DomainStatus';

export class DomainStatusService extends AbstractService<DomainStatus> {
    protected _getResource(): string {
        return "domainstatus";
    }

    public constructor() {
        super();
    }
}
