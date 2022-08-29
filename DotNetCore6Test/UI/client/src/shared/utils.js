import moment from 'moment';

export const getTimeFromNow = (timestamp) => {
  const date = new Date(timestamp);
  return moment(date).from();
};
