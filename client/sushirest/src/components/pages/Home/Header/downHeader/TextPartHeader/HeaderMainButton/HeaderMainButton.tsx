import style from "./HeaderMainButton.module.css"
import {Link} from "react-router-dom";

const HeaderMainButton = () => {
    return (
        <Link
            className={style.btn}
            to="/Menu" >
            <span>our menu</span>
        </Link>
    );
}

export default HeaderMainButton;
