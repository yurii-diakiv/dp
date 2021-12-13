import { configureStore } from '@reduxjs/toolkit';
import { reducer as toastrReducer } from 'react-redux-toastr';
import { ReducerName } from 'common/enums';
import { columnsReducer } from './slices';

const store = configureStore({
    reducer: {
        [ReducerName.COLUMNS]: columnsReducer,
        [ReducerName.TOASTR]: toastrReducer
    }
});

export { store };
