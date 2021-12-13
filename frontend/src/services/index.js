import { ENV } from 'common/enums';
import { Http } from './http/http.service';
import { Storage } from './storage/storage.service';
import { ColumnApi } from './column-api/column-api.service';
import { Notification } from './notification/notification.service';

const http = new Http();

const notification = new Notification();
const storage = new Storage({ storage: localStorage });

const columnApi = new ColumnApi({ http, apiPrefix: ENV.API_PATH });

export {
    storage,
    notification,
    columnApi
};
