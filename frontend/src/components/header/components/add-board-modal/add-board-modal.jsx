import Modal from 'components/modal/modal';
import { useForm } from 'react-hook-form';
import { Button, TextInput, FormField } from 'components/common';

import styles from './add-board-modal.module.scss';

const DEFAULT_VALUES = {
    name: ''
};

const AddBoardModal = ({ isShown, handleCloseModal }) => {
    const { handleSubmit, control } = useForm({
        defaultValues: DEFAULT_VALUES,
    });

    const handleSubmitForm = (form) => {
        console.log(form);
        console.log('Board created');
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
                        <h2 className={styles.title}>Add board</h2>
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
                            placeholder='Board name'
                            type='text'
                            color='gray-light'
                            control={control}
                        />
                    </div>

                    <div className={styles.submitBtn}>
                        <Button
                            label="Create"
                            // hasHiddenLabel={false}
                            type='submit'
                            // color={ButtonColor.PRIMARY_DARK}
                            // styleType={ButtonStyleType.WITHOUT_BORDER}
                        />
                    </div>
                </form>
            </div>
        </Modal>
    );
};

export default AddBoardModal;
