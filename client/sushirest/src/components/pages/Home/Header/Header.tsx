import TopHeader from "./topHeader/TopHeader";
import headerBack from "../../../../pics/HeaderBack.png"
import style from "./Header.module.css"
import DownHeader from "./downHeader/DownHeader";

const Header = () => {
    return (
        <div className={style.wrapper}>
            <img className={style.BackImg} src={headerBack}></img>
            <TopHeader/>
            <DownHeader/>
        </div>
    );
}
export default  Header;