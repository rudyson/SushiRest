import style from "./HeaderMainButton.module.scss"
import {Link} from "react-router-dom";

export const HeaderMainButton = () => {
    return (
        <Link
            className={style.btn}
            to="/Menu" >
            <span>our menu</span>
        </Link>
    );
}
