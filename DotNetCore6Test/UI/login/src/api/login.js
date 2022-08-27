import { postData } from './index'

export const requestLogin = (email, password) => {
    const data = {
        email,
        password,
    };

    postData('/Auth/Login', data);
}