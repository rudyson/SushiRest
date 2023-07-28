import style from "./buttons.module.scss"
import Cart from "../../../../../pics/headerPic/Cart.png"
import ProfileIcon from "../../../../../pics/headerPic/UserCircle.png"
export const HeaderButtons = () => {
    return (
        <>
            <img className={style.profileIcon} src = {ProfileIcon}></img>
            <img className = {style.cartIcon} src = {Cart}></img>
        </>
    );
}
