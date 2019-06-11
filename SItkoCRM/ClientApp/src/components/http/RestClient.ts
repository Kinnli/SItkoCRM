const axios = require('axios');

export class RestClient {
    
    public static encodeQueryData(data): string {
        const ret: string[] = [];
        for (const d in data) {
            if (!data.hasOwnProperty(d)) {
                continue;
            }
            ret.push(encodeURIComponent(d) + '=' + encodeURIComponent(data[d]));
        }
        return ret.join('&');
    }

    public get(resource, params): Observable<any> {
        return this._httpClient.get(this._getUrl(resource, params));
    }

    public post(resource, data, params = null): Observable<any> {
        return this._httpClient.post(this._getUrl(resource, params), data);
    }

    public put(resource, data): Observable<any> {
        return this._httpClient.put(this._getUrl(resource), data);
    }

    public delete(resource): Observable<any> {
        return this._httpClient.delete(this._getUrl(resource));
    }

    private _getUrl(resource: string, params?: object | null): string {
        let url = this._baseUrl + resource + '?';
        if (params) {
            url += RestClient.encodeQueryData(params);
        }
        return url;
    }
}
