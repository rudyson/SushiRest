import './App.css'
import {Route, Routes} from "react-router-dom";
import MainLayout from "./layouts/mainLayout.tsx";
import Home from "./components/pages/home/home.tsx";

const App = () => {

  return (
      <Routes>
          <Route path="/" element={<MainLayout/>}>
              <Route path="" element={<Home/>}/>
          </Route>
      </Routes>
  )
}

export default App
