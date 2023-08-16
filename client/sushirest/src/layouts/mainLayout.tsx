import '../App.css';
import {Outlet} from "react-router-dom";
import Footer from "../components/footer/footer.tsx";
import Header from "../components/header/header.tsx";
const MainLayout= () => {
    return (
        <>
            <Header/>
            <Outlet/>
            <Footer/>
        </>
    );
}

export default MainLayout;