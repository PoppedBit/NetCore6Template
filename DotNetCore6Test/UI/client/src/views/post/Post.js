import { useParams } from 'react-router-dom';

import { ExistingPost } from './ExistingPost';
import { NewPost } from './NewPost';

export const Post = (props) => {
  const params = useParams();
  const { id, commentId } = params;

  if (id) {
    return <ExistingPost 
      id={id} 
      commentId={commentId} 
    />;
  } else {
    return <NewPost />;
  }
};
