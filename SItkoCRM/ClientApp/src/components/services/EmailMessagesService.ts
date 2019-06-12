import { AbstractService } from '../http/AbstractService';
import { EmailMessage } from '../entities/EmailMessage';

export class EmailMessages extends AbstractService<EmailMessage> {
    protected _getResource(): string {
        return "emailmessages";
    }

    public constructor() {
        super();
    }
}
