import { HttpMethod, ColumnsApiPath, ApiPath, ContentType } from 'common/enums';

class ColumnApi {
    #http;
    #apiPrefix;

    constructor({ http, apiPrefix }) {
        this.#http = http;
        this.#apiPrefix = apiPrefix;
    }

    getColumns() {
        return this.#http.load(
            `${this.#apiPrefix}${ApiPath.COLUMNS}${ColumnsApiPath.ROOT}`,
            {
                method: HttpMethod.GET
            }
        );
    }

    createColumn(payload) {
        return this.#http.load(
            `${this.#apiPrefix}${ApiPath.COLUMNS}${ColumnsApiPath.ROOT}`,
            {
                method: HttpMethod.POST,
                contentType: ContentType.JSON,
                payload
            }
        );
    }
}

export { ColumnApi };
