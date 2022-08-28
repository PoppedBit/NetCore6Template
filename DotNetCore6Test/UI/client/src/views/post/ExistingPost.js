import { useState, useEffect } from 'react';

import { requestPost } from 'api/forum-api';

export const ExistingPost = (props) => {
  const { id } = props;

  const [post, setPost] = useState(null);
  const [comments, setComments] = useState([]);

  useEffect(() => {
    if(!post){
      requestPost(id)
        .then((response) => response.json())
        .then((response) => {
          const { post, comments } = response;
          setPost(post);
          setComments(comments);
        });
    }
  }, [id, post]);

  if(!post){
    return <div>Loading</div>;
  }

  const { title, link, body, createdTimestamp } = post;

  return <div>{title}</div>
};
