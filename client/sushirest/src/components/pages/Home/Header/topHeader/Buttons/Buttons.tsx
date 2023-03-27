import style from "./Buttons.module.css"
import Cart from "../../../../../../pics/headerPic/Cart.png"
import ProfileIcon from "../../../../../../pics/headerPic/User Circle.png";
const HeaderButtons = () => {
    return (
        <div>
            <img className={style.profileIcon} src = {ProfileIcon}></img>
            <img className = {style.cartIcon} src = {Cart}></img>
        </div>
    );
}
export  default HeaderButtons;