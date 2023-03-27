import style from "./TopHeader.module.css"
import Menu from "../Menu/Menu";
import HeaderButtons from "./Buttons/Buttons";
const TopHeader = () => {
    return (
        <div className={style.wrapper}>
            <p className={style.mainText}>SUSHIREST</p>
            <Menu/>
            <HeaderButtons/>
        </div>
    );
}
export  default TopHeader;


