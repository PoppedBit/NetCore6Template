
const baseUrl = process.env.REACT_APP_API_URL;

export const postData = (endpoint, data) => {
    const postConfig = {
        method: 'POST',
        credentials: 'include',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    };
    fetch(
        `${baseUrl}${endpoint}`,
        postConfig,
    );
}