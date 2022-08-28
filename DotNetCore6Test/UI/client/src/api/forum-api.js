import { baseUrl, getBaseRequestConfig } from 'api';

export const requestPost = async (id, commentId) => {
  const config = getBaseRequestConfig();
  return fetch(`${baseUrl}/Forum/Post/${id}${commentId ? commentId : ''}`, config);
};