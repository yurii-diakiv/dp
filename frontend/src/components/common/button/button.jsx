import clsx from 'clsx';

import styles from './styles.module.scss';

const Button = ({ type, label, onClick, color, round, iconBtn }) => (
    <button
        className={clsx(styles.btn, styles[color], iconBtn && styles.iconBtn, round && styles.round)}
        type={type}
        onClick={onClick}
    >
        {label}
    </button>
);

export default Button;
