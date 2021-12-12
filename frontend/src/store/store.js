import { configureStore } from '@reduxjs/toolkit';
import { reducer as toastrReducer } from 'react-redux-toastr';
import { ReducerName } from 'common/enums';

const store = configureStore({
    reducer: {
        [ReducerName.TOASTR]: toastrReducer
    }
});

export { store };
