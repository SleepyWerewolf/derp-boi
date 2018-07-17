import React from 'react';
import Unity, { UnityContent } from "react-unity-webgl";

import { LoadingBar } from './LoadingBar';
import './App.css';

const { Component } = React;

export class App extends Component {
  constructor(props) {
    super(props);

    this.state = { progression: 0, shouldShowLoadingBar: true };
    this.unityContent = new UnityContent('Build/WebAssembly.json', 'Build/UnityLoader.js');
    this.unityContent.on('progress', progression => {
      this.setState({ progression });

      if (progression === 1) {
        setTimeout(() => this.setState({ shouldShowLoadingBar: false }), 500);
      }
    });
  }

  render() {
    return (
      <div className="App">
        {
          this.state.shouldShowLoadingBar &&
          <LoadingBar percentage={this.state.progression * 100} />
        }
        <div className="UnityContainer">
          <Unity unityContent={this.unityContent} width="100vw" height="100vh" />
        </div>
      </div>
    );
  }
}

export default App;
