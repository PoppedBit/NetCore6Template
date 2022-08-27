import { baseUrl, getPostConfig } from './index'

export const requestLogin = async (email, password) => {
    const data = {
        email,
        password,
    };

    const postConfig = getPostConfig(data);

    return fetch(
        `${baseUrl}/Auth/Login`,
        postConfig,
    );
}