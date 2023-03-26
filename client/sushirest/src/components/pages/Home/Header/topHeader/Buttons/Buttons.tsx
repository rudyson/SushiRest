import style from "./Buttons.module.css"
import Cart from "../../../../../../pics/Cart.png"
import ProfileIcon from "../../../../../../pics/User Circle.png";
const HeaderButtons = () => {
    return (
        <div>
            <img className={style.ProfileIcon} src = {ProfileIcon}></img>
            <img className = {style.CartIcon} src = {Cart}></img>
        </div>
    );
}
export  default HeaderButtons;