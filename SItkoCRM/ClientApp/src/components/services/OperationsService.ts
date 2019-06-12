import { AbstractService } from '../http/AbstractService';
import { Operation } from '../entities/Operation';

export class Operations extends AbstractService<Operation> {
    protected _getResource(): string {
        return "operations";
    }

    public constructor() {
        super();
    }
}
