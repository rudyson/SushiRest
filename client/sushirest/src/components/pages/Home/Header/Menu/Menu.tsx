import style from "./Menu.module.css";
import {Link} from "react-router-dom";
import React, {useState} from "react";




//const Menu = React.lazy(() => import("./pages/About"));
//const Delivery = React.lazy(() => import("./pages/Dashboard"));
//const AboutUs = React.lazy(() => import("./pages/Dashboard"));

const Menu = () => {
    const [selected, setSelected] = useState<string>('home');

    const handlePageClick = (page: string): void => {
        setSelected(page);
    };
    return (
        <nav className={style.menuWrapper}>
            <Link onClick={() => handlePageClick('home')}
                  className={`${style.linkText} ${style.firstLink} ${selected === 'home' ? style.selected : ''}`}
                  to="/">Home</Link>
            <Link onClick={() => handlePageClick('menu')}
                  className={`${style.linkText} ${selected === 'menu' ? style.selected : ''}`}
                  to="/Menu">Menu</Link>
            <Link onClick={() => handlePageClick('delivery')}
                  className={`${style.linkText} ${selected === 'delivery' ? style.selected : ''}`}
                  to="/Delivery">Delivery</Link>
            <Link onClick={() => handlePageClick('aboutus')}
                  className={`${style.linkText} ${selected === 'aboutus' ? style.selected : ''}`}
                  to="/AboutUs">About Us</Link>
        </nav>
    );
}

export default Menu;