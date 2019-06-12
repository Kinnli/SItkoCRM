import { AbstractService } from '../http/AbstractService';
import { Host } from '../entities/Host';

export class Hosts extends AbstractService<Host> {
    protected _getResource(): string {
        return "hosts";
    }

    public constructor() {
        super();
    }
}
