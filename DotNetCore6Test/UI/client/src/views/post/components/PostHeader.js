import { Link } from 'react-router-dom';

import './index.scss';

export const PostHeader = (props) => {
  const { post } = props;
  const { id, title, link, createdTimestamp, authorId } = post;

  return (
    <div className="post-header">
      <div className="post-meta-data">
        <Link className="post-author" to={`/user/${authorId}`}>
          {authorId}
        </Link>
      </div>
      <div className="post-title">
        <Link to={`/post/${id}`}>{title}</Link>
      </div>
    </div>
  );
};
