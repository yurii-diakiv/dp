import { Http } from './http/http.service';
import { Storage } from './storage/storage.service';

const http = new Http();

const storage = new Storage({ storage: localStorage });

export {
    storage
};
