import { AbstractService } from '../http/AbstractService';
import { Bill } from '../entities/Bill';

export class BillsService extends AbstractService<Bill> {
    protected _getResource(): string {
        return "bills";
    }

    public constructor() {
        super();
    }
}
