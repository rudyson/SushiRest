import style from "./headerMainButton.module.scss"
import {Link} from "react-router-dom";

export const HeaderMainButton = () => {
    return (
        <Link
            className={style.btn}
            to="menu" >
            <span>our menu</span>
        </Link>
    );
}
