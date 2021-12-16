import Modal from 'components/modal/modal';
import { useForm } from 'react-hook-form';
import { Button, TextInput, FormField } from 'components/common';

import styles from './add-card-modal.module.scss';

const DEFAULT_VALUES = {
    title: '',
    description: '',
    assignee: ''
};

const AddBoardModal = ({ isShown, handleCloseModal, columnId }) => {
    const { handleSubmit, control } = useForm({
        defaultValues: DEFAULT_VALUES,
    });

    const handleSubmitForm = (form) => {
        console.log(columnId);
        console.log(form);
        console.log('Card created');
        handleCloseModal();
    }

    return (
        <Modal isShown={isShown}>
            <div className={styles.container}>
                <form
                    onSubmit={handleSubmit(handleSubmitForm)}
                    className={styles.createForm}
                >
                    <div className={styles.header}>
                        <h2 className={styles.title}>Add card</h2>
                        <button
                            className={styles.closeButton}
                            onClick={handleCloseModal}
                            type="button"
                        >
                            &#10060;
                            {/* <span className="visually-hidden">Close</span> */}
                        </button>
                    </div>

                    <div className={styles.inputBlock}>
                        <FormField
                            component={TextInput}
                            name='name'
                            placeholder='Title'
                            type='text'
                            color='gray-light'
                            control={control}
                        />
                    </div>

                    <div className={styles.inputBlock}>
                        <FormField
                            component={TextInput}
                            name='description'
                            placeholder='Description'
                            type='text'
                            color='gray-light'
                            control={control}
                        />
                    </div>

                    <div className={styles.inputBlock}>
                        <FormField
                            component={TextInput}
                            name='assignee'
                            placeholder='Assignee'
                            type='text'
                            color='gray-light'
                            control={control}
                        />
                    </div>

                    <div className={styles.submitBtn}>
                        <Button
                            label="Create"
                            type='submit'
                        />
                    </div>
                </form>
            </div>
        </Modal>
    );
};

export default AddBoardModal;
