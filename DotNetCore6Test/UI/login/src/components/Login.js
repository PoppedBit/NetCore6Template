
import { useState } from 'react';

import {
    Button,
    Snackbar,
    TextField,
} from '@mui/material';

import { requestLogin } from '../api/login';

const snackbarAnchor = {
    vertical: 'bottom',
    horizontal: 'center' 
}

export const Login = () => {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmitClicked = () => {
        if (!email.length) {
            setErrorMessage("Email is Required!");
            return;
        }

        if (!password.length) {
            setErrorMessage("Password is Required!");
            return;
        }

        requestLogin(email, password);
    }

    return <>
        <form
            className='form-login'
        >
            <TextField
                className='form-login-input'
                label="Email"
                fullWidth
                value={email}
                onChange={(e) => { setEmail(e.target.value) }}
            />
            <TextField
                className='form-login-input'
                label="Password"
                type="password"
                fullWidth
                value={password}
                onChange={(e) => { setPassword(e.target.value) }}
            />
            <Button
                className='form-login-submit'
                variant='contained'
                onClick={handleSubmitClicked}
            >Login</Button>
        </form>
        <Snackbar
            className='login-snackbar'
            open={errorMessage.length}
            autoHideDuration={4000}
            message={errorMessage}
            onClose={() => { setErrorMessage('') }}
            anchorOrigin={snackbarAnchor}
        />
    </>

}