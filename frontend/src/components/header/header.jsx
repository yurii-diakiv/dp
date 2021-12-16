import { Button } from 'components/common'
import { useState } from 'react';
import { AddBoardModal } from './components'

import styles from './header.module.scss';

const Header = () => {
    const [isShown, setIsShown] = useState(false);

    const handleOpenModal = () => {
        setIsShown(true);
    }

    const handleCloseModal = () => {
        setIsShown(false);
    }

    return (
        <div className={styles.container}>
            <div className={styles.left}>
                <Button
                    label='Create'
                    type='button'
                    color='gray-light'  
                    onClick={handleOpenModal}
                />
                <Button
                    label='Boards'
                    type='button'
                    color='gray-light'  
                />
            </div>
            <div className={styles.right}>
                <a class="active" href="#home">Peter Parker</a>
                <img src="https://www.w3schools.com/howto/img_avatar.png" height="30px" alt="Avatar"></img>
            </div>

            <AddBoardModal isShown = { isShown } handleCloseModal = { handleCloseModal }/>
        </div>
    );
}

export default Header;
