import '../App.css';
import {Outlet} from "react-router-dom";
import Header from "../components/pages/header/header.tsx";
import Footer from "../components/pages/footer/footer.tsx";

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