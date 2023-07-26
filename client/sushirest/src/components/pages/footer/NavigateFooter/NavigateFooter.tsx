import style from "./NavigateFooter.module.scss";
import {Link} from "react-router-dom";

export const NavigateFooter = () => {

    return (
        <nav className={style.menuWrapper}>
            <Link to="/">Home</Link>
            <Link to="/Menu">Menu</Link>
            <Link to="/Delivery">Delivery</Link>
            <Link to="/AboutUs">About Us</Link>
        </nav>
    );
}
