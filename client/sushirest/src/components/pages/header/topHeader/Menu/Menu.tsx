import style from "./menu.module.scss";
import {Link} from "react-router-dom";
import {useState} from "react";


export const Menu = () => {
    const [selected, setSelected] = useState('home')
    const handlePageClick = (page)=> {
        setSelected(page)
    };

    return (
        <nav className={style.wrapper}>
            <Link onClick={() => handlePageClick('home')}
                  className={selected === 'home' ? style.active : style.linkText}
                  to="/">Home</Link>
            <Link onClick={() => handlePageClick('menu')}
                  className={selected === 'menu' ? style.active : style.linkText}
                  to="Menu">Menu</Link>
            <Link onClick={() => handlePageClick('delivery')}
                  className={selected === 'delivery' ? style.active : style.linkText}
                  to="Delivery">Delivery</Link>
            <Link onClick={() => handlePageClick('aboutus')}
                  className={selected === 'aboutus' ? style.active : style.linkText}
                  to="AboutUs">About Us</Link>

        </nav>
    );
}
