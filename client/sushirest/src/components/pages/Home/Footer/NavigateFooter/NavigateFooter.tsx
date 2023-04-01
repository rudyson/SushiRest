import style from "./NavigateFooter.module.css";
import {Link} from "react-router-dom";


const NavigateFooter = () => {

    return (
        <nav className={style.menuWrapper}>
            <Link className={`${style.linkText} ${style.firstLink}`}
                  to="/">Home</Link>
            <Link className={style.linkText}
                  to="/Menu">Menu</Link>
            <Link className={style.linkText}
                  to="/Delivery">Delivery</Link>
            <Link className={style.linkText}
                  to="/AboutUs">About Us</Link>
        </nav>
    );
}

export default NavigateFooter;