import TopHeader from "./topHeader/TopHeader";
import headerBack from "../../../../pics/headerPic/HeaderBack.png"
import style from "./Header.module.css"
import DownHeader from "./downHeader/DownHeader";

const Header = () => {
    return (
        <div className={style.wrapper}>
            <img className={style.backImg} src={headerBack}></img>
            <TopHeader/>
            <DownHeader/>
        </div>
    );
}
export default  Header;