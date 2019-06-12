import { AbstractService } from '../http/AbstractService';
import { Server } from '../entities/Server';

export class Servers extends AbstractService<Server> {
    protected _getResource(): string {
        return "servers";
    }

    public constructor() {
        super();
    }
}
