import { baseUrl, getBaseRequestConfig, getPostConfig } from 'api';

export const requestPost = async (id, commentId) => {
  const config = getBaseRequestConfig();
  return fetch(`${baseUrl}/Forum/Post/${id}${commentId ? commentId : ''}`, config);
};

export const requestPosts = async (data) => {
  const config = getPostConfig(data);
  return fetch(`${baseUrl}/Forum/Posts`, config);
};

export const createPost = async (data) => {
  const config = getPostConfig(data);
  return fetch(`${baseUrl}/Forum/Post`, config);
};
