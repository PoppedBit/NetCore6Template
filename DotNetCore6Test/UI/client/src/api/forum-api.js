import { baseUrl, getBaseRequestConfig } from 'api';

export const requestPost = async (id) => {
  const config = getBaseRequestConfig();
  return fetch(`${baseUrl}/Forum/Post/${id}`, config);
};