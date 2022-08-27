export const baseUrl = process.env.REACT_APP_API_URL;

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
