import { useState, useEffect } from 'react';

import { requestPosts } from 'api/forum-api';

import { PostHeader } from './components/PostHeader';

import './index.scss';

export const PostList = (props) => {
  const [posts, setPosts] = useState(null);

  useEffect(() => {
    if (!posts) {
      requestPosts({})
        .then((response) => response.json())
        .then((response) => {
          const { posts } = response;
          setPosts(posts);
        });
    }
  }, [posts]);

  if (!posts) {
    return <div>Loading</div>;
  }

  const postItems = posts.map((post) => {
    return <PostHeader post={post} />;
  });

  return <div className="post-list">{postItems}</div>;
};
