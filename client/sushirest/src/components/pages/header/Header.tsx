import {TopHeader, DownHeader} from "../../../index.ts";
import headerBack from "../../../pics/headerPic/HeaderBack.png"
import style from "./Header.module.scss"

const Header = () => {
    return (
        <header className={style.wrapper}>
            <img className={style.headerBack} src={headerBack}></img>
            <TopHeader/>
            <DownHeader/>
        </header>
    );
}
export default  Header;