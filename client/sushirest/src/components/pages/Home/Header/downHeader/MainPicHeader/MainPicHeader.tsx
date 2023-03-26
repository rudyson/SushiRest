import style from "./MainPicHeader.module.css"
import MainPic from "../../../../../../pics/mainPic-min.png"
const MainPicHeader = () => {
    return (
        <>
            <img className={style.Pic} src={MainPic}></img>
        </>
    );
}
export  default MainPicHeader;