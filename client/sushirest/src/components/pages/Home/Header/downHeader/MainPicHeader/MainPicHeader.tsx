import style from "./MainPicHeader.module.css"
import MainPic from "../../../../../../pics/headerPic/mainPic-min.png"
const MainPicHeader = () => {
    return (
        <>
            <img className={style.pic} src={MainPic}></img>
        </>
    );
}
export  default MainPicHeader;