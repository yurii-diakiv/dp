import { createSlice } from '@reduxjs/toolkit';
import { columnApi, notification as notificationService } from 'services';
import { HttpError } from 'exceptions';
import { ReducerName } from 'common/enums';

const initialState = {
    columns: []
};

const { reducer, actions } = createSlice({
    name: ReducerName.COLUMNS,
    initialState,
    reducers: {
        setColumns: (state, action) => {
            state.columns = action.payload;
        },
        addColumn: (state, action) => {
            state.columns = [...state.columns, ...action.payload];
        }
    },
});

const getColumns = () => async (dispatch) => {
    try {
        const columns = await columnApi.getColumns();
        dispatch(actions.setColumns(columns));
    } catch (error) {
        if (error instanceof HttpError) {
            return notificationService.error(`Error ${error.status}`, error.messages);
        }
        throw error;
    }
};

const addColumn = column => async (dispatch) => {
    try {
        const response = await columnApi.createColumn(column);
        dispatch(actions.addColumn(response));
    } catch (error) {
        if (error instanceof HttpError) {
            return notificationService.error(`Error ${error.status}`, error.messages);
        }
        throw error;
    }
};

const ColumnsActionCreator = {
    ...actions,
    getColumns,
    addColumn
};

export { ColumnsActionCreator, reducer };
