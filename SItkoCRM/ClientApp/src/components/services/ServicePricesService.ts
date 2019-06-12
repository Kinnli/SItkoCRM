import { AbstractService } from '../http/AbstractService';
import { ServicePrice } from '../entities/ServicePrice';

export class ServicePrices extends AbstractService<ServicePrice> {
    protected _getResource(): string {
        return "serviceprices";
    }

    public constructor() {
        super();
    }
}
