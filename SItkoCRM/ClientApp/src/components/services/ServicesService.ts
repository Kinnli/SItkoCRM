import { AbstractService } from '../http/AbstractService';
import { Service } from '../entities/Service';

export class Services extends AbstractService<Service> {
    protected _getResource(): string {
        return "services";
    }

    public constructor() {
        super();
    }
}
