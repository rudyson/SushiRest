import style from "./navigateFooter.module.scss";
import {Link} from "react-router-dom";

export const NavigateFooter = () => {

    return (
        <nav className={style.menuWrapper}>
            <Link className={style.link} to="/">Home</Link>
            <Link className={style.link} to="/Menu">Menu</Link>
            <Link className={style.link} to="/Delivery">Delivery</Link>
            <Link className={style.link} to="/AboutUs">About Us</Link>
        </nav>
    );
}
