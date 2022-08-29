import { useState } from 'react';
import {
  Button,
  Snackbar,
  TextField
} from '@mui/material';

import { createPost } from 'api/forum-api';

import './index.scss';

const defaultValues = {
  title: '',
  link: '',
  body: '',
};

const snackbarAnchor = {
  vertical: 'bottom',
  horizontal: 'center'
};

export const NewPost = (props) => {

  const [ formValues, setFormValues ] = useState(defaultValues);
  const [errorMessage, setErrorMessage] = useState('');
  const [disableSubmit, setDisableSubmit] = useState(false);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormValues({
      ...formValues,
      [name]: value,
    });
  };

  const { title, link, body} = formValues;

  const submitForm = () => {
    if(!title.length){
      setErrorMessage("A title is required!");
    }

    setDisableSubmit(true);

    createPost(formValues)
    .then((response) => response.json())
    .then((response) => {
      if (response.message) {
        setErrorMessage(response.message);
        setDisableSubmit(false);
      } else {
        const { postId } = response;
        window.location.href = `/post/${postId}`;
      }
    });

  }

  return <>
    <h1>New Post</h1>
    <form
      className='new-post-form'
    >
      <TextField
        label="Title"
        name='title'
        value={title}
        onChange={handleInputChange}
        required={true}
      />
      <TextField
        label="Link"
        name='link'
        value={link}
        onChange={handleInputChange}
      />
      <TextField
        label="Body"
        name='body'
        multiline
        rows={4}
        value={body}
        onChange={handleInputChange}
      />
      <Button
        variant='contained'
        onClick={submitForm}
        disabled={disableSubmit}
      >
        Submit
      </Button>
      <Snackbar
        open={errorMessage.length}
        autoHideDuration={4000}
        message={errorMessage}
        onClose={() => {
          setErrorMessage('');
        }}
        anchorOrigin={snackbarAnchor}
      />
    </form>
  </>;
};
