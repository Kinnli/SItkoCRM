import { AbstractService } from '../http/AbstractService';
import { EmailType } from '../entities/EmailType';

export class EmailTypes extends AbstractService<EmailType> {
    protected _getResource(): string {
        return "emailtypes";
    }

    public constructor() {
        super();
    }
}
