import styles from './modal.module.scss';

const Modal = ({ isShown, children }) => <>{isShown && <div className={styles.container}>{children}</div>}</>;

export default Modal;
