import style from "./header.module.scss"
import {Navigation, HeaderButtons} from "../../index.ts";
import {Link, useLocation} from "react-router-dom";
import headerBack from "../../pics/headerPic/HeaderBack.png";

const Header = () => {
    const location = useLocation()
    return (
        <section className={location.pathname === "/" ? style.wrapper : style.alt}>
            {location.pathname === "/" && (<img className={style.headerBack} src={headerBack}></img>) }
            <h1>
                <Link to = "/">SUSHIREST</Link>
            </h1>
            <Navigation location={location} />
            <HeaderButtons location={location}/>
        </section>
    );
}

export default Header
