import { Http } from './http/http.service';
import { Storage } from './storage/storage.service';
import { Notification } from './notification/notification.service';

const http = new Http();

const notification = new Notification();
const storage = new Storage({ storage: localStorage });

export {
    storage,
    notification
};
