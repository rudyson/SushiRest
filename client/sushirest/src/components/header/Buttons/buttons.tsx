import style from "./buttons.module.scss"
import Cart from "../../../pics/headerPic/Cart.png"
import ProfileIcon from "../../../pics/headerPic/UserCircle.png"
import CartWhite from "../../../pics/headerPic/cartWhite.png"
import ProfileIconWhite from "../../../pics/headerPic/userCircleWhite.png"

export const HeaderButtons = ({location}) => {
    return (
        <>
            {location.pathname === "/" ? <img className={style.profileIcon} src={ProfileIcon}></img> :
                <img className={style.profileIcon} src={ProfileIconWhite}></img>}
            {location.pathname === "/" ? <img className={style.cartIcon} src={Cart}></img> :
                <img className={style.cartIcon} src={CartWhite}></img>}
        </>
    )
}
