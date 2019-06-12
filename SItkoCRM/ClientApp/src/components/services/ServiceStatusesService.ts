import { AbstractService } from '../http/AbstractService';
import { ServiceStatus } from '../entities/ServiceStatus';

export class ServiceStatuses extends AbstractService<ServiceStatus> {
    protected _getResource(): string {
        return "servicestatuses";
    }

    public constructor() {
        super();
    }
}
