import './App.css'
import {Route, Routes} from "react-router-dom";
import MainLayout from "./layouts/mainLayout.tsx";
import Home from "./pages/home/home.tsx";
import Menu from "./pages/menu/menu.tsx";

const App = () => {

  return (
      <Routes>
          <Route path="/" element={<MainLayout/>}>
              <Route index element={<Home/>}/>
              <Route path="menu" element={<Menu/>}/>
          </Route>
      </Routes>
  )
}

export default App
