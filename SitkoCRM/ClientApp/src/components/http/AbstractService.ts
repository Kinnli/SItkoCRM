import * as rm from 'typed-rest-client/RestClient';
import {Filter} from './Filter';
import {IRestResponse} from 'typed-rest-client/RestClient';

export abstract class AbstractService<T> implements IBaseService<T> {

    protected restClient: rm.RestClient;

    protected constructor() {
        this.restClient = new rm.RestClient('rest', "/");
    }

    private static encodeQueryData(data): string {
        const ret: string[] = [];
        for (const d in data) {
            if (!data.hasOwnProperty(d)) {
                continue;
            }
            ret.push(encodeURIComponent(d) + '=' + encodeURIComponent(data[d]));
        }
        return ret.join('&');
    }


    private static _getUrl(resource: string, params?: object | null): string {
        let url = resource + '?';
        if (params) {
            url += AbstractService.encodeQueryData(params);
        }
        return url;
    }

    public getAll(page: number | null = 0, perPage: number | null = 10, sort: string | null = '', filter: Filter | null = null): Promise<IRestResponse<AbstractListResult<T>>> {
        return this.restClient.get<AbstractListResult<T>>(AbstractService._getUrl(this._getResource(), {
            limit: perPage || 10,
            offset: page !== null && perPage !== null && page > 0 ? perPage * (page - 1) : 0,
            order: sort,
            filter: filter == null ? null : filter.toString()
        }));
    }

    public get(id: number): Promise<IRestResponse<ModelResponse<T>>> {
        return this.restClient.get<ModelResponse<T>>(this._getResource() + '/' + id, {});
    }

    public new(): Promise<IRestResponse<ModelResponse<T>>> {
        return this.restClient.get<ModelResponse<T>>(this._getResource() + '/new', {});
    }

    public add(item: T): Promise<IRestResponse<ModelResponse<T>>> {
        return this.restClient.create<ModelResponse<T>>(this._getResource(), item);
    }

    public update(id: number, item: T): Promise<IRestResponse<ModelResponse<T>>> {
        return this.restClient.update<ModelResponse<T>>(this._getResource() + '/' + id, item);
    }

    public delete(id: number): Promise<IRestResponse<boolean>> {
        return this.restClient.del<boolean>(this._getResource() + '/' + id);
    }

    public count(): Promise<IRestResponse<number>> {
        return this.restClient.get<number>(this._getResource() + '/count', {});
    }

    protected abstract _getResource(): string;
}

export class RestError {
    public message: string = '';
    public field: string = '';
}

export class RestResult {
    public code: number = 0;
    public errors: RestError[] = [];
    public message: string = '';
    public isSuccess: boolean = false;
}

export abstract class AbstractListResult<T> {

    public abstract data: T[];

    // @JsonProperty()
    public totalItems: number = 0;
}

export class ModelResponse<T> extends RestResult {
    public model: T | null = null;
}

export interface IBaseServiceCreatable<T> extends IBaseService<T> {
    create(name: string): Promise<IRestResponse<ModelResponse<T>>>;
}

export abstract class AbstractServiceWithUpload<T> extends AbstractService<T> implements IBaseServiceWithUpload<T> {
    public upload(file: any): Promise<IRestResponse<ModelResponse<StorageItem>>> {
        return this.restClient.create<ModelResponse<StorageItem>>(this._getResource() + '/upload/?name=' + file.file.name, file.file);
    }
}

export interface IBaseService<T> {
    getAll(
        page: number | null,
        perPage: number | null,
        sort: string | null,
        filter: Filter | null
    ): Promise<IRestResponse<AbstractListResult<T>>>;

    get(id: number): Promise<IRestResponse<ModelResponse<T>>>;

    add(item: T): Promise<IRestResponse<ModelResponse<T>>>;

    update(id: number, item: T): Promise<IRestResponse<ModelResponse<T>>>;

    delete(id: number): Promise<IRestResponse<boolean>>;

    count(): Promise<IRestResponse<number>>;
}

export interface IBaseServiceWithUpload<T> extends IBaseService<T> {
    upload(file: any): Promise<IRestResponse<ModelResponse<StorageItem>>>;
}

export class StorageItem {
    public fileName: string = '';
    public fileSize: number = 0;
    public publicUri: string = '';
    public filePath: string = '';
}
