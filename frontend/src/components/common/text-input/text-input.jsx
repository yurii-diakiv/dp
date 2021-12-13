import clsx from 'clsx';

import styles from '../common-styles.module.scss';

const TextInput = ({ type, label, placeholder, color, disabled, onChange, onBlur, defaultValue, field }) => (
    <span className={styles.inputControl}>
        <label className={styles.label}>
            {label && <span className={clsx(styles.labelText)}>
                {label}
            </span>}
            <input
                type={type}
                placeholder={placeholder}
                className={clsx(styles.textInput, styles[color])}
                disabled={disabled}
                onChange={onChange}
                onBlur={onBlur}
                defaultValue={defaultValue}
                {...field}
            />
        </label>
    </span>
);

export default TextInput;
