import logo from './logo.svg';
import './App.css';

function App() {
  const increment = 10;
  const viewSize = 2;

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        <div>
          <my-blazor-counter increment={increment}></my-blazor-counter>
        </div>
        <div>
          <fetch-data view-size={viewSize}></fetch-data>
        </div>
      </header>
    </div>
  );
}

export default App;
