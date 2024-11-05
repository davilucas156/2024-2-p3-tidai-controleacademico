import './styles/App.css';
import ViewIndex from './views/index';  
import { BrowserRouter as Router } from 'react-router-dom';
import '@fortawesome/fontawesome-free/css/all.min.css';

function App() {
  return (
    <div className="App">
      <Router>
        <ViewIndex />
      </Router>
    </div>
  );
}

export default App;