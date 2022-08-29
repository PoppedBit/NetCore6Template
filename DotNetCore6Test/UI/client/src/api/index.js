export const baseUrl = process.env.REACT_APP_API_URL;

export const getBaseRequestConfig = () => {
  const config = {
    method: 'GET',
    mode: 'cors',
    credentials: 'include',
    headers: {
      Accept: 'application/json',
      'Content-Type': 'application/json'
    }
  };

  return config;
};

export const getPostConfig = (data) => {
  const postConfig = {
    method: 'POST',
    credentials: 'include',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data)
  };

  return postConfig;
};
