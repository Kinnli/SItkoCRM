export abstract class AbstractService<T> implements IBaseService<T> {
    protected constructor(protected _httpClient: RestClient) {
    }

    public getAll(page: number | null = 0, perPage: number | null = 10, sort: string | null = '', filter: Filter | null = null): Observable<AbstractListResult<T>> {
        return this._httpClient.get(this._getResource(), {
            limit: perPage || 10,
            offset: page !== null && perPage !== null && page > 0 ? perPage * (page - 1) : 0,
            order: sort,
            filter: filter == null ? null : filter.toString()
        }).pipe(map(res => <AbstractListResult<T>>res));
    }

    public get(id: number): Observable<ModelResponse<T>> {
        return this._httpClient.get(this._getResource() + '/' + id, {})
            .pipe(map(res => <ModelResponse<T>>res));
    }

    public new(): Observable<ModelResponse<T>> {
        return this._httpClient.get(this._getResource() + '/new', {})
            .pipe(map(res => <ModelResponse<T>>res));
    }

    public add(item: T): Observable<ModelResponse<T>> {
        return this._httpClient.post(this._getResource(), item)
            .pipe(map(res => <ModelResponse<T>>res));
    }

    public update(id: number, item: T): Observable<ModelResponse<T>> {
        return this._httpClient.put(this._getResource() + '/' + id, item)
            .pipe(map(res => <ModelResponse<T>>res));
    }

    public delete(id: number): Observable<boolean> {
        return this._httpClient.delete(this._getResource() + '/' + id)
            .pipe(map(() => true));
    }

    public count(): Observable<number> {
        return this._httpClient.get(this._getResource() + '/count', {})
            .pipe(map(res => <number>res));
    }

    protected abstract _getResource(): string;
}

export class RestError {
    public message: string;
    public field: string;
}

export class RestResult {
    public code: number;
    public errors: RestError[] = [];
    public message: string;
    public isSuccess: boolean;
}

export abstract class AbstractListResult<T> {

    public abstract data: T[];

    // @JsonProperty()
    public totalItems: number;
}

export class ModelResponse<T> extends RestResult {
    public model: T;
}

export interface IBaseServiceCreatable<T> extends IBaseService<T> {
    create(name: string): Observable<ModelResponse<T>>;
}

export abstract class AbstractServiceWithUpload<T> extends AbstractService<T> implements IBaseServiceWithUpload<T> {
    public upload(file: InputFile): Observable<ModelResponse<StorageItem>> {
        // @ts-ignore
        return this._httpClient.post(this._getResource() + '/upload/', file.file, { name: file.file.name })
            .pipe(map((data: ModelResponse<StorageItem>) => data));
    }
}

export interface IBaseService<T> {
    getAll(
        page: number | null,
        perPage: number | null,
        sort: string | null,
        filter: Filter | null
    ): Observable<AbstractListResult<T>>;

    get(id: number): Observable<ModelResponse<T>>;

    add(item: T): Observable<ModelResponse<T>>;

    update(id: number, item: T): Observable<ModelResponse<T>>;

    delete(id: number): Observable<boolean>;

    count(): Observable<number>;
}

export interface IBaseServiceWithUpload<T> extends IBaseService<T> {
    upload(file: InputFile): Observable<ModelResponse<StorageItem>>;
}
