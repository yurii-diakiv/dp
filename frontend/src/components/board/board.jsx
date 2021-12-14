import clsx from 'clsx';
import { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { faTrashAlt } from '@fortawesome/free-regular-svg-icons';
import { TextInput, Button } from 'components/common';
import { ColumnsActionCreator } from 'store/slices';

import styles from './board.module.scss';

const Board = () => {
    // const { columns } = useSelector(({ columns }) => ({
    //     columns: columns.columns,
    // }));

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(ColumnsActionCreator.getColumns());
    }, []);

    const [columnName, setColumnName] = useState('');

    const mokColumns = [
        {
            id: 1, name: 'To Do', cards: [
                { id: 1, title: 'Create board', text: 'Board with columns' },
                { id: 1, title: 'Create columns', text: "- Header\n- Cards\n- Actions: remove, add, edit, add a new card" },
                { id: 3, title: 'Create card', text: 'Card with information' },
                { id: 3, title: 'Create header', text: 'Header with user info' },
                { id: 3, title: 'Some new task', text: 'Info' },
                { id: 3, title: 'Some new task', text: '' },
                { id: 3, title: 'Another task', text: '' },
                { id: 3, title: 'Another task', text: 'Info' },
            ]
        },
        {
            id: 2, name: 'In Progress', cards: [
                { id: 2, title: 'In prodgress task', text: 'Info' },
                { id: 2, title: 'Some task', text: '' }
            ]
        },
        { id: 3, name: 'Code Review', cards: [] },
        {
            id: 4, name: 'Done', cards: [
                { id: 4, title: 'Done task', text: '' }
            ]
        },
    ];

    const handleColumnNameChange = id => e => console.log(id, e.target.value);

    const handleNewColumnNameChange = e => setColumnName(e.target.value);

    const handleAddColumn = () => console.log(columnName);

    const handleRemoveColumn = id => () => console.log(id);

    const handleRemoveCard = id => () => console.log(id);

    const handleAddCard = columnId => () => console.log('add a new card', columnId);

    return (
        <div className={styles.container}>
            {mokColumns.map(column =>
                <div key={column.id}>
                    <div className={styles.column}>
                        <div className={clsx(styles.inlineBlock, styles.columnHeader)}>
                            <TextInput
                                placeholder='Column name'
                                type='text'
                                color='gray-light'
                                defaultValue={column.name}
                                onBlur={handleColumnNameChange(column.id)}
                            />
                            <Button
                                label={<FontAwesomeIcon icon={faTrashAlt} />}
                                type='button'
                                color='gray-light'
                                round
                                onClick={handleRemoveColumn(column.id)}
                            />
                        </div>
                        <div className={styles.cardsContainer}>
                            {column.cards.map(card =>
                                <div key={card.id} className={styles.card}>
                                    <div className={clsx(styles.cardTitle, styles.inlineBlock)}>
                                        <div style={{ width: '100%' }}>
                                            {card.title}
                                        </div>
                                        <Button
                                            label={<FontAwesomeIcon icon={faTrashAlt} />}
                                            type='button'
                                            round
                                            onClick={handleRemoveCard(card.id)}
                                        />
                                    </div>
                                    <div className={styles.cardText}>
                                        {card.text}
                                    </div>
                                </div>
                            )}
                        </div>
                        <div className={styles.columnFooter}>
                            <Button
                                label='Add a new card'
                                type='button'
                                color='gray-light'
                                onClick={handleAddCard(column.id)}
                            />
                        </div>
                    </div>
                </div>
            )}
            <div>
                <div className={styles.newColumn}>
                    <div className={styles.inlineBlock}>
                        <TextInput
                            placeholder='Add a new column'
                            type='text'
                            color='gray-very-light'
                            onChange={handleNewColumnNameChange}
                        />
                        <Button
                            label={<FontAwesomeIcon icon={faPlus} />}
                            type='button'
                            color='primary-light'
                            iconBtn
                            onClick={handleAddColumn}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Board;
