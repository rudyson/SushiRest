import style from "./navigation.module.scss"
import {Link} from "react-router-dom"

export const Navigation = ({location}) => {
    return (
        <nav className={style.wrapper}>
            <Link className={location.pathname === '/' ? style.active : style.linkText}
                  to="/">Home</Link>
            <Link className={location.pathname === '/menu' ? style.active : style.linkText}
                  to="menu">Menu</Link>
            <Link className={location.pathname === '/delivery' ? style.active : style.linkText}
                  to="Delivery">Delivery</Link>
            <Link className={location.pathname === '/aboutus' ? style.active : style.linkText}
                  to="AboutUs">About Us</Link>
        </nav>
    );
}
