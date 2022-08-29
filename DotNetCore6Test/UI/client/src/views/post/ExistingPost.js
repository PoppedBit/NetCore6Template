import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import { requestPost } from 'api/forum-api';
import { getTimeFromNow } from 'shared/utils';

import { PostHeader } from './components/PostHeader';

import './index.scss';

export const ExistingPost = (props) => {
  const { id, commentId } = props;

  const [post, setPost] = useState(null);
  const [comments, setComments] = useState([]);

  useEffect(() => {
    if (!post) {
      requestPost(id, commentId)
        .then((response) => response.json())
        .then((response) => {
          const { post, comments } = response;
          setPost(post);
          setComments(comments);
        });
    }
  }, [id, post]);

  if (!post) {
    return <div>Loading</div>;
  }

  const { body } = post;

  return (
    <>
      <PostHeader post={post} />
      <div className="post-body">{body}</div>
    </>
  );
};
