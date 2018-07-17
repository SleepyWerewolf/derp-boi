import React from 'react';

const generateStyles = percentage => ({
  outer: {
    border: '2px solid white',
    // position: 'absolute',
    // top: '50%',
    // left: '50%',
    width: '75%',
    zIndex: '1',
  },

  inner: {
    backgroundColor: 'grey',
    width: `${percentage}%`,
  }
});

export const LoadingBar = ({ percentage }) => {
  const styles = generateStyles(percentage);

  return (
    <div style={styles.outer}>
      <div style={styles.inner} width="{percentage}%">
        {percentage}%
      </div>
    </div>
  );
};
